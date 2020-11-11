using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRSample.Application.Models.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int Id);
        Task Add(T item);
        Task Edit(T item);
        Task Delete(int Id);
    }
}
