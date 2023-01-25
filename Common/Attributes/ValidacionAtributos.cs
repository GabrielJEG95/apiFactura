

using System;
using System.ComponentModel.DataAnnotations;

namespace Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class RequiredId : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var inputValue = int.Parse(value.ToString());

            return inputValue != 0;

        }
    }

}