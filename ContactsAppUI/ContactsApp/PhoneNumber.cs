using System;

namespace ContactsApp
{
    public class PhoneNumber
    {
        private long _phoneNumber;
        public long Number
        {
            get => _phoneNumber;
            set
            {

                if (value.ToString() == string.Empty)
                {
                    throw new ArgumentNullException("Field 'PhoneNumber' can't be empty");
                }
                else if (value.ToString().Length != 11)
                {
                    throw new ArgumentException("Длина номера телефона должна быть ровно 11 символов, а был " + value.ToString().Length);
                }
                else if (value.ToString()[0] != '7')
                {
                    throw new FormatException("Номер телефона должен начинаться с 7, а начинается с " + value.ToString()[0]);
                }
                _phoneNumber = value;
            }
        }
    }
}
