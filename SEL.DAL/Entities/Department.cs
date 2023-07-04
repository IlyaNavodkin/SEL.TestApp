namespace SEL.DAL.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public int? ParentDepartmentId { get; set; }
        public string Name { get; set; }
    }
}