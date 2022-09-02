using System;
using System.Collections.Generic;
using System.Text;
using WPP.Domain.Interfaces;

namespace WPP.Domain.Helpers
{
    public class PasswordValidator
    {
        public IValidationPolicy ValidationPolicy { get; set; }

    }
}
