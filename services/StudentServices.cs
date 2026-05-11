public class StudentService
{
    List<Student> students = new List<Student>();
    public void AddStudent(Student student)
{
    Student.Add(student);
}
    public List<Student> GetAllStudents()
    {
        return students;
    }
}

