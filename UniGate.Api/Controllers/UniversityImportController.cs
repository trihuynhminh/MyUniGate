using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using UniGate.Core.Entities;
using UniGate.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace UniGate.Api.Controllers
{
    [ApiController]
    [Route("api/import")]
    public class UniversityImportController : ControllerBase
    {
        private readonly AppDbContext _db;

        public UniversityImportController(AppDbContext db)
        {
            _db = db;
        }

        // DTO để Swagger hiển thị nút Choose File
        public class FileUploadDto
        {
            public IFormFile File { get; set; }
        }

        // Import Universities (tên route vẫn giữ là "schools" để tương thích cũ)
        // Excel format:
        // Col1: Code, Col2: Name, Col3: Province, Col4: Website, Col5: Description, Col6: LogoUrl
        [HttpPost("schools")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> ImportUniversities([FromForm] FileUploadDto request)
        {
            var file = request.File;

            if (file == null || file.Length == 0)
                return BadRequest("File không hợp lệ!");

            // Cấu hình LicenseContext cho EPPlus
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            stream.Position = 0;

            using var package = new ExcelPackage(stream);
            var sheet = package.Workbook.Worksheets.FirstOrDefault();
            if (sheet == null)
                return BadRequest("Không tìm thấy sheet trong file Excel!");

            int row = 2; // bỏ dòng tiêu đề đầu tiên

            int total = 0;
            int inserted = 0;
            int updated = 0;
            int skipped = 0;
            var errors = new List<object>();

            while (sheet.Cells[row, 1].Value != null)
            {
                total++;

                string code = sheet.Cells[row, 1].Text?.Trim() ?? "";
                string name = sheet.Cells[row, 2].Text?.Trim() ?? "";
                string province = sheet.Cells[row, 3].Text?.Trim() ?? "";
                string website = sheet.Cells[row, 4].Text?.Trim() ?? "";
                string description = sheet.Cells[row, 5].Text?.Trim() ?? "";
                string logoUrl = sheet.Cells[row, 6].Text?.Trim() ?? "";

                // Thiếu code hoặc name => bỏ qua dòng này
                if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(name))
                {
                    skipped++;
                    row++;
                    continue;
                }

                try
                {
                    // Tìm theo UniversityCode (unique)
                    var uni = await _db.Universities.FirstOrDefaultAsync(u => u.UniversityCode == code);

                    if (uni == null)
                    {
                        // Thêm mới
                        uni = new University
                        {
                            UniversityCode = code,
                            UniversityName = name,
                            Province = province,
                            Website = website,
                            Description = description,
                            LogoUrl = logoUrl
                        };

                        _db.Universities.Add(uni);
                        inserted++;
                    }
                    else
                    {
                        // Cập nhật
                        uni.UniversityName = name;
                        uni.Province = province;
                        uni.Website = website;
                        uni.Description = description;
                        uni.LogoUrl = logoUrl;
                        updated++;
                    }
                }
                catch (Exception ex)
                {
                    errors.Add(new
                    {
                        Row = row,
                        Code = code,
                        Name = name,
                        Error = ex.Message
                    });
                }

                row++;
            }

            await _db.SaveChangesAsync();

            // Kết quả trả về (để test và debug dễ)
            return Ok(new
            {
                Message = "Import danh sách trường thành công!",
                TotalRows = total,
                Inserted = inserted,
                Updated = updated,
                Skipped = skipped,
                ErrorCount = errors.Count,
                Errors = errors
            });
        }
    }
}
