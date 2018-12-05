using System;
using System.IO;
using System.Reflection;
using ContactsApp;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace ContactsAppUnitTest
{
    [TestFixture]
    public class SerealizationTests
    {
        private string _path;
        private Project _contact = new Project();
        private readonly Contact _firstContact = new Contact();
        private readonly Contact _secondContact = new Contact();

        /// <summary>
        /// Подготовка данных к тестированию (де)сериализации
        /// </summary>
        [SetUp]
        public void InitContact()
        {
            _path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //Первый контакт на проверку
            _firstContact.Name = "Грыня";
            _firstContact.Surname = "Резник";
            _firstContact.DateOfBirthday = new DateTime(1997,06,12);
            _firstContact.Num.Number = 79528856498;
            _firstContact.Email = "Rezya@gmail.com";
            _firstContact.Vk = "id@egoka";

            //Второй контакт на проверку
            _secondContact.Name = "Василий";
            _secondContact.Surname = "Петров";
            _secondContact.DateOfBirthday = new DateTime(1998,06,07);
            _secondContact.Num.Number = 79214541235;
            _secondContact.Email = "vasya@mail.ru";
            _secondContact.Vk = "id@vasya";
        }

        /// <summary>
        /// Позитивный тест десериализации
        /// </summary>
        [Test(Description = "Тест десериализации")]
        public void TestDeserialization()
        {
            _contact = ProjectManager.LoadFile(_contact, _path + @"\TestProjectFiles\TestContacts.txt");

            NUnit.Framework.Assert.AreEqual(2,_contact.Contacts.Count,"Кол-во контактов не совпадают");
            Assert.AreEqual(_contact.Contacts[0].Name, _firstContact.Name, "Метод десеариализует не правильную информацию(имя первого контакта)");
            Assert.AreEqual(_contact.Contacts[1].Surname, _secondContact.Surname, "Метод десериалузиет не правильную информацию(фамилия второго контакта)");
            Assert.AreEqual(_contact.Contacts[0].Num.Number, _firstContact.Num.Number, "Метод десериалузиет не правильную информацию(номер телефона первого контакта)");
            Assert.AreEqual(_contact.Contacts[1].Email, _secondContact.Email, "Метод десериалузиет не правильную информацию(почтовый ящик второго контакта)");
            Assert.AreEqual(_contact.Contacts[1].DateOfBirthday, _secondContact.DateOfBirthday,"Date incorrect!");
        }

        /// <summary>
        /// Позитивный тест сериализации
        /// </summary>
        [Test(Description = "Тест сериализации")]
        public void TestSerialization()
        {
            ProjectManager.SaveFile(_contact ,_path + @"\TestProjectFiles\SaveContactsTest.txt");
            var fileAsString = File.ReadAllText(_path + @"\TestProjectFiles\SaveContactsTest.txt");
            var expected = File.ReadAllText(_path + @"\TestProjectFiles\TestContacts.txt");
            Assert.AreEqual(expected,fileAsString,"Метод сериализует не верную информацию");
        }
    }
}
