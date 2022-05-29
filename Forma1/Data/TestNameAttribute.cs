using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forma1.Data
{
    public class TestNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var context = (Forma1Context)validationContext.GetService(typeof(Forma1Context));
            if (!context.RaceGroup.Any(x => x.Name.Equals(value.ToString())))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Team Name already exists!");
        }
    }
}
