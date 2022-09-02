using System;
using System.Collections.Generic;
using System.Text;
using WPP.Domain.Enums;

namespace WPP.Domain.Interfaces
{
    public interface IValidationPolicy
    {
        public ValidationStatus ValidationStatus { get; }

        public ValidationStatus Validate();
    }
}
