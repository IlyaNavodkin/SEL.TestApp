using Microsoft.AspNetCore.Mvc;
using SEL.DAL.Entities;
using SEL.DAL.Repositories;
using SEL.DAL.Repositories.Interfaces;
using SEL.Presentation.ViewModels;

namespace SEL.Presentation.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var departments = departmentRepository.GetAll();
            return View(departments);
        }
    }
}