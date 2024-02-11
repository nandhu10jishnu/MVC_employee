using EmployeeManagement.Repository;
using EmployeeManagmenet.Interface;
using EmployeeManagmenet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagmenet.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employeeRepository;

        public EmployeeController(IEmployee employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            List<Employee> employees = _employeeRepository.Get();
            return View(employees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                _employeeRepository.Create(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(string id)
        {
            Employee employee = _employeeRepository.Get(id);
            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Employee employee)
        {
            try
            {
                _employeeRepository.Update(id, employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




        
        [HttpPost]
        public ActionResult TestDelete(string id)
        {
            try
            {
                // Retrieve the employee from the repository using the id
                Employee employeeToDelete = _employeeRepository.Get(id);

                if (employeeToDelete == null)
                {
                    // Handle the case where the employee is not found
                    return Json(new { success = false, message = "Item not found" });
                }

                // Perform the deletion
                _employeeRepository.Remove(id);

                return Json(new { success = true, message = "Item deleted successfully" });
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during the deletion process
                return Json(new { success = false, message = $"Error: {ex.Message}" });
            }
        }


    }
}
