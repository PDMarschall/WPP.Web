using System;
using System.Collections.Generic;
using System.Text;
using WPP.Domain.Interfaces;

namespace WPP.Domain.Models
{
    public class ValidationPolicy_One : ValidationPolicy_Base
    {
        private int _occcurrence;
        private int _maxOccurernce;
        private int _minOccurrence;
        private char _constraintChar;


        public override void Validate(Password password)
        {
            _occcurrence = 0;
            _maxOccurernce = password.ValidationInfo.Maximum;
            _minOccurrence = password.ValidationInfo.Minimum;
            _constraintChar = password.ValidationInfo.ConstraintCharacter;

            password.Valid = TestPasswordText(password.PasswordText);
        }

        private bool TestPasswordText(string pwordText)
        {
            foreach (char element in pwordText)
            {
                if (element == _constraintChar)
                    _occcurrence++;
            }

            return _occcurrence <= _maxOccurernce && _occcurrence >= _minOccurrence;
        }
    }
}
