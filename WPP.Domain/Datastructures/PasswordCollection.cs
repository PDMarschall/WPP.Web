using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPP.Domain.Models;

namespace WPP.Domain.Datastructures
{
    public class PasswordCollection
    {
        private List<Password> _passwordCollection = new List<Password>();
        public int Count => _passwordCollection.Count;

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
            foreach (Password pword in _passwordCollection)
            {
                pword.ValidationPolicy.Validate(pword);
            }
        }

        public IEnumerable<Password> ReturnValidatPasswords()
        {
            return (IEnumerable<Password>)_passwordCollection.Select(x => x.ValidationPolicy.ValidationStatus == Enums.ValidationStatus.Valid);
        }

        public IEnumerable<Password> ReturnInvalidatPasswords()
        {
            return (IEnumerable<Password>)_passwordCollection.Select(x => x.ValidationPolicy.ValidationStatus == Enums.ValidationStatus.Invalid);
        }
    }
}
