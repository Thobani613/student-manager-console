namespace StudentManagerConsole.Models
{
    public abstract class Person
    {
        public string? Name { get; set; }

        public abstract string GetDetails();
    }
}