using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using WPP.Domain.Datastructures;
using WPP.Domain.Models;

namespace WPP.Infrastructure
{
    public class PasswordValidationParser
    {
        private readonly Regex _passwordPolicyRegex = new Regex(@"^(?<Minimum>\d{1,3})-(?<Maximum>\d{1,3}) (?<ConstraintCharacter>\w): (?<PasswordText>\w+)$");

        public PasswordCollection ParsePasswordPolicyFile(IEnumerable<string> input)
        {
            PasswordCollection passwordCollection = new PasswordCollection();

            foreach (string element in input)
            {
                Match passwordPolicyMatch = _passwordPolicyRegex.Match(element);
                passwordCollection.Add(GetPasswordFromRegex(passwordPolicyMatch));
            }

            return passwordCollection;
        }

        public IEnumerable<string> ReadPasswordFile(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                List<string> fileContents = new List<string>();
                while (!reader.EndOfStream)
                {
                    fileContents.Add(reader.ReadLine());
                }
                return fileContents;
            }
        }

        private Password GetPasswordFromRegex(Match match)
        {
            Password tempPassword = new Password(match.Groups["PasswordText"].Value,
                                    new ValidationInfo(Convert.ToInt32(match.Groups["Minimum"].Value),
                                                    Convert.ToInt32(match.Groups["Maximum"].Value),
                                                    Convert.ToChar(match.Groups["ConstraintCharacter"].Value)));

            return tempPassword;
        }
    }
}