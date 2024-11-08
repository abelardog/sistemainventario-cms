using Microsoft.EntityFrameworkCore;
using sistemainventariocms.Data.Data;
using sistemainventariocms.Data.Repositorios.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace sistemainventariocms.Data.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> _dbSet;

        public Repositorio(ApplicationDbContext db, DbSet<T> dbSet)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public async Task Actualizar(T entidad)
        {
            _dbSet.Update(entidad);
        }

        public async Task Crear(T entidad)
        {
            await _dbSet.AddAsync(entidad);
        }

        public void Eliminar(T entidad)
        {
            _dbSet.Remove(entidad);
        }

        public void EliminarRango(IEnumerable<T> entidades)
        {
            _dbSet.UpdateRange(entidades);
        }

        public async Task<T> Obtener(int id)
        {
           return await _dbSet.FindAsync(id) ?? default;
        }

        public async Task<T> ObtenerPrimero(Expression<Func<T, bool>>? filtro = null, string? includeProperties = null, bool tracked = true)
        {
            IQueryable<T> query = _dbSet;

            if (filtro != null)
            {
                query = query.Where(filtro);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync() ?? null;
        }

        public async Task<IEnumerable<T>> ObtenerTodos(Expression<Func<T, bool>>? filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>>? OrderBy = null, string? includeProperties = null, bool tracked = true)
        {
            IQueryable<T> query = _dbSet;
            
            if (filtro != null)
            {
                query = query.Where(filtro);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            if (OrderBy != null)
            {
                return await OrderBy(query).ToListAsync();
            }
            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }
    }
}
