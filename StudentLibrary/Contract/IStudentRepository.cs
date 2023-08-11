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
    Task<Student?> GetStudentById(int id);
    Task CreateStudent(Student student);
    Task<Student?> UpdateStudent(Student student, int id);
    Task<Student?> DeleteStudent(int id);
}
