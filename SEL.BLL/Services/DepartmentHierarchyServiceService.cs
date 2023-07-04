using SEL.BLL.Dtos;
using SEL.BLL.Models;
using SEL.BLL.Services.Interfaces;

namespace SEL.BLL.Services;

public class DepartmentHierarchyService : IDepartmentHierarchyService
{
    private readonly IWorkerService _workerService;

    public DepartmentHierarchyService(IWorkerService workerService)
    {
        _workerService = workerService;
    }

    public List<DepartmentHierarchy> BuildDepartmentHierarchy(List<DepartmentDto> departments)
    {
        var allWorkers = _workerService.GetAll();

        var departmentDictionary = departments
            .ToDictionary(d => d.Id, d => new DepartmentHierarchy
            {
                Id = d.Id,
                Name = d.Name,
                Workers = allWorkers.Where(w => w.DepartmentId == d.Id).ToList(),
                Children = new List<DepartmentHierarchy>()
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

        var rootDepartments = departmentDictionary.Values
            .Where(d => !departments.Any(dep => dep.Id == d.Id && dep.ParentDepartmentId.HasValue))
            .ToList();

        return rootDepartments;
    }
}