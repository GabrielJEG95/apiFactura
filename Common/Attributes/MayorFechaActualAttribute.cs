using System;
using System.ComponentModel.DataAnnotations;

namespace Common.Attributes
{
    public class MayorFechaActualAttribute : ValidationAttribute
    {
        public MayorFechaActualAttribute()
        {
            this.ErrorMessage = "{0} debe ser posterior o igual a la fecha actual " + DateTime.Now.Date.ToString("dd/MM/yyyy");
        }

        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            if (dt.Date >= DateTime.Now.Date)
            {
                return true;
            }
            return false;
        }
    }

}