using SEL.BLL.Dtos;
using SEL.BLL.Models;

namespace SEL.BLL.Services.Interfaces;

public interface IDepartmentHierarchyService
{
    List<DepartmentHierarchy> BuildDepartmentHierarchy(List<DepartmentDto> departments);
}