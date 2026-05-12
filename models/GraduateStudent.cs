namespace StudentManagerConsole.Models
{
    public class GraduateStudent : Student
    {
        public string? ThesisTitle { get; set; }

        public override string GetDetails()
        {
            return $"[Graduate]  Name: {Name} | Number: {StudentNumber} | Course: {Course} | Thesis: {ThesisTitle}";
        }
    }
}