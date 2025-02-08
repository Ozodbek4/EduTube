using EduTube.Domain.Entities;

namespace EduTube.Domain.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);

    Task UpdateAsync(User user);

    Task DeleteAsync(User user);
}