using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс списка контактов
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Задается список всех контактов
        /// </summary>
        public List<Contact> Contacts = new List<Contact>();

        public List<Contact> SortContacts(List<Contact> contactsList)
        {
            //Сортировка списка контактов
            contactsList.Sort(delegate (Contact x, Contact y)
            {
                if (x.Surname == null && y.Surname == null) return 0;
                else if (x.Surname == null) return -1;
                else if (y.Surname == null) return 1;
                else return x.Surname.CompareTo(y.Surname);
            });

            return contactsList;
        }

        public List<Contact> SortContacts(List<Contact> contactsList, string findSubstring)
        {
            List<Contact> findContacts = new List<Contact>();
            foreach (var contact in contactsList)
            {
                if (contact.Surname.StartsWith(findSubstring))
                {
                    findContacts.Add(contact);
                }
            }
            return findContacts;
        }
    }
}
