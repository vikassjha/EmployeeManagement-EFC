using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement_EFC.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}
