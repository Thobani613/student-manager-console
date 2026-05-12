using StudentManagerConsole.Interfaces;
using StudentManagerConsole.Models;
using StudentManagerConsole.Services;
using StudentManagerConsole.Validators;
using Microsoft.Extensions.DependencyInjection;

IStudentService studentService = new StudentService(new StudentValidator());
bool isRunning = true;

while (isRunning)
{
    ShowMenu();

    Console.Write("Choose an option: ");
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Clear();
            AddStudent();
            break;

        case "2":
            Console.Clear();
            AddGraduateStudent();
            break;

        case "3":
            Console.Clear();
            ViewAllStudents();
            break;

        case "4":
            isRunning = false;
            break;

        default:
            Console.WriteLine("Invalid option. Please choose 1, 2, 3 or 4.");
            Console.WriteLine("Press any key to try again...");
            Console.ReadKey();
            break;
    }
}

void ShowMenu()
{
    Console.Clear();
    Console.WriteLine("=== Student Manager v7 ===");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. Add Graduate Student");
    Console.WriteLine("3. View All Students");
    Console.WriteLine("4. Exit");
    Console.WriteLine();
}

void AddStudent()
{
    Console.WriteLine("=== Add Student ===");

    Student student = new Student();

    Console.Write("Enter student name: ");
    student.Name = Console.ReadLine();

    Console.Write("Enter student number: ");
    student.StudentNumber = Console.ReadLine();

    Console.Write("Enter course name: ");
    student.Course = Console.ReadLine();

    if (studentService.AddStudent(student, out string errorMessage))
    {
        Console.WriteLine("\n✅ Student added successfully!");
    }
    else
    {
        Console.WriteLine($"\n❌ Error: {errorMessage}");
    }

    Pause();
}

void AddGraduateStudent()
{
    Console.WriteLine("=== Add Graduate Student ===");

    GraduateStudent student = new GraduateStudent();

    Console.Write("Enter student name: ");
    student.Name = Console.ReadLine();

    Console.Write("Enter student number: ");
    student.StudentNumber = Console.ReadLine();

    Console.Write("Enter course name: ");
    student.Course = Console.ReadLine();

    Console.Write("Enter thesis title: ");
    student.ThesisTitle = Console.ReadLine();

    if (studentService.AddStudent(student, out string errorMessage))
    {
        Console.WriteLine("\n✅ Graduate Student added successfully!");
    }
    else
    {
        Console.WriteLine($"\n❌ Error: {errorMessage}");
    }

    Pause();
}

void ViewAllStudents()
{
    Console.WriteLine("=== All Students ===");

    List<Student> students = studentService.GetAllStudents();

    if (students.Count == 0)
    {
        Console.WriteLine("No students have been added yet.");
    }
    else
    {
        foreach (Student student in students)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine(student.GetDetails());
        }
    }

    Pause();
}

void Pause()
{
    Console.WriteLine();
    Console.WriteLine("Press any key to return to the menu...");
    Console.ReadKey();
}