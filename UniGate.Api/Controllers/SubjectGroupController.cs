using Microsoft.AspNetCore.Mvc;
using UniGate.Infrastructure;
using UniGate.Shared.DTOs;

[ApiController]
[Route("api/subject-groups")]
public class SubjectGroupController : ControllerBase
{
    private readonly AppDbContext _db;

    public SubjectGroupController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(
            _db.SubjectGroups
                .Select(g => new SubjectGroupDto
                {
                    GroupID = g.GroupID,
                    GroupName = g.GroupName,
                    Subjects = g.Subjects
                })
                .ToList()
        );
    }
}
