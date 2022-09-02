using System;
using System.Collections.Generic;
using System.IO;
using WPP.Domain.Datastructures;
using WPP.Domain.Models;
using WPP.Infrastructure;

namespace WPP.ConsoleTester
{
    public class Program
    {
        private static PasswordValidationParser _parser = new PasswordValidationParser();
        private static List<string> _fileContents = new List<string>();
        private static string path = @"C:\Dania\PrgTek31-PasswordPolicy.txt";
        private static PasswordCollection _passwordCollection;

        static void Main(string[] args)
        {
            ReadFile();
            RunParser();

            _passwordCollection.SetValidationPolicy(new ValidationPolicy_One());
            IEnumerable<Password> valid = _passwordCollection.ReturnValidPasswords();
        }

        private static void ReadFile()
        {
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                _fileContents.Add(reader.ReadLine());
            }
        }

        private static void RunParser()
        {
            _passwordCollection = _parser.ParsePasswordPolicyFile(_fileContents);
        }
    }
}
