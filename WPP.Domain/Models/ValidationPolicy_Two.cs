using System;
using System.Collections.Generic;
using System.Text;
using WPP.Domain.Interfaces;

namespace WPP.Domain.Models
{
    public class ValidationPolicy_Two : ValidationPolicy_Base
    {
        private int _indexOne;
        private int _indexTwo;
        private char _constraintChar;
        private bool _occurrenceOne;
        private bool _occurrenceTwo;


        public override void Validate(Password password)
        {
            _indexOne = password.ValidationInfo.Minimum - 1;
            _indexTwo = password.ValidationInfo.Maximum - 1;
            _constraintChar = password.ValidationInfo.ConstraintCharacter;

            password.Valid = TestPasswordText(password.PasswordText);
        }

        private bool TestPasswordText(string pwordText)
        {
            char[] temp = pwordText.ToCharArray();

            if (_indexOne >= 0)
                _occurrenceOne = (temp[_indexOne] == _constraintChar);

            if (_indexTwo <= temp.Length)
                _occurrenceTwo = (temp[_indexTwo] == _constraintChar);

            return _occurrenceOne ^ _occurrenceTwo;
        }
    }
}
