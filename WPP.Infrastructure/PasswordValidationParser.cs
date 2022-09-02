using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using WPP.Domain.Datastructures;
using WPP.Domain.Models;

namespace WPP.Infrastructure
{
    public class PasswordValidationParser
    {
        private readonly Regex _passwordPolicyRegex = new Regex(@"^(?<Minimum>\d{1,3})-(?<Maximum>\d{1,3}) (?<ConstraintCharacter>\w): (?<PasswordText>\w+)$");

        public PasswordCollection ParsePasswordPolicyFile(List<string> input)
        {
            PasswordCollection passwordCollection = new PasswordCollection();

            foreach (string element in input)
            {
                Match passwordPolicyMatch = _passwordPolicyRegex.Match(element);
                passwordCollection.Add(GetPasswordFromRegex(passwordPolicyMatch));
            }

            return passwordCollection;
        }

        private Password GetPasswordFromRegex(Match match)
        {
            Password tempPassword = new Password(match.Groups["PasswordText"].Value,
                                    new ValidationInfo(Convert.ToInt32(match.Groups["Minumum"].Value),
                                                    Convert.ToInt32(match.Groups["Maximum"].Value),
                                                    Convert.ToChar(match.Groups["ConstraintCharacter"].Value)));

            return tempPassword;
        }
    }
}