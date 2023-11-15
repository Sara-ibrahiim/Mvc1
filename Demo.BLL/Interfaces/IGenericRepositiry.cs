using Demo.DAL.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IGenericRepositiry <T> where T : BaseEntity
    {
        T GetById(int? id);
        IEnumerable<T> GetAll();
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
