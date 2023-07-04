using SEL.DAL.Entities;

namespace SEL.DAL.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll();
        Department GetById(int id);
        void Delete(int id);
    }
}