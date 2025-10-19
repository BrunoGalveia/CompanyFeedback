using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyFeedback.Domain.Interface.Repos
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Add(TEntity entity);
        TEntity Update(TEntity entity);
        Task<bool> Delete(int id);
        Task<bool> Any(int id);
    }
}
