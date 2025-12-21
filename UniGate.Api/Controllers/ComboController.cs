using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniGate.Infrastructure;
using UniGate.Api.DTOs;




namespace UniGate.Api.Controllers
{
    [ApiController]
    [Route("api/combos")]
    public class ComboController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ComboController(AppDbContext db)
        {
            _db = db;
        }

        // =========================
        // GET: api/combos
        // Logic cũ: trả về Id + Code + Subjects(List)
        // DB mới: SubjectGroups (GroupID, GroupName, Subjects string)
        // =========================
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _db.SubjectGroups
                .AsNoTracking()
                .Select(g => new ComboDto
                {
                    Id = g.GroupID,
                    Code = g.GroupName,
                    Subjects = ParseSubjects(g.Subjects)
                })
                .ToList();

            return Ok(list);
        }

        // =========================
        // GET: api/combos/with-subjects
        // Logic cũ: trả về Code + Subjects(List)
        // =========================
        [HttpGet("with-subjects")]
        public IActionResult GetCombosWithSubjects()
        {
            var combos = _db.SubjectGroups
                .AsNoTracking()
                .Select(g => new ComboWithSubjectsDto
                {
                    Code = g.GroupName,
                    Subjects = ParseSubjects(g.Subjects)
                })
                .ToList();

            return Ok(combos);
        }

        // Tách chuỗi "Toán, Lý, Hóa" -> List<string>
        // (nếu data của bạn dùng dấu ; hoặc | thì cũng tách luôn)
        private static List<string> ParseSubjects(string? subjectsRaw)
        {
            if (string.IsNullOrWhiteSpace(subjectsRaw))
                return new List<string>();

            return subjectsRaw
                .Split(new[] { ',', ';', '|' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList();
        }
    }

    
}
