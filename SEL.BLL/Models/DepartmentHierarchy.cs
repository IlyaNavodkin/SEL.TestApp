namespace SEL.BLL.Models;

public class DepartmentHierarchy
{
    public int Id { get; set; }
    public DepartmentHierarchy ParentDepartment { get; set; }
    public string Name { get; set; }
    public List<DepartmentHierarchy> Children { get; set; } = new List<DepartmentHierarchy>();
}