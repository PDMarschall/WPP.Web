using System;
using System.Collections.Generic;
using System.Text;

namespace WPP.Domain.Interfaces
{
    public interface IValidationInfo
    {
        public int Minimum { get; }
        public int Maximum { get; }
        public char ConstraintCharacter { get; }
    }
}
