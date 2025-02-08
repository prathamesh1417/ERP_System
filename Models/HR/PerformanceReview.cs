using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ERPSystem.Models.HR
{
    public class PerformanceReview
    {
        public int Id { get; set; }

        [Required, StringLength(500)]
        public string Feedback { get; set; }
        public DateTime ReviewDate { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
