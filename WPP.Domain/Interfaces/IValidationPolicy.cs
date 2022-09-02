using System;
using System.Collections.Generic;
using System.Text;
using WPP.Domain.Models;

namespace WPP.Domain.Interfaces
{
    public interface IValidationPolicy
    {
        public void Validate(Password password);
    }
}
