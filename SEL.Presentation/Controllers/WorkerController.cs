using Microsoft.AspNetCore.Mvc;
using SEL.DAL.Entities;
using SEL.DAL.Repositories.Interfaces;
using SEL.Presentation.ViewModels;

namespace SEL.Presentation.Controllers
{
    public class WorkersController : Controller
    {
        private IWorkerRepository _workerRepository;
        private IDepartmentRepository _departmentRepository;

        public WorkersController(IWorkerRepository workerRepository, IDepartmentRepository departmentRepository)
        {
            _workerRepository = workerRepository;
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Worker> workers = _workerRepository.GetAll();

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
            _workerRepository.Delete(id);
            
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Edit(int userId)
        {
            var worker = _workerRepository.GetById(userId);
            var workerViewModel = Mapper.ConvertToWorkerViewModel(worker);
            
            var departments = _departmentRepository.GetAll();
            var departmentViewModels = departments.Select(d => Mapper.ConvertToDepartmentViewModel(d));
            
            var department = _departmentRepository.GetById(workerViewModel.DepartmentId);
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
            var worker = new Worker
            {
                Id = workerDepartmentViewModel.Worker.Id,
                FirstName = workerDepartmentViewModel.Worker.FirstName,
                LastName = workerDepartmentViewModel.Worker.LastName,
                MidName = workerDepartmentViewModel.Worker.MidName,
                DepartmentId = workerDepartmentViewModel.Worker.DepartmentId,
                PersonnelNumber = workerDepartmentViewModel.Worker.PersonnelNumber,
            };
            
            _workerRepository.Update(worker);
            
            return RedirectToAction("Index");
        }
    }
}