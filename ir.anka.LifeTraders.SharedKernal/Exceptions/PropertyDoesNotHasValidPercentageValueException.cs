namespace ir.anka.LifeTraders.SharedKernel.Exceptions;

public class PropertyDoesNotHasValidPercentageValueException : DomainException
{
    private readonly string propertyTitle;

    public PropertyDoesNotHasValidPercentageValueException(string propertyTitle)
    {
        this.propertyTitle = propertyTitle;
    }

    private readonly string baseMessage = "{0} is not has a valid percentage value";

    public override string Message => string.Format(baseMessage, nameof(propertyTitle));
}