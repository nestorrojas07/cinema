namespace Domain.Interfaces.Core;

public interface IUpdate <T, ID, OUT> where T : class where ID: struct where OUT: class 
{
    Task<OUT> UpdateAsync(ID id, T entity, CancellationToken token = default);
}