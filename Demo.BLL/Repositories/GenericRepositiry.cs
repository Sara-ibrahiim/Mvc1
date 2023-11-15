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
    public class GenericRepositiry<T> : IGenericRepositiry<T> where T : BaseEntity
    {

        private readonly MvcAppDbContext _context;
        public GenericRepositiry(MvcAppDbContext context)
        {
            _context = context;

        }
        public int Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChanges();
        }

        public int Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
         => _context.Set<T>().ToList();

        public T GetById(int? id)
        => _context.Set<T>().Find(id);

        public int Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return _context.SaveChanges();
        }
    }
}
