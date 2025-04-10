namespace Domain.Interfaces.Core;

public interface IUpdate <T> where T : class
{
    Task<T> UpdateAsync(T entity, CancellationToken token = default);
}