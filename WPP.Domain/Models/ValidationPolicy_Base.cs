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
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public char ConstraintCharacter { get; set; }

        public ValidationPolicy_Base(int min, int max, char constraint)
        {
            Minimum = min;
            Maximum = max;
            ConstraintCharacter = constraint;
        }

        public abstract ValidationStatus Validate(Password password);
    }
}
