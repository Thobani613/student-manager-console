Console.WriteLine("=== STUDENT MANAGER APP ===");
Console.WriteLine();

//get student name
Console.Write("Enter student name: "); 
string? studentName = Console.ReadLine();

//get student number which be stored as a string
Console.WriteLine("Enter student number: ");
string? studentNumber = Console.ReadLine();

//get Ccourse
Console.WriteLine("Enter course name: ");
string? course = Console.ReadLine();

//code to display the information entered by the user
Console.WriteLine();
Console.WriteLine("=== Student Details ===");
Console.WriteLine($"Name: {studentName}");
Console.WriteLine($"Student Number: {studentNumber}");
Console.WriteLine($"Course: {course}");
