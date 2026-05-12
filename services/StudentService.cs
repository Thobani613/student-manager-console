using StudentManagerConsole.Interfaces;
using StudentManagerConsole.Models;

namespace StudentManagerConsole.Services
{
    public class StudentService : IStudentService
    {
        private readonly List<Student> _students = new List<Student>();
        private readonly IValidator<Student> _validator;

        public StudentService(IValidator<Student> validator)
        {
            _validator = validator;
        }

        public bool AddStudent(Student student, out string errorMessage)
        {
            if (!_validator.Validate(student, out errorMessage))
                return false;

            _students.Add(student);
            errorMessage = string.Empty;
            return true;
        }

        public List<Student> GetAllStudents()
        {
            return _students;
        }
    }
}