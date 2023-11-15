using Demo.BLL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class UntiOfWork : IUntiOfWork
    {
        public IEmployeeRepositary EmployeeRepositary { get; set; }
        public IDepartmentRepositary DepartmentRepositary { get; set; }

        public UntiOfWork(IEmployeeRepositary employeeRepositary, IDepartmentRepositary departmentRepositary)
        {
            EmployeeRepositary = employeeRepositary;
            DepartmentRepositary = departmentRepositary;

        }
    }
}
