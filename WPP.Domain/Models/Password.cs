using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using WPP.Domain.Interfaces;

namespace WPP.Domain.Models
{
    public class Password
    {
        public IValidationPolicy ValidationPolicy { get; set; }
        public string PasswordText { get; }

        public Password(string pwtext)
        {
            PasswordText = pwtext;            
        }
    }
}