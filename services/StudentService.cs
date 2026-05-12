using StudentManagerConsole.Interfaces;
using StudentManagerConsole.Models;
using Microsoft.Data.Sqlite;

namespace StudentManagerConsole.Services
{
    public class StudentService : IStudentService
    {
        private readonly IValidator<Student> _validator;
        private readonly string _connectionString = "Data Source=students.db";

        public StudentService(IValidator<Student> validator)
        {
            _validator = validator;
            InitializeDatabase();
        }

        public bool AddStudent(Student student, out string errorMessage)
        {
            if (!_validator.Validate(student, out errorMessage))
                return false;

            using SqliteConnection connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = "INSERT INTO Students (Name, StudentNumber, Course) VALUES (@Name, @StudentNumber, @Course)";
            using SqliteCommand command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", student.Name);
            command.Parameters.AddWithValue("@StudentNumber", student.StudentNumber);
            command.Parameters.AddWithValue("@Course", student.Course);
            command.ExecuteNonQuery();

            errorMessage = string.Empty;
            return true;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using SqliteConnection connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = "SELECT Name, StudentNumber, Course FROM Students";
            using SqliteCommand command = new SqliteCommand(sql, connection);
            using SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                students.Add(new Student
                {
                    Name = reader.GetString(0),
                    StudentNumber = reader.GetString(1),
                    Course = reader.GetString(2)
                });
            }

            return students;
        }

        private void InitializeDatabase()
        {
            using SqliteConnection connection = new SqliteConnection(_connectionString);
            connection.Open();

            string sql = @"CREATE TABLE IF NOT EXISTS Students (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                StudentNumber TEXT NOT NULL,
                Course TEXT NOT NULL
            )";

            using SqliteCommand command = new SqliteCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
}