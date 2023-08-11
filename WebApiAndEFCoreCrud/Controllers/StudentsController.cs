using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentLibrary.Contract;
using StudentLibrary.Models;
using System.Diagnostics.Contracts;

namespace WebApiAndEFCoreCrud.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentRepository _student;

    public StudentsController(IStudentRepository student)
    {
        _student = student;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
    {
        var students = await _student.GetAllStudents();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudentById(int id)
    {
        var student = await _student.GetStudentById(id);

        if (student is null)
            return NotFound("Student not found.");

        return Ok(student);
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent(Student student)
    {
        await _student.CreateStudent(student);
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateStudent(Student student, int id)
    {
        var existStudent = await _student.UpdateStudent(student, id);

        if (existStudent is null) return BadRequest();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Student>> DeleteStudent(int id)
    {
        var student = await _student.DeleteStudent(id);

        if (student is null) return NotFound();

        return NoContent();
    }

}
