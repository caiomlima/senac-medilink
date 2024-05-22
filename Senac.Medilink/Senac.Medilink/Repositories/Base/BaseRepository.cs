using Senac.Medilink.Data.Entity.Common;

namespace Senac.Medilink.Repositories.Base
{
    public class BaseRepository<TEntity> where TEntity : BaseEntity, IBaseRepository<TEntity>
    {
        public BaseRepository()
        {
            
        }

        public async Task<TEntity> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
