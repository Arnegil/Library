using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using PizzaDelivery.ViewModel.Exensions;

namespace PizzaDelivery.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumValue)
        {
            var enumMember = enumValue.GetType().GetMember(enumValue.ToString()).FirstOrDefault();
            var descriptionAttribute =
                enumMember == null
                    ? default(DescriptionAttribute)
                    : enumMember.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            return
                descriptionAttribute == null
                    ? enumValue.ToString()
                    : descriptionAttribute.Description;
        }

        public static T[] GetEnumValues<T>(this Type enumType)
        {
            if (enumType != typeof(T))
                throw new ArgumentException(nameof(enumType));

            var array = Enum.GetValues(enumType);
            var enums = array.Cast<T>().ToArray();
            return enums;
        }
    }
}
