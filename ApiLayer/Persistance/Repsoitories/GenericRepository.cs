using ApiLayer.Core.Application.Interfaces;
using ApiLayer.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiLayer.Persistance.Repsoitories
{
    public class GenericRepository<T> : IRepository<T> where T : class, new()
    {
        private readonly JWTContext _jWTContext;

        public GenericRepository(JWTContext jWTContext)
        {
            _jWTContext = jWTContext;
        }

        public async Task CreateAsync(T entity)
        {
           await this._jWTContext.Set<T>().AddAsync(entity);
            await this._jWTContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllsync()
        {
            return await this._jWTContext.Set<T>().AsNoTracking().ToListAsync(); //asnotracking :uygulamaların performansını optimize etmemize yardımcı olmak için geliştirilmiş bir fonksiyondur.
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter) 
        {
            return await this._jWTContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter); //default varsa boş geçilebelir de olabailir bu yuzden soru işareti ilgili yere koyabilirisn
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await this._jWTContext.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
           this._jWTContext.Set<T>().Remove(entity);
            await this._jWTContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
           this._jWTContext.Set<T>().Update(entity);
            await this._jWTContext.SaveChangesAsync();
        }
    }
}
