using System;
using System.Collections.Generic;
using System.Text;
using WPP.Domain.Interfaces;

namespace WPP.Domain.Models
{
    public class ValidationInfo
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public char ConstraintCharacter { get; set; }

        public ValidationInfo(int min, int max, char constraint)
        {
            Minimum = min;
            Maximum = max;
            ConstraintCharacter = constraint;
        }
    }
}
