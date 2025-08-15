using System.Linq.Expressions;
using src.Features.Users.Entities;
using src.Features.Users.Interfaces;

namespace src.Features.Users;

public class UserRepository : IUserRepository
{
    public Task<User> AddAsync(User model)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> FindAsync(Expression<Func<User, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(User model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(User model)
    {
        throw new NotImplementedException();
    }
}