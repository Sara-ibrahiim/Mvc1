using Demo.BLL.Interfaces;
using Demo.DAL.Context;
using Demo.DAL.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class EmployeeRepositary : GenericRepositiry<Employee> , IEmployeeRepositary
    {

        private readonly MvcAppDbContext _context;
        public EmployeeRepositary(MvcAppDbContext context) :base(context)
        {
            _context = context;

        }

        public IEnumerable<Employee> GetEmployeesByDepartmentName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Search(string name)
     =>_context.Employee.Where(emp => emp.Name.Trim().ToLower().Contains(name.Trim().ToLower()));


        //public int Add(Employee employee)
        //{
        //    _context.Employee.Add(employee);
        //    return _context.SaveChanges();
        //}

        //public int Delete(Employee employee)
        //{
        //    _context.Employee.Remove(employee);
        //    return _context.SaveChanges();
        //}

        //public Employee GetEmployeeId(int? id)
        //=> _context.Employee.FirstOrDefault(x => x.Id == id);

        //public IEnumerable<Employee> GetEmployees()

        //      => _context.Employee.ToList();


        //public int Update(Employee employee)
        //{
        //    _context.Employee.Update(employee);
        //    return _context.SaveChanges();
        //}
    }
}
