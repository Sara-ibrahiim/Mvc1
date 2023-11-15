using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Enitities;
using Demo.PL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        //private readonly IDepartmentRepositary : Controller

      //   private readonly IDepartmentRepositary _departmentRepositary;


        private readonly ILogger<DepartmentController> _logger;
        private readonly IUntiOfWork _untiOfWork;
        private readonly IMapper _mapper;
        public DepartmentController(
            
           //IDepartmentRepositary departmentRepositary,

            ILogger<DepartmentController> logger,
            IUntiOfWork untiOfWork,
            IMapper mapper


            )
        {
           // _departmentRepositary = departmentRepositary;
            //this.logger = logger; 
            _logger = logger;
            _untiOfWork = untiOfWork;
            _mapper = mapper;
        } 
        [HttpGet]
        //, ActionName("")
        public IActionResult Index()
        {
            IEnumerable<Department> department;
            IEnumerable<DepartmentViewModel> mappedDepartment;

            department = _untiOfWork.DepartmentRepositary.GetAll();

            mappedDepartment = _mapper.Map<IEnumerable<DepartmentViewModel>>(department);
            //ViewData["Message"] = "Hello from view Data";
            //ViewBag.MessageBag = "Hello from view Bag";
            return View(mappedDepartment); 
        }

        [HttpGet]

        public IActionResult Create()
        {
            //_departmentRepositary.Add(department);
        return View();
        }


        [HttpPost]

        public IActionResult Create(DepartmentViewModel departmentvm)
        {
            if(ModelState.IsValid)
            {
                var department = _mapper.Map<Department>(departmentvm);
                _untiOfWork.DepartmentRepositary.Add(department);
                TempData["Message"] = "Department Created Successfully!!";
            return RedirectToAction("Index");
            }

            return View(departmentvm);
        }
        //public IActionResult Details(int? id)

        //{
        //    if (id is null)
        //        return View("/Home/Error");
        //    var department = _departmentRepositary.GetById(id);
        //    if (department is null)
        //        return View("Home/Error");
        //    return View(department);

        //}

        public IActionResult Details(int? id)
        {
            try
            {

                if (id is null)
                    return NotFound();
                var department = _untiOfWork.DepartmentRepositary.GetById(id);
                department.Name = "Hr 03";
                if (department is null)
                    return NotFound();
                var mappedDepartment = _mapper.Map<DepartmentViewModel>(department);
                return View(mappedDepartment);
            }

            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Error" ,"Home");
            }
      



        }




     [HttpGet]

        public IActionResult Update (int? id)
        {
            if (id is null)
                return NotFound();
            var department =  _untiOfWork.DepartmentRepositary.GetById(id);

            if (department is null)
                return NotFound();
            var mappedDepartment = _mapper.Map<DepartmentViewModel>(department);
            return View(mappedDepartment);
        }

        [HttpPost]
        public IActionResult Update(int id, DepartmentViewModel departmentvm)
        {

            if (id != departmentvm.Id)
                return NotFound();
            try
            {
                if (ModelState.IsValid)
                {
                    var department = _mapper.Map<Department>(departmentvm);
                    _untiOfWork.DepartmentRepositary.Update(department);
                    return RedirectToAction("Index");
                }
                return View(departmentvm);
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
            // var mappedDepartment = _mapper.Map<DepartmentViewModel>(department);
            
           
            var department = _untiOfWork.DepartmentRepositary.GetById(id);
           // return View(mappedDepartment)
            if (department is null)
                return NotFound();         
            _untiOfWork.DepartmentRepositary.Delete(department);
            return RedirectToAction("Index");
            var mappedDepartment = _mapper.Map<DepartmentViewModel>(department);
            return View(mappedDepartment);
        }


    }
}

