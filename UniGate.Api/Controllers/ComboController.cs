using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using UniGate.Infrastructure;
using UniGate.Api.DTOs;
using UniGate.Shared.DTOs;


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
        // GET: api/combos (ADMIN)
        // =========================
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _db.SubjectGroups
                .AsNoTracking()
                .Select(g => new DTOs.ComboDto
                {
                    Id = g.GroupID,
                    Code = g.GroupName,
                    Subjects = ParseSubjects(g.Subjects)
                })
                .ToList();

            return Ok(list);
        }

        // =========================
        // GET: api/combos/for-student
        // =========================
        [HttpGet("for-student")]
        public IActionResult GetForStudent()
        {
            var combos = _db.SubjectGroups
                .AsNoTracking()
                .Select(g => new ComboInfoDto
                {
                    Code = g.GroupName,
                    Subjects = ParseSubjects(g.Subjects)
                })
                .ToList();

            return Ok(combos);
        }

        // =========================
        // Helper
        // =========================
        private static List<string> ParseSubjects(string? raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return new();

            return raw
                .Split(new[] { ',', ';', '|' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList();
        }
    }
}
