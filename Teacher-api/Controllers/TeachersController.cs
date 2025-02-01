using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teacher_api.Models;

namespace Teacher_api.Controllers;

public class TeachersController : ControllerBase
{
    private readonly AppDbContext _context;

    public TeachersController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet("GetAllTeachersByStudent")]
    public async Task<ActionResult<IEnumerable<Teacher>>> GetAllTeachersByStudent(string studentName)
    {
        var student = await _context.Pupils
            .FirstOrDefaultAsync(p => p.FirstName == studentName);

        if (student == null)
        {
            return NotFound("Student not found.");
        }

        var teachers = await _context.Teachers
            .Where(t => t.Pupils.Contains(student))
            .ToListAsync();

        return Ok(teachers);
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<Teacher>>> getAll()
    {
        var students = await _context.Pupils.ToListAsync();
        return Ok(students);
    }
}