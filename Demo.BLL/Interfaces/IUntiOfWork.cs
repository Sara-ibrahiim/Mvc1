using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IUntiOfWork
    {
        public IEmployeeRepositary EmployeeRepositary { get; set; }
        public IDepartmentRepositary DepartmentRepositary { get; set; }
    }
}
