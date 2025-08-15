using src.Features.Users.DTOs;

namespace src.Features;

public interface IService<TResponse, in TRequest> where TResponse : class
{
    Task<UserResponse?> CreateAsync(TRequest request);
    Task<TResponse> GetByIdAsync(Guid id);
    Task<IEnumerable<TResponse>> FindAsync(TRequest model);
    Task<TResponse> UpdateAsync(TRequest model);
    Task DeleteAsync(TRequest model);
}