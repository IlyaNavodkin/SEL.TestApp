using SEL.BLL.Dtos;
using SEL.BLL.Services.Interfaces;
using SEL.DAL.Entities;
using SEL.DAL.Repositories.Interfaces;

namespace SEL.BLL.Services;

public class WorkerService : IWorkerService
{
    private readonly IWorkerRepository _workerRepository;

    public WorkerService(IWorkerRepository workerRepository)
    {
        _workerRepository = workerRepository;
    }

    public IEnumerable<WorkerDto> GetAll()
    {
        var workers = _workerRepository.GetAll();
        var dtos = workers.Select(worker => ConvertToDTO(worker));
        
        return dtos;
    }

    public WorkerDto GetById(int id)
    {
        var entity = _workerRepository.GetById(id);
        return ConvertToDTO(entity);
    }

    public void Delete(int id)
    {
        _workerRepository.Delete(id);
    }

    public void Update(WorkerDto dto)
    {
        var entity = ConvertToEntity(dto);
        _workerRepository.Update(entity);
    }

    private WorkerDto ConvertToDTO(Worker entity)
    {
        return new WorkerDto
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            MidName = entity.MidName,
            DepartmentId = entity.DepartmentId,
            PersonnelNumber = entity.PersonnelNumber,
        };
    }

    private Worker ConvertToEntity(WorkerDto dto)
    {
        return new Worker
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            MidName = dto.MidName,
            DepartmentId = dto.DepartmentId,
            PersonnelNumber = dto.PersonnelNumber,
        };
    }
}