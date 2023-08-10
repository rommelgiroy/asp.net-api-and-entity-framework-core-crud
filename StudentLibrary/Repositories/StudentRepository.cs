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

    public Task DeleteStudent(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Student>> GetAllStudents()
    {
        var students = await _dbContext.Student.ToListAsync();
        return students;
    }

    public Task GetStudentById(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateStudent(int id)
    {
        throw new NotImplementedException();
    }
}
