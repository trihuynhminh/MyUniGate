using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using UniGate.Core.Entities;
using UniGate.Infrastructure;
using UniGate.Api.DTOs;

namespace UniGate.Api.Controllers
{
    [ApiController]
    [Route("api/import")]
    public class MajorImportController : ControllerBase
    {
        private readonly AppDbContext _db;

        public MajorImportController(AppDbContext db)
        {
            _db = db;
        }


        // Excel columns (giống cũ):
        // 1 MajorCode | 2 MajorName | 3 SchoolCode(UniversityCode) | 4 Cutoff | 5 Combos(A00,D01)
        [HttpPost("majors")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> ImportMajors([FromForm] FileUploadDto request)
        {
            var file = request.File;

            if (file == null || file.Length == 0)
                return BadRequest("File không hợp lệ!");

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            stream.Position = 0;

            using var package = new ExcelPackage(stream);
            var sheet = package.Workbook.Worksheets.FirstOrDefault();
            if (sheet == null)
                return BadRequest("Không tìm thấy sheet!");

            int row = 2;

            while (sheet.Cells[row, 1].Value != null)
            {
                string majorCode = sheet.Cells[row, 1].Text.Trim();
                string majorName = sheet.Cells[row, 2].Text.Trim();
                string uniCode = sheet.Cells[row, 3].Text.Trim();
                string cutoffRaw = sheet.Cells[row, 4].Text.Trim();
                string combosRaw = sheet.Cells[row, 5].Text.Trim();

                if (string.IsNullOrWhiteSpace(majorCode) || string.IsNullOrWhiteSpace(majorName))
                {
                    row++;
                    continue;
                }

                // 1) Tìm University theo UniversityCode
                var uni = await _db.Universities.FirstOrDefaultAsync(u => u.UniversityCode == uniCode);
                if (uni == null)
                {
                    row++;
                    continue; // giữ logic cũ: không có trường => skip
                }

                // 2) Parse cutoff
                decimal cutoff = 0;
                decimal.TryParse(cutoffRaw, out cutoff);

                // 3) Tạo hoặc update Major theo MajorCode
                var major = await _db.Majors.FirstOrDefaultAsync(m => m.MajorCode == majorCode);

                if (major == null)
                {
                    major = new Major
                    {
                        MajorCode = majorCode,
                        MajorName = majorName
                    };
                    _db.Majors.Add(major);
                    await _db.SaveChangesAsync(); // để có MajorID
                }
                else
                {
                    major.MajorName = majorName;
                    await _db.SaveChangesAsync();
                }

                // 4) Xóa MajorGroups cũ rồi add mới
                var oldGroups = _db.MajorGroups.Where(x => x.MajorID == major.MajorID);
                _db.MajorGroups.RemoveRange(oldGroups);

                var comboCodes = combosRaw.Split(',')
                    .Select(c => c.Trim())
                    .Where(c => !string.IsNullOrWhiteSpace(c))
                    .Distinct()
                    .ToList();

                int importYear = DateTime.Now.Year;

                foreach (var code in comboCodes)
                {
                    var group = await _db.SubjectGroups.FirstOrDefaultAsync(g => g.GroupName == code);
                    if (group == null) continue;

                    _db.MajorGroups.Add(new MajorGroup
                    {
                        MajorID = major.MajorID,
                        GroupID = group.GroupID,
                        ExamYear = (short)importYear
                    });

                    // 5) Admissions: lưu điểm chuẩn
                    var admission = await _db.Admissions.FirstOrDefaultAsync(a =>
                        a.UniversityID == uni.UniversityID &&
                        a.MajorID == major.MajorID &&
                        a.GroupID == group.GroupID &&
                        a.Year == (short)importYear);

                    if (admission == null)
                    {
                        _db.Admissions.Add(new Admission
                        {
                            UniversityID = uni.UniversityID,
                            MajorID = major.MajorID,
                            GroupID = group.GroupID,
                            Year = (short)importYear,
                            MinScore = cutoff
                        });
                    }
                    else
                    {
                        admission.MinScore = cutoff;
                    }
                }

                await _db.SaveChangesAsync();
                row++;
            }

            return Ok("Import danh sách ngành thành công!");
        }
    }
}
