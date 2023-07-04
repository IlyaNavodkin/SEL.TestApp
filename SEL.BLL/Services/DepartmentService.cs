using SEL.BLL.Dtos;
using SEL.BLL.Services.Interfaces;
using SEL.DAL.Entities;
using SEL.DAL.Repositories.Interfaces;

namespace SEL.BLL.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public IEnumerable<DepartmentDto> GetAll()
    {
        var entities = _departmentRepository.GetAll();
        var dtos = entities.Select(e => ConvertToDTO(e));

        return dtos;
    }

    public DepartmentDto GetById(int id)
    {
        var entity = _departmentRepository.GetById(id);
        return ConvertToDTO(entity);
    }

    public void Delete(int id)
    {
        _departmentRepository.Delete(id);
    }
    
    private DepartmentDto ConvertToDTO(Department entity)
    {
        return new DepartmentDto
        {
            Id = entity.Id,
            Name = entity.Name,
            ParentDepartmentId = entity.ParentDepartmentId,
        };
    }
}