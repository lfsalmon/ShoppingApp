using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopServer.Data.Repositories
{
    public interface IGenericRepository<T>
    {
        public Task<T> Add(T entity);
        public Task<T> Update(T entity);
        public Task<T> Delete(int id);
        public Task<T> GetById(int id);
        public Task<List<T>> GetAll();

    }
}
