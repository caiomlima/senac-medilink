using Senac.Medilink.Data.Entity.Common;

namespace Senac.Medilink.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetAsync(long id, CancellationToken cancellationToken = default);
        Task<TEntity> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
