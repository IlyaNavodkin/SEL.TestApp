namespace SEL.Presentation.ViewModels;

public class DepartmentHierarchyViewModel
{
    public int Id { get; set; }
    public DepartmentHierarchyViewModel ParentDepartment { get; set; }
    public string Name { get; set; }
    public List<DepartmentHierarchyViewModel> Children { get; set; } = new List<DepartmentHierarchyViewModel>();
}