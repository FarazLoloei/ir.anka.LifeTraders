namespace ir.anka.LifeTraders.SharedKernel.Exceptions;

public class InvalidIPAddressException : DomainException
{
    private readonly string propertyTitle;

    public InvalidIPAddressException(string propertyTitle)
    {
        this.propertyTitle = propertyTitle;
    }

    private readonly string baseMessage = "{0} is not a valid IP address";

    public override string Message => string.Format(baseMessage, nameof(propertyTitle));
}