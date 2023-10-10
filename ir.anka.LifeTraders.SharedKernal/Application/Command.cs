using MediatR;

namespace ir.anka.LifeTraders.SharedKernel.Application;

public abstract class Command : IRequest
{
    public Command()
    {
        timeStamp = DateTime.Now;
    }

    private DateTime timeStamp;

    public DateTime TimeStamp
    { get { return timeStamp; } }
}