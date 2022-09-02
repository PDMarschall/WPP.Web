using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPP.Domain.Helpers;
using WPP.Domain.Interfaces;
using WPP.Domain.Models;

namespace WPP.Domain.Datastructures
{
    public class PasswordCollection :IEnumerable
    {
        private List<Password> _passwordCollection = new List<Password>();
        private PasswordValidator _validator = new PasswordValidator();
        private bool _hasBeenValidated = false;
        private int _validCount = 0;
        private int _invalidCount = 0;

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
            _validator.ValidationPolicy = valpol;
        }

        public void ValidateCollection()
        {
            if (Count > 0)
            {
                foreach (Password pword in _passwordCollection)
                {
                    _validator.ValidationPolicy.Validate(pword);
                }
                _hasBeenValidated = true;
            }
        }

        public IEnumerable<Password> ReturnValidPasswords()
        {
            IEnumerable<Password> temp = _passwordCollection.FindAll(p => p.Valid);
            _validCount = temp.Count();
            return temp;
        }

        public IEnumerable<Password> ReturnInvalidPasswords()
        {
            IEnumerable<Password> temp = _passwordCollection.FindAll(p => !p.Valid);
            _invalidCount = temp.Count();
            return temp;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)_passwordCollection).GetEnumerator();
        }
    }
}
