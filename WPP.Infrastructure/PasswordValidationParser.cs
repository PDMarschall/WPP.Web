using System;
using System.Text.RegularExpressions;

namespace WPP.Infrastructure
{
    public class PasswordValidationParser
    {
        private readonly Regex _passwordRegex = new Regex(@"^?<Minimum>\d{1, 3}-?<Maximum>\d{1,3} ?<ConstraintCharacter>\w: ?<PasswordText>\w +$");
    }
}
