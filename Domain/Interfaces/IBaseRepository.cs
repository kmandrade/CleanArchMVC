using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        /// <summary>
        /// Altera uma entity. Para salvar, utilize o método .Salvar()
        /// </summary>
        /// <param name="entity"></param>
        Task<TEntity> UpdateAsync(TEntity entity);
        /// <summary>
        /// Exclui uma entity. Para salvar, utilize o método .Salvar()
        /// </summary>
        /// <param name="entity"></param>
        Task<TEntity> DeleteAsync(TEntity entity);
        /// <summary>
        /// Método que salva todas as inserções/alterações/exclusões
        /// </summary>
        /// <returns></returns>
        Task<int> SaveAsync();

        void Dispose();
    }
}
