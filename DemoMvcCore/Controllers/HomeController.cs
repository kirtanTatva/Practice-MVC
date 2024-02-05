using DemoMvcCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace DemoMvcCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        List<EmployeeModel> listOfEmps = new List<EmployeeModel>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;            

            // static dummy data
            listOfEmps.Add(new EmployeeModel { EmpId = 1, FirstName = "Shubham", EmpRole = "Devloper" });
            listOfEmps.Add(new EmployeeModel { EmpId = 2, FirstName = "Meet", EmpRole = "QA" });
            listOfEmps.Add(new EmployeeModel { EmpId = 3, FirstName = "Jay", EmpRole = "HR" });
            listOfEmps.Add(new EmployeeModel { EmpId = 4, FirstName = "Bhavesh", EmpRole = "QA" });
            listOfEmps.Add(new EmployeeModel { EmpId = 5, FirstName = "Ravi", EmpRole = "Devloper" });
            listOfEmps.Add(new EmployeeModel { EmpId = 6, FirstName = "Smit", EmpRole = "Devloper" });
            listOfEmps.Add(new EmployeeModel { EmpId = 7, FirstName = "Akash", EmpRole = "PM" });
            listOfEmps.Add(new EmployeeModel { EmpId = 8, FirstName = "Dharm", EmpRole = "TL" });
            listOfEmps.Add(new EmployeeModel { EmpId = 9, FirstName = "Kartik", EmpRole = "Devloper" });
            listOfEmps.Add(new EmployeeModel { EmpId = 10, FirstName = "Riya", EmpRole = "Devloper" });
            listOfEmps.Add(new EmployeeModel { EmpId = 11, FirstName = "Mahesh", EmpRole = "Network" });
            listOfEmps.Add(new EmployeeModel { EmpId = 12, FirstName = "Jayesh", EmpRole = "Network" });
            listOfEmps.Add(new EmployeeModel { EmpId = 13, FirstName = "Ramesh", EmpRole = "Network" });
            listOfEmps.Add(new EmployeeModel { EmpId = 14, FirstName = "Shivam", EmpRole = "Network" });
            listOfEmps.Add(new EmployeeModel { EmpId = 15, FirstName = "Krishna", EmpRole = "Devloper" });            
        }

        [Route("", Name = "Default")]
        [Route("home/employee-list", Name = "EmployeeList")]
        public IActionResult Index()
        {
            // after create adding record temporary
            if (TempData != null && TempData["FirstName"] != null && TempData["EmpRole"] != null)
            {
                var empId = listOfEmps.Max(m => m.EmpId) + 1;
                listOfEmps.Add(new EmployeeModel { EmpId = empId, FirstName = TempData["FirstName"].ToString(), EmpRole = TempData["EmpRole"].ToString() });
            }

            return View(listOfEmps);
        }

        [Route("home/employee-list-json", Name = "EmployeeListJson")]
        public IActionResult EmployeeListJson()
        {
            return Json(new { data = listOfEmps });
        }

        [Route("home/create-employee", Name = "CreateEmployee")]
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        [Route("home/create-employee", Name = "CreateEmployeePost")]
        public IActionResult CreateEmployee(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {                
                TempData["FirstName"] = model.FirstName;
                TempData["EmpRole"] = model.EmpRole;

                return RedirectToRoute("EmployeeList");
            }

            ViewData["ModelState"] = "Model state invalid.";
            return View(model);
        }        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}