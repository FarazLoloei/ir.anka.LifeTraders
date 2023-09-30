namespace ir.anka.LifeTraders.SharedKernel.Exceptions;

public class PropertyValueIsInvalidException : DomainException
{
    private readonly string propertyTitle;

    public PropertyValueIsInvalidException(string propertyTitle)
    {
        this.propertyTitle = propertyTitle;
    }

    private readonly string baseMessage = "{0} is invalid";

    public override string Message => string.Format(baseMessage, nameof(propertyTitle));
}