﻿using ir.anka.LifeTraders.SharedKernel.Application;
using MediatR;

namespace ir.anka.LifeTraders.SharedKernel.Abstraction.Application;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand> where TCommand : Command
{
}