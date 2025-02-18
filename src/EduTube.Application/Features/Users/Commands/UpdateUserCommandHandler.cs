using AutoMapper;
using EduTube.Application.Abstractions.Messaging;
using EduTube.Application.Abstractions.Persistence;
using EduTube.Application.Common.DTOs;
using EduTube.Application.Common.Exceptions;
using EduTube.Application.Common.Extensions;
using EduTube.Domain.Entities;
using FluentValidation;

namespace EduTube.Application.Features.Users.Commands;

public class UpdateUserCommandHandler(IUnitOfWork unitOfWork,
    IMapper mapper,
    IValidator<UpdateUserCommand> validator) : ICommandHandler<UpdateUserCommand, UserDto>
{
    public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        await validator.EnsureValidationAsync(request, cancellationToken);

        var exists = await unitOfWork.Users.GetAsync(entity => entity.Id == request.Id && !entity.IsDeleted, asNoTracking: false)
            ?? throw new NotFoundException(nameof(User), request.Id);

        exists.FirstName = request.FirstName;
        exists.LastName = request.LastName;

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return mapper.Map<UserDto>(exists);
    }
}