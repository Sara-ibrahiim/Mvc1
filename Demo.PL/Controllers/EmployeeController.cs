using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Enitities;
using Demo.PL.Helper;
using Demo.PL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Logging;

namespace Demo.PL.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly IUntiOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUntiOfWork untiOfWork , IMapper mapper , ILogger<DepartmentController> logger) { 

            _unitOfWork = untiOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index(string SearchValue="")
        {
            IEnumerable<Employee> employees;
            IEnumerable<EmployeeViewModel> mappedEmployees;

            if(string.IsNullOrEmpty(SearchValue))
            {
                employees = _unitOfWork.EmployeeRepositary.GetAll();
                mappedEmployees = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
            }
            else
            {
                employees = _unitOfWork.EmployeeRepositary.Search(SearchValue);
                mappedEmployees = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
            }
            
            return View(mappedEmployees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = _unitOfWork.DepartmentRepositary.GetAll();
            return View(new EmployeeViewModel());
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeVM)
        {


          //  ModelState["Department"].ValidationState = ModelValidationState.Valid;
            if (ModelState.IsValid)
            {
                try {

                    //Employee employee = new Employee
                    //{
                    //    Name = employeeVM.Name,
                    //    Address = employeeVM.Address,
                    //    DepartmentId = employeeVM.DepartmentId,
                    //    Email = employeeVM.Email,
                    //    HireDate = employeeVM.HireDate,
                    //    IsActive = employeeVM.IsActive,
                    //    Salary = employeeVM.Salary
                    //};

                 var employee = _mapper.Map<Employee>(employeeVM);
                  employee.ImageUrl = DocumentSettings.UploadFile(employeeVM.Image, "Images");
                   _unitOfWork.EmployeeRepositary.Add(employee);
                return RedirectToAction (nameof(Index));
                }
                catch (Exception ex)
                { 
                    throw new Exception(ex.Message);
                }
            }
            ViewBag.Departments = _unitOfWork.DepartmentRepositary.GetAll();
            return View(employeeVM);
        }

        public IActionResult Details(int? id)
        {
            try
            {


                if (id is null)
                    return NotFound();
                var Employee = _unitOfWork.EmployeeRepositary.GetById(id);
              
                if (Employee is null)
                    return NotFound();
                var mappedEmployees = _mapper.Map<EmployeeViewModel>(Employee);
                return View(mappedEmployees);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Error", "Home");
            }




        }


        [HttpGet]

        public IActionResult Update(int? id)
        {

            if (id is null)
                return NotFound();
            var employee = _unitOfWork.EmployeeRepositary.GetById(id);

            if (employee is null)
                return NotFound();
           
            var mappedEmployees = _mapper.Map<EmployeeViewModel>(employee);
            return View(mappedEmployees);

           
        }

        [HttpPost]
        public IActionResult Update(int id, EmployeeViewModel employeeVM)
        {

            if (id != employeeVM.Id)
                return NotFound();
            try
            {
                if (ModelState.IsValid)
                {
                   var employee = _mapper.Map<Employee>(employeeVM);
                    _unitOfWork.EmployeeRepositary.Update(employee);
                    return RedirectToAction("Index");
                }
                return View(employeeVM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
                return NotFound();
            var Employee = _unitOfWork.EmployeeRepositary.GetById(id);
            if (Employee is null)
                return NotFound();
            _unitOfWork.EmployeeRepositary.Delete(Employee);
            return RedirectToAction("Index");
            var mappedEmployees = _mapper.Map<EmployeeViewModel>(Employee);
            return View(mappedEmployees);
        }
    }
}
