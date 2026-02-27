using EmployeeManagment.Models;
using EmployeeManagment.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NuGet.Protocol.Core.Types;



namespace EmployeeManagment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public IWebHostEnvironment WebHost { get; }

        public HomeController(IEmployeeRepository employeeRepository, IWebHostEnvironment webHost)
        {
            this.employeeRepository = employeeRepository;
            WebHost = webHost;
        }






        public IActionResult Index()
        {
            var model = employeeRepository.GetAllEmployee();
            return View(model);
        }






        public IActionResult Details(int? id)
        {
            //throw new Exception("Error in Details View");

            Employee employee = employeeRepository.GetEmployee(id.Value);
            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);

            }
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = employee,
                PageTitle = "Employee Details"

            };


            return View(homeDetailsViewModel);
        }








        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(WebHost.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Employee newEmployee = new Employee()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    Photopath = uniqueFileName

                };
                employeeRepository.Add(newEmployee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();
        }


        public IActionResult Edit()
        {

            return View();
        }

        
        public IActionResult Delete(int Id)
        {
            employeeRepository.Delete(Id);

            return RedirectToAction("Index");
        }
    }
}