namespace SEL.Presentation.ViewModels
{
    public class WorkerDepartmentViewModel
    {
        public WorkerViewModel Worker { get; set; }
        public IEnumerable<DepartmentViewModel> Departments { get; set; }
        public DepartmentViewModel CurrentDepartment { get; set; }
    }
}