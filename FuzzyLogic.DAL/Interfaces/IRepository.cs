using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FuzzyLogic.DAL.Interfaces
{
    internal interface IRepository<T> : IDisposable where T : class
    {
        /// <summary>
        /// Получить сущность по ключу
        /// </summary>
        /// <param name="id"> Ключ </param>
        /// <returns> Сущность </returns>
        Task<T> Get(long id);

        /// <summary>
        /// Получить перечисление сущностей
        /// </summary>
        /// <returns> Перечисление сущностей </returns>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Получить перечисление сущностей по фильтру
        /// </summary>
        /// <param name="filter"> Фильтр отбора </param>
        /// <returns> Перечисление сущностей </returns>
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Получить сущность с применением фильтра отбора
        /// </summary>
        /// <param name="filter"> Фильтр отбора </param>
        /// <returns> Сущность </returns>
        Task<T> Get(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Создать новую сущность
        /// </summary>
        /// <param name="entity"> Сущность </param>
        T Create(T entity);

        /// <summary>
        /// Обновить сущность
        /// </summary>
        /// <param name="entity"> Сущность для обновления</param>
        void Update(T entity);

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="entity"> Сущность для удаления </param>
        void Delete(T entity);
    }
}
