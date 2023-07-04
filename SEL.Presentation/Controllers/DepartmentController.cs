using Microsoft.AspNetCore.Mvc;
using SEL.BLL.Dtos;
using SEL.BLL.Models;
using SEL.BLL.Services.Interfaces;
using SEL.DAL.Entities;
using SEL.DAL.Repositories;
using SEL.DAL.Repositories.Interfaces;
using SEL.Presentation.ViewModels;

namespace SEL.Presentation.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IDepartmentHierarchyService _departmentHierarchyService;

        public DepartmentController(IDepartmentService departmentService, 
            IDepartmentHierarchyService departmentHierarchyService)
        {
            _departmentService = departmentService;
            _departmentHierarchyService = departmentHierarchyService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAll().ToList();
            var departmentHierarchyViewModels = _departmentHierarchyService
                .BuildDepartmentHierarchy(departments);
            
            return View(departmentHierarchyViewModels);
        }
        
    }
}