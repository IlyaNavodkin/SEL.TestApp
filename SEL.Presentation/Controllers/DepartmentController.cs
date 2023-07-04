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
            var departments = departmentRepository.GetAll().ToList();
            var departmentHierarchyViewModels = BuildDepartmentHierarchy(departments);
            
            return View(departmentHierarchyViewModels);
        }
        
        public List<DepartmentHierarchyViewModel> BuildDepartmentHierarchy(List<Department> departments)
        {
            var departmentDictionary = departments.ToDictionary(d => d.Id, d => new DepartmentHierarchyViewModel
            {
                Id = d.Id,
                Name = d.Name,
                Children = new List<DepartmentHierarchyViewModel>()
            });

            foreach (var department in departments)
            {
                if (department.ParentDepartmentId.HasValue)
                {
                    if (departmentDictionary.TryGetValue(department.ParentDepartmentId.Value, out var parentDepartment))
                    {
                        parentDepartment.Children.Add(departmentDictionary[department.Id]);
                    }
                }
            }

            var rootDepartments = departmentDictionary.Values.Where(d => !departments.Any(dep => dep.Id == d.Id && dep.ParentDepartmentId.HasValue)).ToList();

            return rootDepartments;
        }
    }
}