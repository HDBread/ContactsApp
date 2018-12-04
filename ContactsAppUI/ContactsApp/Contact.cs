using System;

namespace ContactsApp
{
    public class Contact : ICloneable
    {
        /// <summary>
        /// Объект(?) свойста фамилия
        /// </summary>
        private string _surname;

        /// <summary>
        /// Объект(?) свойста имя
        /// </summary>
        private string _name;

        /// <summary>
        /// Объект(?) свойста дата рождения
        /// </summary>
        private DateTime _date;

        /// <summary>
        /// Объект(?) свойства номер телефона
        /// </summary>
        private PhoneNumber _phone = new PhoneNumber();

        /// <summary>
        /// Объект(?) свойста почтовый ящик
        /// </summary>
        private string _email;

        /// <summary>
        /// Объект(?) свойста id вконтакте
        /// </summary>
        private string _vk;


        /// <summary>
        /// Свойство фамилия
        /// </summary>
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

        /// <summary>
        /// Свойство Имя
        /// </summary>
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

        /// <summary>
        /// Свойство номер телефона
        /// </summary>
        public PhoneNumber Num
        {
            get => _phone;
            set => _phone = value;
        }

        /// <summary>
        /// Свойство дата рождения
        /// </summary>
        public DateTime DateOfBirthday
        {
            get => _date;
            set
            {
                if (value > DateTime.Today)
                {
                    throw new ArgumentException("Дата не должна быть больше " + DateTime.Today.ToShortDateString() +
                                                ", а был " + value.Date.ToShortDateString());
                }
                else
                    _date = value;
            }
        }

        /// <summary>
        /// Свойство почтовый ящик
        /// </summary>
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

        /// <summary>
        /// Свойство idВконтакте
        /// </summary>
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

        /// <summary>
        /// Метод клонирования контакта
        /// </summary>
        /// <returns>Склонированный контакт</returns>
        public object Clone()
        {
            Contact newContact = new Contact();
            newContact.Name = Name;
            newContact.Surname = Surname;
            newContact.Num.Number = Num.Number;
            newContact.DateOfBirthday = DateOfBirthday;
            newContact.Email = Email;
            newContact.Vk = Vk;
            return newContact;
        }
    }
}
