using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using UniGate.Api.DTOs;
using UniGate.Api.Services;
//using UniGate.Application.DTOs.Score;
using UniGate.Core.Entities;
using UniGate.Infrastructure;


namespace UniGate.Api.Controllers
{
    [ApiController]
    [Route("api/user-scores")]
    public class UserScoresController : ControllerBase
    {
        private readonly AppDbContext _db;

        public UserScoresController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost("save")]
        public async Task<IActionResult> SaveScores([FromBody] UserScoreRequest req)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var score = await _db.UserScores.FindAsync(req.UserId);

            if (score == null)
            {
                score = new UserScore { UserID = req.UserId };
                _db.UserScores.Add(score);
            }

            foreach (var prop in typeof(UserScoreRequest).GetProperties())
            {
                var target = typeof(UserScore).GetProperty(prop.Name);
                if (target != null)
                    target.SetValue(score, prop.GetValue(req));
            }

            await _db.SaveChangesAsync();
            return Ok(new { Message = "Lưu điểm thành công" });
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetScores(int userId)
        {
            var score = await _db.UserScores.FindAsync(userId);

            if (score == null)
                return NotFound(new { Message = "Người dùng chưa nhập điểm!" });

            return Ok(score);
        }



    }
}
