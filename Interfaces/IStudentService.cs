using StudentManagerConsole.Models;

namespace StudentManagerConsole.Interfaces
{
    public interface IStudentService
    {
        bool AddStudent(Student student, out string errorMessage);
        List<Student> GetAllStudents();
    }
}