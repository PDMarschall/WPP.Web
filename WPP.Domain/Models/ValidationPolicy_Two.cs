﻿using System;
using System.Collections.Generic;
using System.Text;
using WPP.Domain.Enums;
using WPP.Domain.Interfaces;

namespace WPP.Domain.Models
{
    public class ValidationPolicy_Two : ValidationPolicy_Base
    {
        public ValidationPolicy_Two(int min, int max, char constraint) : base(min, max, constraint)
        {
        }

        public override ValidationStatus Validate(Password password)
        {
            throw new NotImplementedException();
        }
    }
}
