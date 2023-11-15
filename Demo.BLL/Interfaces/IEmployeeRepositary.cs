using Demo.DAL.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IEmployeeRepositary : IGenericRepositiry <Employee>
    {
        IEnumerable<Employee> GetEmployeesByDepartmentName(string name);
        IEnumerable<Employee> Search(string name);
        //Employee GetEmployeeId(int? id);
        //IEnumerable<Employee> GetEmployees();
        //int Add(Employee employee);
        //int Update(Employee employee);
        //int Delete(Employee employee);

    }
}
