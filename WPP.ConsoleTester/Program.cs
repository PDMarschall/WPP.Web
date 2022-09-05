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
        private static string path = @"D:\Dania\PrgTek31-PasswordPolicy.txt";
        private static PasswordCollection _passwordCollection;

        static void Main(string[] args)
        {
            ReadFile();
            RunParser();

            _passwordCollection.SetValidationPolicy(new ValidationPolicy_One());
            _passwordCollection.ValidateCollection();

            IEnumerable<Password> validOne = _passwordCollection.ReturnValidPasswords();
            IEnumerable<Password> invalidOne = _passwordCollection.ReturnInvalidPasswords();

            Console.WriteLine("Policy One");
            Console.WriteLine($"Count of valid passwords: {_passwordCollection.ValidCount}");
            Console.WriteLine($"Count of invalid passwords: {_passwordCollection.InvalidCount}");
            Console.WriteLine();

            _passwordCollection.SetValidationPolicy(new ValidationPolicy_Two());
            _passwordCollection.ValidateCollection();

            IEnumerable<Password> validTwo = _passwordCollection.ReturnValidPasswords();
            IEnumerable<Password> invalidTwo = _passwordCollection.ReturnInvalidPasswords();

            Console.WriteLine("Policy Two");
            Console.WriteLine($"Count of valid passwords: {_passwordCollection.ValidCount}");
            Console.WriteLine($"Count of invalid passwords: {_passwordCollection.InvalidCount}");
            Console.WriteLine();
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
