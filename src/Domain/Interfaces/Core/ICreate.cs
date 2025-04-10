using Domain.Entities;

namespace Domain.Interfaces.Core;

public interface ICreate<T> where T : class
{
    Task<T> CreateAsync(T entity, CancellationToken token = default);
}