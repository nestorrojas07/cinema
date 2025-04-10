namespace Domain.Interfaces.Core;

public interface IRead<T> where T : class
{
    Task<T> GetByIdAsync(long id, CancellationToken token = default);
}