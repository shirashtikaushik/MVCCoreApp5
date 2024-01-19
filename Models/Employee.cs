namespace MVCCoreApp5.Models
{
    public class Employee
    {
       
        public int Id { get; set; }
        public  string Name { get; set; }
        public DateTime DateofJoining { get; set; }
        public int Salary { get; set; }

        public required string Dept { get; set; }
    }
}

