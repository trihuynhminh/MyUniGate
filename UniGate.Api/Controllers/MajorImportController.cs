using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.ComponentModel;
using UniGate.Core.Entities;
using UniGate.Infrastructure;


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
        public async Task<IActionResult> ImportMajors([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File không hợp lệ!");

            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;


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
                string uniCode = sheet.Cells[row, 3].Text.Trim();       // schoolCode cũ -> UniversityCode mới
                string cutoffRaw = sheet.Cells[row, 4].Text.Trim();     // điểm chuẩn
                string combosRaw = sheet.Cells[row, 5].Text.Trim();     // A00,D01

                if (string.IsNullOrWhiteSpace(majorCode) || string.IsNullOrWhiteSpace(majorName))
                {
                    row++;
                    continue;
                }

                // 1) Tìm University theo UniversityCode (thay vì Schools.Code)
                var uni = _db.Universities.FirstOrDefault(u => u.UniversityCode == uniCode);
                if (uni == null)
                {
                    row++;
                    continue; // y hệt logic cũ: trường không tồn tại thì skip dòng
                }

                // 2) Parse cutoff
                decimal cutoff = 0;
                decimal.TryParse(cutoffRaw, out cutoff);

                // 3) Tạo hoặc update Major theo MajorCode
                var major = _db.Majors.FirstOrDefault(m => m.MajorCode == majorCode);

                if (major == null)
                {
                    major = new Major
                    {
                        MajorCode = majorCode,
                        MajorName = majorName
                    };
                    _db.Majors.Add(major);
                    await _db.SaveChangesAsync();
                }
                else
                {
                    major.MajorName = majorName;
                    await _db.SaveChangesAsync();
                }

                // 4) xử lý combos: xóa MajorGroups cũ rồi add mới (giống MajorCombos cũ)
                var oldGroups = _db.MajorGroups.Where(x => x.MajorID == major.MajorID);
                _db.MajorGroups.RemoveRange(oldGroups);

                var comboCodes = combosRaw.Split(',')
                    .Select(c => c.Trim())
                    .Where(c => !string.IsNullOrWhiteSpace(c))
                    .Distinct()
                    .ToList();

                // để import Admissions theo từng combo
                int importYear = DateTime.Now.Year;

                foreach (var code in comboCodes)
                {
                    // SubjectGroups.GroupName = A00, D01...
                    var group = _db.SubjectGroups.FirstOrDefault(g => g.GroupName == code);
                    if (group == null) continue;

                    // add MajorGroups
                    _db.MajorGroups.Add(new MajorGroup
                    {
                        MajorID = major.MajorID,
                        GroupID = group.GroupID,
                        ExamYear = (short?)importYear
                    });

                    // 5) Lưu điểm chuẩn (DB mới nằm ở Admissions)
                    // Key unique: (UniversityID, MajorID, GroupID, Year)
                    var admission = _db.Admissions.FirstOrDefault(a =>
                        a.UniversityID == uni.UniversityID &&
                        a.MajorID == major.MajorID &&
                        a.GroupID == group.GroupID &&
                        a.Year == (short)importYear);

                    if (admission == null)
                    {
                        admission = new Admission
                        {
                            UniversityID = uni.UniversityID,
                            MajorID = major.MajorID,
                            GroupID = group.GroupID,
                            Year = (short)importYear,
                            MinScore = cutoff
                        };
                        _db.Admissions.Add(admission);
                    }
                    else
                    {
                        // update cutoff giống cũ
                        admission.MinScore = cutoff;
                    }
                }

                await _db.SaveChangesAsync();
                row++;
            }

            // output giống cũ
            return Ok("Import danh sách ngành thành công!");
        }
    }
}
