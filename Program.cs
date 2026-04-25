string? studentName = null;
string? studentNumber = null;
string? course = null;
bool isRunning = true;

//while loop for when is running
while (isRunning)
{
    Console.Clear();
    Console.WriteLine("=== Student Manager ===");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. View Student");
    Console.WriteLine("3. Exit");

    //we ask the user to choose an option 
    Console.WriteLine("Choose an option: ");
    string? choice = Console.ReadLine();
    
    //switch statement for for the option selected
    switch (choice)
    {
        case "1":
        Console.Clear();

        Console.WriteLine("=== Add student === ");
        Console.Write("Enter student name: ");
        studentName = Console.ReadLine();

        Console.Write("Enter student number: ");
        studentNumber = Console.ReadLine();

        Console.Write("Enter course name: ");
        course = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Student added successfully");
        Console.WriteLine("Press any key to exit to the menu");
        Console.ReadKey();

        break;

        case "2":
        Console.Clear();
        Console.WriteLine("=== Student details ===");

        if (string.IsNullOrWhiteSpace(studentName))
            {
                Console.WriteLine("No student has been added yet");
            }
            else
            {
                Console.WriteLine($"Name: {studentName}");
                Console.WriteLine($"Student Number: {studentNumber}");
                Console.WriteLine($"Course: {course}");
            }
            Console.WriteLine();

            Console.WriteLine("Press any key to retrn to the main menu");
            Console.ReadKey();

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