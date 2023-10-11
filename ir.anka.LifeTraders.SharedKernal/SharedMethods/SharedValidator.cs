using ir.anka.LifeTraders.SharedKernel.Exceptions;
using ir.anka.LifeTraders.SharedKernel.SharedMethods.Abstraction;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ir.anka.LifeTraders.SharedKernel.SharedMethods;

public class SharedValidator : ISharedValidator
{
    public IEnumerable<PropertyDoesNotHasValidValueException> CheckPropertiesValueBasedOnRangeAttribute(object obj, Type[] validTypes)
    {
        return CheckPropertiesValueBasedOnRangeAttribute(obj, obj.GetType()
                                .GetProperties()
                                .Where(x => validTypes.Contains(x.PropertyType)));
    }

    public IEnumerable<PropertyDoesNotHasValidValueException> CheckPropertiesValueBasedOnRangeAttribute(object obj, IEnumerable<PropertyInfo> properties)
    {
        foreach (var prop in properties)
        {

            dynamic value = prop.GetValue(obj) ?? 0;
            if (value is int || value is byte || value is Int32 || value is long)
                value = Convert.ToInt64(value);

            if (value is double || value is float)
                value = Convert.ToDouble(value);

            var rangeAttributeMetaData = prop.GetCustomAttributes<RangeAttribute>(false).First();
            if (!(value >= double.Parse(rangeAttributeMetaData.Minimum.ToString()!) || value <= double.Parse(rangeAttributeMetaData.Maximum.ToString()!)))
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