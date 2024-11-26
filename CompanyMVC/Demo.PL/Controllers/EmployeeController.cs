using Demo.DAL.Entities;
using Demo.PLL.Interfaces;
using Demo.PLL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            var employee = _employeeRepository.GetAll();
            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                int result = _employeeRepository.Add(employee);
                if (result > 0)
                {
                    TempData["Message"] = "Employee is Created";
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Details(int? Id, string ViewName)
        {
            if (Id is null)
                return BadRequest();
            var employee = _employeeRepository.GetByID(Id.Value);
            if (employee is null)
                return NotFound();
            return View(ViewName, employee);
        }

        public IActionResult Edit(int? Id)
        {
            return Details(Id, "Edit");
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Update(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Delete(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }


    }
}
