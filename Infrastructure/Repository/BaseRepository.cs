using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public T GetbyId(int id, string[] includes = null)
        {
            //    var s=  _context.Set<T>().Find(id);
            //return s;


            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include).AsNoTracking();
            return query.FirstOrDefault(e=>e.Id==id);
            //return _context.Set<T>().AsNoTracking().FirstOrDefault(e=>e.Id==id);
        }

        public IReadOnlyList<T> GetAll(string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include).AsNoTracking();
            return query.ToList();
            // return await _context.Set<T>().AsNoTracking().ToList();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
