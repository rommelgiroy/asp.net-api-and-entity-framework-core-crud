using StudentLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary.Contract;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllStudents();
    Task GetStudentById(int id);
    Task CreateStudent(Student student);
    Task UpdateStudent(int id);
    Task DeleteStudent(int id);
}
