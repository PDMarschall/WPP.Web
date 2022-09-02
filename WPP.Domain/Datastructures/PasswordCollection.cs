using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPP.Domain.Enums;
using WPP.Domain.Models;

namespace WPP.Domain.Datastructures
{
    public class PasswordCollection
    {
        private List<Password> _passwordCollection = new List<Password>();
        private bool _hasBeenValidated = false;

        public bool HasBeenValidated => _hasBeenValidated;
        public int Count => _passwordCollection.Count;
        public int ValidCount => _passwordCollection.Select(p => p.ValidationPolicy.ValidationStatus == ValidationStatus.Valid).Count();
        public int InvalidCount => _passwordCollection.Select(p => p.ValidationPolicy.ValidationStatus == ValidationStatus.Invalid).Count();

        public PasswordCollection()
        {

        }

        public PasswordCollection(Password password)
        {
            _passwordCollection.Add(password);
        }

        public PasswordCollection(IEnumerable<Password> passwords)
        {
            _passwordCollection.AddRange(passwords);
        }

        public void ValidateCollection()
        {
            if (Count > 0)
            {
                foreach (Password pword in _passwordCollection)
                {
                    pword.ValidationPolicy.Validate(pword);
                }
                _hasBeenValidated = true;
            }
        }

        public IEnumerable<Password> ReturnValidPasswords()
        {
            return (IEnumerable<Password>)_passwordCollection.Select(p => p.ValidationPolicy.ValidationStatus == ValidationStatus.Valid);
        }

        public IEnumerable<Password> ReturnInvalidPasswords()
        {
            return (IEnumerable<Password>)_passwordCollection.Select(p => p.ValidationPolicy.ValidationStatus == ValidationStatus.Invalid);
        }
    }
}
