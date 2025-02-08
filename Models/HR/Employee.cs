using System.ComponentModel.DataAnnotations;

namespace ERPSystem.Models.HR
{
    public class Employee
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        public string Position { get; set; }
        public DateTime HireDate { get; set; }

        // Business logic: Years of service calculation
        public int YearsOfService => DateTime.Now.Year - HireDate.Year;
    }
}
