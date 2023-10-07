namespace ir.anka.LifeTraders.SharedKernel.Exceptions;

public class PropertyDoesNotHasValidValueException : DomainException
{
    private readonly string propertyTitle;
    private readonly object minimumValue, maximumValue;

    public PropertyDoesNotHasValidValueException(string propertyTitle, object minimumValue, object maximumValue)
    {
        this.propertyTitle = propertyTitle;
        this.minimumValue = minimumValue;
        this.maximumValue = maximumValue;
    }

    private readonly string baseMessage = "{0} is not has a valid value, value should be between ({1}, {2})";

    public override string Message => string.Format(baseMessage, nameof(propertyTitle), minimumValue, maximumValue);
}