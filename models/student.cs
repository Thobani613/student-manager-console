public class Student : Person
{
    public string? StudentNumber { get; set; }
    public string? Course { get; set; }

    public override string GetDetails()
    {
        return $"[Student]  Name: {Name} | Number: {StudentNumber} | Course: {Course}";
    }
}