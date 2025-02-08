using System.ComponentModel.DataAnnotations.Schema;

namespace ERPSystem.Models.HR
{
    public class Payroll
    {
        public int Id { get; set; }
        public decimal Salary { get; set; }
        public DateTime PaymentDate { get; set; }

        // Foreign key to Employee
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
