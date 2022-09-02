using System;
using System.Collections.Generic;
using System.Text;
using WPP.Domain.Enums;
using WPP.Domain.Interfaces;

namespace WPP.Domain.Models
{
    public class ValidationPolicy_Two : ValidationPolicy_Base
    {
        public override ValidationStatus Validate()
        {
            throw new NotImplementedException();
        }
    }
}
