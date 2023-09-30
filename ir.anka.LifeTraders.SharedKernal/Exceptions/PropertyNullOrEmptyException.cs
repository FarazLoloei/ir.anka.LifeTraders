namespace ir.anka.LifeTraders.SharedKernel.Exceptions;

public class PropertyNullOrEmptyException : DomainException
{
    private readonly string propertyTitle;

    public PropertyNullOrEmptyException(string propertyTitle)
    {
        this.propertyTitle = propertyTitle;
    }

    private readonly string baseMessage = "{0} is null or empty";

    public override string Message => string.Format(baseMessage, nameof(propertyTitle));
}