using Demo.DAL.Entities;
using Demo.PLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepositories _departmentRepositories;

        public DepartmentController(IDepartmentRepositories departmentRepositories)
        {
            _departmentRepositories = departmentRepositories;
        }
        public IActionResult Index()
        {
            var departments = _departmentRepositories.GetAll();
            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                int result = _departmentRepositories.Add(department);
                if(result > 0)
                {
                    TempData["Message"] = "Department is Created";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public IActionResult Details(int? Id, string viewName = "Details")
        {
            if (Id is null)
                return BadRequest();
            var department = _departmentRepositories.GetByID(Id.Value);
            if (department is null)
                return NotFound();
            return View(viewName, department);
        }
        public IActionResult Edit(int? Id)
        {
        //    if (Id is null)
        //        return BadRequest();
        //    var department = _departmentRepositories.GetById(Id.Value);
        //    if(department is null)
        //        return NotFound();
        //    return View(department);
            return Details(Id, "Edit");
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
                try
                {
                    _departmentRepositories.Update(department);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            return View(department);
        }


        public IActionResult Delete(int? Id)
        {
            return Details(Id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete(Department department)
        {
            if(ModelState.IsValid)
            {
                _departmentRepositories.Delete(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
    }
}
