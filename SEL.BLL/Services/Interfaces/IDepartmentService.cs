using SEL.BLL.Dtos;
using SEL.DAL.Entities;

namespace SEL.BLL.Services.Interfaces;

public interface IDepartmentService
{
    IEnumerable<DepartmentDto> GetAll();
    DepartmentDto GetById(int id);
    void Delete(int id);
}