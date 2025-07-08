using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Core.Contract.Repositories
{
    public interface IRepository<T>
    {
        Task<T?> GetById(Guid id);
        Task<List<T>> GetAll();
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);
    }
}
