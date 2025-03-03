﻿using MediatR;

namespace EduTube.Application.Abstractions.Messaging;

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
}

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
}