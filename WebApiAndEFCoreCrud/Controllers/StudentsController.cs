using Microsoft.AspNetCore.Mvc;
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

    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudentById(int id)
    {
        var student = await _student.GetStudentById(id);

        if (student is null)
            return NotFound("Student not found.");

        return Ok(student);
    }

    [HttpPost]
    public async Task<ActionResult> CreateStudent(Student student)
    {
        await _student.CreateStudent(student);
        return Ok("Student successfully save");
    }

    [HttpPut]
    public async Task<ActionResult> UpdateStudent(Student student, int id)
    {
        var existStudent = await _student.UpdateStudent(student, id);

        if (existStudent is null) return BadRequest();

        return Ok("Studet successfully updated");
    }

    [HttpDelete("{id}")] 
    public async Task<ActionResult<Student>> DeleteStudent(int id)
    {
        var student = await _student.DeleteStudent(id);

        if (student is null) return NotFound();

        return NoContent();
    }

}
