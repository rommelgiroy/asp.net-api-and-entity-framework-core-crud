using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentLibrary.Contract;
using StudentLibrary.Models;

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

    [HttpPost]
    public async Task<IActionResult> CreateStudent(Student student)
    {
        await _student.CreateStudent(student);
        return NoContent();
    }

}
