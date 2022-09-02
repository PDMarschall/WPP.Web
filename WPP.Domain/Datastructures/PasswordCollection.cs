using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPP.Domain.Enums;
using WPP.Domain.Interfaces;
using WPP.Domain.Models;

namespace WPP.Domain.Datastructures
{
    public class PasswordCollection
    {
        private List<Password> _passwordCollection = new List<Password>();
        private bool _hasBeenValidated = false;
        private int _validCount;
        private int _invalidCount;

        public bool HasBeenValidated => _hasBeenValidated;
        public int Count => _passwordCollection.Count;
        public int ValidCount => _validCount;
        public int InvalidCount => _invalidCount;

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

        public void Add(Password password)
        {
            _passwordCollection.Add(password);
        }

        public void Clear()
        {
            _passwordCollection.Clear();
        }

        public void SetValidationPolicy(IValidationPolicy valpol)
        {
            if (Count > 0)
            {
                foreach (Password pword in _passwordCollection)
                {
                    pword.ValidationPolicy = valpol;
                }
                _hasBeenValidated = true;
            }
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
            IEnumerable<Password> temp = _passwordCollection.FindAll(p => p.ValidationPolicy.ValidationStatus == ValidationStatus.Valid);
            _validCount = temp.Count();
            return temp;
        }

        public IEnumerable<Password> ReturnInvalidPasswords()
        {
            IEnumerable<Password> temp = (IEnumerable<Password>)_passwordCollection.Select(p => p.ValidationPolicy.ValidationStatus == ValidationStatus.Invalid);
            _invalidCount = temp.Count();
            return temp;
        }
    }
}
