using SEL.DAL.Entities;

namespace SEL.DAL.Repositories.Interfaces
{
    public interface IWorkerRepository
    {
        IEnumerable<Worker> GetAll();
        Worker GetById(int id);
        void Delete(int id);
        void Update(Worker entity);
    }
}