
namespace Data.Interfaces.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> ObterTodos();

        Task<TEntity> Adicionar(TEntity entity);
    }
}
