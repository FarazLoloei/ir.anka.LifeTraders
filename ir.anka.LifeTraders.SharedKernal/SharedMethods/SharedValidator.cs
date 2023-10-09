using ir.anka.LifeTraders.SharedKernel.Exceptions;
using ir.anka.LifeTraders.SharedKernel.SharedMethods.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ir.anka.LifeTraders.SharedKernel.SharedMethods;

public class SharedValidator : ISharedValidator
{
    public IEnumerable<PropertyDoesNotHasValidValueException> CheckPropertiesValueBasedOnRangeAttribute(object obj, Type[] validTypes)
    {
        return CheckPropertiesValueBasedOnRangeAttribute(obj.GetType()
                                .GetProperties()
                                .Where(x => validTypes.Contains(x.PropertyType)));
    }

    public IEnumerable<PropertyDoesNotHasValidValueException> CheckPropertiesValueBasedOnRangeAttribute(IEnumerable<PropertyInfo> properties)
    {
        foreach (var prop in properties)
        {
            var value = (double)(prop.GetConstantValue() ?? 0);

            var rangeAttributeMetaData = prop.GetCustomAttributes<RangeAttribute>(false).First();
            if (!(value >= (double)rangeAttributeMetaData.Minimum || value <= (double)rangeAttributeMetaData.Maximum))
                yield return new PropertyDoesNotHasValidValueException(prop.Name, rangeAttributeMetaData.Minimum, rangeAttributeMetaData.Maximum);
        }
    }

    public bool IsValidIPAddress4(string ipAddress)
    {
        if (String.IsNullOrWhiteSpace(ipAddress)) return false;

        string[] splitValues = ipAddress.Split('.');
        if (splitValues.Length != 4) return false;

        byte tempForParsing;

        return splitValues.All(r => byte.TryParse(r, out tempForParsing));
    }
}