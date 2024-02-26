namespace EMS.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Departments { get; set; }

    }
}
