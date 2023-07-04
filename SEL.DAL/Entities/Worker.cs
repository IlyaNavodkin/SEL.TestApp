namespace SEL.DAL.Entities
{
    public class Worker
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }
        public int PersonnelNumber { get; set; }
    }
}