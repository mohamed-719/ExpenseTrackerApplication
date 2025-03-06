using Data;
using ExpenseTracker.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private EtDbContext _context;


        public Repository(EtDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
            //_context.SavedChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            //_context.SaveChanges(); 
        }

        public void Delete(int id)
        {
            // var entity= _context.Set<T>().Find(id);
            //_context.Set<T>().Remove(entity);
            //_context.SaveChanges();
            var entity = GetById(id);
            Delete(entity);

        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            //_context.SaveChanges();

        }


        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            //_context.SaveChanges();

        }
    }
}
