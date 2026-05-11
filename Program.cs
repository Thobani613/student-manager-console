List<Student> students = new List<Student>();
bool isRunning = true;

//while loop for when is running
while (isRunning)
{
    ShowMenu();

    Console.Write("Choose an option: ");
    string? choice = Console.ReadLine();
    
    //switch statement for for the option selected
    switch (choice)
    {
        case "1":
        Console.Clear();
        AddStudent();
        break;

        case "2":
        Console.Clear();
        ViewAllStudents();
        break;

        case "3":
        isRunning = false;
        break;

        default:
        Console.WriteLine("Invalid option. Please choose 1, 2, or 3.");
        Console.WriteLine("Press any key to try again...");
        Console.ReadKey();
        break;
    }
}

void ShowMenu()
{
    Console.WriteLine("=== Student Manager Console App ===");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. View  All Student");
    Console.WriteLine("3. Exit");
    Console.WriteLine();
}

void AddStudent()
{
    Console.Clear();

    Console.WriteLine("=== Add Student ===");

    Student student = new Student();

    Console.Write("Enter student name: ");
    student.Name = Console.ReadLine();

    Console.Write("Enter student number: ");
    student.studentNumber = Console.ReadLine();

    Console.Write("Enter course name: ");
    student.Course = Console.ReadLine();

    students.Add(student);

    Console.WriteLine();
    Console.WriteLine("Student added successfully!");

    Pause();
}

void ViewAllStudents()
{
    Console.Clear();

    Console.WriteLine("=== All Students ===");

    if (students.Count == 0)
    {
        Console.WriteLine("No student has been added yet.");
    }
    else
    {
       foreach(Student student in students)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine($"Name: {student.Name}");
            Console.WriteLine($"Student Number:{student.studentNumber}");
            Console.WriteLine($"Course: {student.Course}");
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