namespace SEL.Presentation.ViewModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentDepartmentId { get; set; }
        public List<DepartmentViewModel> ChildDepartments { get; set; }
    }
}