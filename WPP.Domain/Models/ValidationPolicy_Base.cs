using System;
using System.Collections.Generic;
using System.Text;
using WPP.Domain.Enums;
using WPP.Domain.Interfaces;

namespace WPP.Domain.Models
{
    public abstract class ValidationPolicy_Base : IValidationPolicy
    {
        public ValidationStatus ValidationStatus { get; }

        public abstract ValidationStatus Validate(Password password);
    }
}
