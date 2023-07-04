namespace SEL.BLL.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public int? ParentDepartmentId { get; set; }
        public string Name { get; set; }
    }
}