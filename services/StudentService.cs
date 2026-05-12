using StudentManagerConsole.Interfaces;
using StudentManagerConsole.Models;
using System.Text.Json;

namespace StudentManagerConsole.Services
{
    public class StudentService : IStudentService
    {
        private readonly IValidator<Student> _validator;
        private readonly string _filePath = "students.json";
        private List<Student> _students;

        public StudentService(IValidator<Student> validator)
        {
            _validator = validator;
            _students = LoadStudents();
        }

        public bool AddStudent(Student student, out string errorMessage)
        {
            if (!_validator.Validate(student, out errorMessage))
                return false;

            _students.Add(student);
            SaveStudents();
            errorMessage = string.Empty;
            return true;
        }

        public List<Student> GetAllStudents()
        {
            return _students;
        }

        private void SaveStudents()
        {
            string json = JsonSerializer.Serialize(_students);
            File.WriteAllText(_filePath, json);
        }

        private List<Student> LoadStudents()
        {
            if (!File.Exists(_filePath))
                return new List<Student>();

            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
        }
    }
}