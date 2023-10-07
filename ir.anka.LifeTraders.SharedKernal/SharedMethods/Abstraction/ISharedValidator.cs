using ir.anka.LifeTraders.SharedKernel.Exceptions;
using System.Reflection;

namespace ir.anka.LifeTraders.SharedKernel.SharedMethods.Abstraction;

public interface ISharedValidator
{
    public IEnumerable<PropertyDoesNotHasValidValueException> CheckPropertiesValueBasedOnRangeAttribute(object obj, Type[] validTypes);

    public IEnumerable<PropertyDoesNotHasValidValueException> CheckPropertiesValueBasedOnRangeAttribute(IEnumerable<PropertyInfo> properties);
}