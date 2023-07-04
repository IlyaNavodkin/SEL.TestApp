using Microsoft.AspNetCore.Mvc;
using SEL.BLL.Dtos;
using SEL.BLL.Services.Interfaces;
using SEL.DAL.Entities;
using SEL.DAL.Repositories.Interfaces;
using SEL.Presentation.Helpers;
using SEL.Presentation.ViewModels;

namespace SEL.Presentation.Controllers
{
    public class WorkersController : Controller
    {
        private IWorkerService _workerService;
        private IDepartmentService _departmentService;

        public WorkersController(IWorkerService workerService, IDepartmentService departmentService)
        {
            _workerService = workerService;
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var workers = _workerService.GetAll();

            List<WorkerViewModel> workerViewModels = workers.Select(worker => new WorkerViewModel
            {
                Id = worker.Id,
                FirstName = worker.FirstName,
                MidName = worker.MidName,
                LastName = worker.LastName,
                PersonnelNumber = worker.PersonnelNumber
            }).ToList();

            return View(workerViewModels);
        }
        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _workerService.Delete(id);
            
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Edit(int userId)
        {
            var worker = _workerService.GetById(userId);
            var workerViewModel = Mapper.ConvertToWorkerViewModel(worker);
            
            var departments = _departmentService.GetAll();
            var departmentViewModels = departments
                .Select(d => Mapper.ConvertToDepartmentViewModel(d));
            
            var department = _departmentService.GetById(workerViewModel.DepartmentId);
            var departmentViewModel = Mapper.ConvertToDepartmentViewModel(department);
            
            var viewModel = new WorkerDepartmentViewModel
            {
                Departments = departmentViewModels,
                CurrentDepartment = departmentViewModel,
                Worker = workerViewModel
            };
            
            return View(viewModel);
        }
        
        [HttpPost]
        public IActionResult Edit(WorkerDepartmentViewModel workerDepartmentViewModel)
        {
            var worker = new WorkerDto
            {
                Id = workerDepartmentViewModel.Worker.Id,
                FirstName = workerDepartmentViewModel.Worker.FirstName,
                LastName = workerDepartmentViewModel.Worker.LastName,
                MidName = workerDepartmentViewModel.Worker.MidName,
                DepartmentId = workerDepartmentViewModel.Worker.DepartmentId,
                PersonnelNumber = workerDepartmentViewModel.Worker.PersonnelNumber,
            };
            
            _workerService.Update(worker);
            
            return RedirectToAction("Index");
        }
    }
}