using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T GetbyId(int id, string[] includes = null);
        IReadOnlyList<T> GetAll(string[] includes = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
