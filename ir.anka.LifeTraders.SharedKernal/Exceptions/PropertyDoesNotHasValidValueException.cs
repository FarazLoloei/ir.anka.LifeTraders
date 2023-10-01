namespace ir.anka.LifeTraders.SharedKernel.Exceptions;

public class PropertyDoesNotHasValidValueException : DomainException
{
    private readonly string propertyTitle;

    public PropertyDoesNotHasValidValueException(string propertyTitle)
    {
        this.propertyTitle = propertyTitle;
    }

    private readonly string baseMessage = "{0} is not has a valid value";

    public override string Message => string.Format(baseMessage, nameof(propertyTitle));
}