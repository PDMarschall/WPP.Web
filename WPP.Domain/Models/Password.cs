using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using WPP.Domain.Interfaces;

namespace WPP.Domain.Models
{
    public class Password
    {        
        public IValidationInfo ValidationInfo { get; set; }
        public string PasswordText { get; set; }
        public bool Valid { get; set; }

        public Password(string pwtext, IValidationInfo info)
        {
            PasswordText = pwtext;
            ValidationInfo = info;
        }

        public override string ToString()
        {
            return PasswordText;
        }

        public string ToFullString()
        {
            return $"{ValidationInfo.Minimum}-{ValidationInfo.Maximum} {ValidationInfo.ConstraintCharacter}: {PasswordText}";
        }
    }
}