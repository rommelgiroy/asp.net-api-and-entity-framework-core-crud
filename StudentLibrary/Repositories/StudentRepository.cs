using Microsoft.EntityFrameworkCore;
using StudentLibrary.Contract;
using StudentLibrary.Data;
using StudentLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public StudentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task CreateStudent(Student student)
    {
        _dbContext.Add(student);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Student?> DeleteStudent(int id)
    {
        var student = await _dbContext.Student.FindAsync(id);

        if (student is null) return null;

        _dbContext.Student.Remove(student);
        await _dbContext.SaveChangesAsync();

        return student;
    }

    public async Task<IEnumerable<Student>> GetAllStudents()
    {
        var students = await _dbContext.Student.ToListAsync();
        return students;
    }

    public async Task<Student?> GetStudentById(int id)
    {
        var student = await _dbContext.Student.FindAsync(id);

        if (student is null) return null;

        return student;
    }

    public async Task<Student?> UpdateStudent(Student student, int id)
    {
        var existStudent = await _dbContext.Student.FindAsync(id);

        if (existStudent is null) return null;

        existStudent.StudentNumber = student.StudentNumber;
        existStudent.FirstName = student.FirstName;
        existStudent.LastName = student.LastName;
        existStudent.PhoneNo = student.PhoneNo;
        existStudent.EmailAddress = student.EmailAddress;


        //_dbContext.Student.Update(student);
        await _dbContext.SaveChangesAsync();

        return student;
    }
}
