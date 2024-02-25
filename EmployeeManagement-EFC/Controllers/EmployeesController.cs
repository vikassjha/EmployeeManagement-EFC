using EmployeeManagement_EFC.Data;
using EmployeeManagement_EFC.Models;
using EmployeeManagement_EFC.Models.Domains;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Add(AddEmployeesViewModel addEmployeesViewRequest)
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
            empDbContext.Employees.Add(employee);
            empDbContext.SaveChanges();
            return RedirectToAction("Add");
        }
    }
}
