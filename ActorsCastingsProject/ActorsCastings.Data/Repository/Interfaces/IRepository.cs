using System.Linq.Expressions;

namespace ActorsCastings.Data.Repository.Interfaces
{
    public interface IRepository<TType, TId>
    {
        TType GetById(TId id);

        Task<TType> GetByIdAsync(TId id);

        IEnumerable<TType> GetAll();

        Task<IEnumerable<TType>> GetAllAsync();

        IQueryable<TType> GetAllAttached();

        TType FirstOrDefault(Func<TType, bool> predicate);

        Task<TType> FirstOrDefaultAsync(Expression<Func<TType, bool>> predicate);

        void Add(TType entity);

        Task AddAsync(TType entity);

        bool Update(TType entity);

        Task<bool> UpdateAsync(TType entity);

        bool SoftDelete(TId id);

        Task<bool> SoftDeleteAsync(TId id);

    }
}
