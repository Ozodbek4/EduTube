using AutoMapper;
using EduTube.Application.Abstractions.Messaging;
using EduTube.Application.Abstractions.Persistence;
using EduTube.Domain.Entities;

namespace EduTube.Application.Features.Users.Commands;

public record CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : ICommandHandler<CreateUserCommand, long>
{
    public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request.UserDto);
        user.Credentials = new UserCredentials { PasswordHash = request.UserDto.Password };

        await unitOfWork.BeginTransactionAsync(cancellationToken);

        await unitOfWork.Users.AddAsync(user);
        
        await unitOfWork.CommitTransactionAsync(cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}