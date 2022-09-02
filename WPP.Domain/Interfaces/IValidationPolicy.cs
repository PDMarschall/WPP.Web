using System;
using System.Collections.Generic;
using System.Text;
using WPP.Domain.Enums;
using WPP.Domain.Models;

namespace WPP.Domain.Interfaces
{
    public interface IValidationPolicy
    {
        public ValidationStatus ValidationStatus { get; }

        public ValidationStatus Validate(Password password);
    }
}
