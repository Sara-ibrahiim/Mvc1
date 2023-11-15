using Demo.BLL.Interfaces;
using Demo.DAL.Context;
using Demo.DAL.Enitities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class DepartmentRepositary : GenericRepositiry<Department> , IDepartmentRepositary
    {

        private readonly MvcAppDbContext _context;
        public DepartmentRepositary(MvcAppDbContext context) : base(context)
        {
            _context = context;
        
        }
     //   public int Add(Department department)
     //   {
     //       _context.Department.Add(department);
     //       return _context.SaveChanges();
     //   }

     //   public int Delete(Department department)
     //   {
     //       _context.Department.Remove(department);
     //       return _context.SaveChanges();
     //   }

     //   public Department GetDepartmentId(int? id)
     //   => _context.Department.FirstOrDefault(x => x.Id == id);

     //   public IEnumerable<Department> GetDepartments()
     //=> _context.Department.ToList();

     //   public int Update(Department department)
     //   {
     //       _context.Department.Update(department);
     //       return _context.SaveChanges();
     //   }
    }
}
