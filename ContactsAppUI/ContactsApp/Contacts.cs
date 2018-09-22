using System;

namespace ContactsApp
{
    public class Contacts
    {
        private string _surname;
        public string Surname
        {
            get => _surname;
            set
            {
                
                if (value == string.Empty)
                {
                    throw new ArgumentNullException("Field 'Surname' can't be empty");
                }
                else if (value.Length > 50)
                {
                    throw new ArgumentException("Длина фамилии должна быть меньше 50, а был " + value.Length);
                }
                else
                    _surname = Char.ToUpper(value[0]) + value.Substring(1);
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                
                if (value == string.Empty)
                {
                    throw new ArgumentNullException("Field 'Name' can't be empty");
                }
                else if (value.Length > 50)
                {
                    throw new ArgumentException("Длина имени должно быть меньше 50, а был " + value.Length);
                }
                else
                    _name = Char.ToUpper(value[0]) + value.Substring(1);
            }

        }

        private long _phoneNumber;
        public long PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                
                if (value.ToString() == string.Empty)
                {
                    throw new ArgumentNullException("Field 'PhoneNumber' can't be empty");
                }
                else if (value.ToString().Length > 11)
                {
                    throw new ArgumentException("Длина фамилии должна быть меньше 11, а был " + value.ToString().Length);
                }
                else if (value.ToString()[0] != '7')
                {
                    throw new FormatException("Номер телефона должен начинаться с 7, а начинается с " + value.ToString()[0]);
                }
                _phoneNumber = value;
            }
        }

        private DateTime _date;
        public DateTime DateOfBirhday
        {
            get => _date;
            set
            {
                if (value > DateTime.Today)
                {
                    throw new ArgumentException("Дата не должна быть больше " + DateTime.Today.ToShortDateString() + ", а был " + value.Date.ToShortDateString());
                }
                else
                    _date = value;
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                
                if (value == string.Empty)
                {
                    throw new ArgumentNullException("Field 'Email' can't be empty");
                }
                else if (value.Length > 50)
                {
                    throw new ArgumentException("Длинна Email'а должна быть меньше 50, а был " + value.Length);
                }
                else
                    _email = value;
            }
        }

        private string _vk;
        public string Vk
        {
            get => _vk;
            set
            {
                
                if (value == string.Empty)
                {
                   throw new ArgumentNullException("Field 'Vk' can't be empty");
                }
                else if (value.Length > 15)
                {
                    throw new ArgumentException("Длинна id vk должна быть меньше 15, а был " + value.Length);
                }
                else
                    _vk = value;
            }
        }
    }
}
