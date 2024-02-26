using EmployeeManagement_EFC.Data;
using EmployeeManagement_EFC.Models;
using EmployeeManagement_EFC.Models.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement_EFC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmpDbContext empDbContext;

        public EmployeesController(EmpDbContext empDbContext)
        {
            this.empDbContext = empDbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Add(AddEmployeesViewModel addEmployeesViewRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeesViewRequest.Name,
                Salary = addEmployeesViewRequest.Salary,
                DateOfBirth = addEmployeesViewRequest.DateOfBirth,
                Department = addEmployeesViewRequest.Department,
                Email = addEmployeesViewRequest.Email
            };
           await empDbContext.Employees.AddAsync(employee);
          await  empDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var employee= await empDbContext.Employees.ToListAsync();
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid Id)
        {

            var employee= await empDbContext.Employees.SingleOrDefaultAsync(x => x.Id == Id);
            if (employee != null)
            {
                var employees = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Salary = employee.Salary,
                    DateOfBirth = employee.DateOfBirth,
                    Department = employee.Department,
                    Email = employee.Email
                };

                return View(employees);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Details(UpdateEmployeeViewModel model)
        {
            var employee= empDbContext.Employees.SingleOrDefault(x => x.Id == model.Id);
            if(employee != null)
            {
                employee.Name = model.Name;
                employee.Salary = model.Salary;
                employee.Email = model.Email;
                employee.DateOfBirth = model.DateOfBirth;
                employee.Department = model.Department;
              

                empDbContext.SaveChanges();
               return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]

        public IActionResult Delete(UpdateEmployeeViewModel model)
        {

            var employee = empDbContext.Employees.SingleOrDefault(x => x.Id == model.Id);
            empDbContext.Employees.Remove(employee);
            empDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
