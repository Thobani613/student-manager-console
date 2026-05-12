
public interface IStudentService
{
    bool AddStudent(Student student, out string errorMessage);
    List<Student> GetAllStudents();
}