using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityHotelRooms.Repositories.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllEntities();
        Task CreateEntity(T entity);
        Task UpdateEntity(T entity);
        Task DeleteEntity(T entity);
    }
}
