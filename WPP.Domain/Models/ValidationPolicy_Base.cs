using System;
using System.Collections.Generic;
using System.Text;
using WPP.Domain.Interfaces;

namespace WPP.Domain.Models
{
    public abstract class ValidationPolicy_Base : IValidationPolicy
    {        
        public abstract void Validate(Password password);
    }
}
