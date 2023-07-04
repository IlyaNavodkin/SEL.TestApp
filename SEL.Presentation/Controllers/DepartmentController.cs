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
            var departmentHierarchyViewModels = CreateDepartmentHierarchy(departments);
            
            return View(departmentHierarchyViewModels);
        }
        
        public List<DepartmentHierarchyViewModel> CreateDepartmentHierarchy(List<Department> departments)
        {
            var departmentMap = new Dictionary<int, DepartmentHierarchyViewModel>();

            foreach (var department in departments)
            {
                var departmentHierarchy = new DepartmentHierarchyViewModel
                {
                    Id = department.Id,
                    Name = department.Name
                };

                departmentMap[department.Id] = departmentHierarchy;
            }

            foreach (var department in departments)
            {
                if (department.ParentDepartmentId.HasValue)
                {
                    var parentDepartment = departmentMap[department.ParentDepartmentId.Value];
                    var childDepartment = departmentMap[department.Id];
                    parentDepartment.Children.Add(childDepartment);
                }
            }

            var rootDepartments = departmentMap.Values
                .Where(d => !departmentMap.ContainsKey(d.ParentDepartment?.Id ?? 0))
                .ToList();

            return rootDepartments;
        }
    }
}