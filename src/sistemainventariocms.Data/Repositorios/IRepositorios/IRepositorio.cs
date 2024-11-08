using System.Linq.Expressions;

namespace sistemainventariocms.Data.Repositorios.IRepositorios
{
    public interface IRepositorio<T> where T : class
    {

        Task<T> Obtener(int id);
        Task<IEnumerable<T>> ObtenerTodos(
            Expression<Func<T, bool>>? filtro = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? OrderBy = null,
            string? includeProperties = null,
            bool tracked = true);
        Task<T> ObtenerPrimero(
            Expression<Func<T, bool>>? filtro = null,
            string? includeProperties = null,
            bool tracked = true);
        Task Crear(T entidad);
        void Eliminar(T entidad);
        void EliminarRango(IEnumerable<T> entidades);
        Task Actualizar(T entidad);
    }
}
