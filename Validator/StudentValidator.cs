using StudentManagerConsole.Interfaces;
using StudentManagerConsole.Models;

namespace StudentManagerConsole.Validators
{
    public class StudentValidator : IValidator<Student>
    {
        public bool Validate(Student student, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(student.Name))
            {
                errorMessage = "Name cannot be empty.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(student.StudentNumber) || student.StudentNumber.Length < 5)
            {
                errorMessage = "Student number must be at least 5 characters.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(student.Course))
            {
                errorMessage = "Course cannot be empty.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}