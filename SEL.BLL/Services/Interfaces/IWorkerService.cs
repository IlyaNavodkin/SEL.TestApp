using SEL.BLL.Dtos;
using SEL.DAL.Entities;

namespace SEL.BLL.Services.Interfaces;

public interface IWorkerService
{
    IEnumerable<WorkerDto> GetAll();
    WorkerDto GetById(int id);
    void Delete(int id);
    void Update(WorkerDto dto);
}