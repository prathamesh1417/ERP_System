using System.Linq;
using ERPSystem.Data;
using System.Threading.Tasks;
using ERPSystem.Services;
using Microsoft.AspNetCore.Mvc;
using ERPSystem.Models.HR;
using Microsoft.EntityFrameworkCore;  // Ensure that the Employee model is within this namespace

namespace ERPSystem.Controllers
{
    public class HRController : Controller
    {
        private readonly HRService _hrService;
        private readonly ApplicationDbContext _context;

        public HRController(HRService hrService,ApplicationDbContext context)
        {
            _hrService = hrService;
            _context = context;

        }

        // GET: HR
        public async Task<IActionResult> Index()
        {
            var employees = await _hrService.GetEmployeesAsync();
            return View(employees);
        }

        // GET: HR/Payroll/{id}?baseSalary=5000
        public async Task<IActionResult> Payroll(int id, decimal baseSalary)
        {
            var employees = await _hrService.GetEmployeesAsync();
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            var calculatedSalary = _hrService.CalculatePayroll(employee, baseSalary);
            ViewBag.CalculatedSalary = calculatedSalary;

            return View(employee);
        }

              public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
                return NotFound();
            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Employees.Any(e => e.Id == employee.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
                return NotFound();
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}


