using SEL.BLL.Dtos;
using SEL.DAL.Entities;
using SEL.Presentation.ViewModels;

namespace SEL.Presentation.Helpers
{
    public static class Mapper
    {
        public static Worker ConvertToWorker(WorkerViewModel viewModel)
        {
            return new Worker
            {
                Id = viewModel.Id,
                DepartmentId = viewModel.DepartmentId,
                FirstName = viewModel.FirstName,
                MidName = viewModel.MidName,
                LastName = viewModel.LastName,
                PersonnelNumber = viewModel.PersonnelNumber
            };
        }

        public static Department ConvertToDepartment(DepartmentViewModel viewModel)
        {
            return new Department
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                ParentDepartmentId = viewModel.ParentDepartmentId
            };
        }
        
        public static WorkerViewModel ConvertToWorkerViewModel(WorkerDto worker)
        {
            return new WorkerViewModel
            {
                Id = worker.Id,
                DepartmentId = worker.DepartmentId,
                FirstName = worker.FirstName,
                MidName = worker.MidName,
                LastName = worker.LastName,
                PersonnelNumber = worker.PersonnelNumber
            };
        }

        public static DepartmentViewModel ConvertToDepartmentViewModel(DepartmentDto department)
        {
            return new DepartmentViewModel
            {
                Id = department.Id,
                Name = department.Name,
                ParentDepartmentId = department.ParentDepartmentId
            };
        }
    }
}