using ERPSystem.Data;
using ERPSystem.Models.HR;
using Microsoft.EntityFrameworkCore;

namespace ERPSystem.Services
{
    public class HRService
    {
        private readonly ApplicationDbContext _context;
        public HRService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }
        // Example business logic: Payroll calculation with a 2% raise per year of service.
        public decimal CalculatePayroll(Employee employee, decimal baseSalary)
        {
            var adjustment = baseSalary * (employee.YearsOfService * 0.02m);
            return baseSalary + adjustment;
        }
    }
}
