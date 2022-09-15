using System;
using System.Collections.Generic;
using System.Text;
using WPP.Domain.Interfaces;
using WPP.Domain.Models;

namespace WPP.Domain.Helpers
{
    public class PasswordValidator
    {
        public IValidationPolicy ValidationPolicy { get; set; }
        public PasswordValidator()
        {
            ValidationPolicy = new ValidationPolicy_One();
        }

    }
}
