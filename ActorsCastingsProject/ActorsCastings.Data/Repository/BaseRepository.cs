using ActorsCastings.Data.Repository.Interfaces;
using ActorsCastings.Web.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ActorsCastings.Data.Repository
{
    public class BaseRepository<TType, TId> : IRepository<TType, TId>
        where TType : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TType> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TType>();
        }
        public void Add(TType entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public async Task AddAsync(TType entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public TType FirstOrDefault(Func<TType, bool> predicate)
        {
            TType entity = _dbSet.FirstOrDefault(predicate);

            return entity;
        }


        public async Task<TType> FirstOrDefaultAsync(Expression<Func<TType, bool>> predicate)
        {
            TType entity = await _dbSet.FirstOrDefaultAsync(predicate);

            return entity;
        }

        public IEnumerable<TType> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<TType>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public IQueryable<TType> GetAllAttached()
        {
            return _dbSet.AsQueryable();
        }

        public TType GetById(TId id)
        {
            TType? entity = _dbSet
                .Find(id);

            return entity;
        }

        public async Task<TType> GetByIdAsync(TId id)
        {
            TType? entity = await _dbSet
                .FindAsync(id);

            return entity;
        }

        public bool SoftDelete(params TId[] id)
        {
            try
            {
                TType? entity = _dbSet.Find(id);
                if (entity == null)
                {
                    return false;
                }

                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> SoftDeleteAsync(params TId[] id)
        {
            try
            {
                TType? entity = await _dbSet.FindAsync(id);
                if (entity == null)
                {
                    return false;
                }

                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(TType entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TType entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
