namespace BasicAPISettings.Api.Domain.Repositories;

public interface IGenericRepository<T> where T : class
{
    /// <summary>
    /// Adiciona um registro na tabela do banco de dados
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task Add(T entity);

    /// <summary>
    /// Adiciona um conjunto de dados na tabela do banco de dados
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    Task AddRange(IEnumerable<T> entities);

    /// <summary>
    /// Exclui um registro na tabela do banco de dados
    /// </summary>
    /// <param name="item"></param>
    void Remove(T item);

    /// <summary>
    /// Exclui um conjunto de dados na tabela do banco de dados
    /// </summary>
    /// <param name="entities"></param>
    void RemoveRange(IEnumerable<T> entities);

    /// <summary>
    /// Atualiza um registro na tabela do banco de dados
    /// </summary>
    /// <param name="entity"></param>
    void Update(T entity);

    /// <summary>
    /// Atualiza um conjunto de dados na tabela do banco de dados
    /// </summary>
    /// <param name="entities"></param>
    void UpdateRange(IEnumerable<T> entities);

    /// <summary>
    /// Pesquisa todos os registro em uma tabela do banco de dados
    /// </summary>
    /// <returns></returns>
    Task<T[]> GetAll();

    /// <summary>
    /// Pesquisa um registro na tabela do banco de dados
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T> GetByIdAsync(T id);
}
