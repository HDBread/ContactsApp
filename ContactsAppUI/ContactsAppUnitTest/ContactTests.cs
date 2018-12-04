using System;
using NUnit.Framework;
using ContactsApp;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ContactsAppUnitTest
{
    [TestFixture]
    public class ContactTests
    {
        private Contact _contact;
        private PhoneNumber _phone;

        [SetUp]
        public void InitContact()
        {
            _contact = new Contact();
            _phone = new PhoneNumber();
        }
        
        /// <summary>
        /// Позитивный тест Get Surname
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="message"></param>
        [TestCase("Егоров", "Выполняется, если фамилия удачно присваевается",
            TestName = "Позитивный тест геттера Surname")]
        [Category("SurnameTests")]
        public void TestSurnameGet_CorrectValue(string expected, string message)
        {
            _contact.Surname = expected;
            var actual = _contact.Surname;

            Assert.AreEqual(expected,actual,"Геттер возвращает неправильную фамилию");
        }

        /// <summary>
        /// Позитивный тест Get Name
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="message"></param>
        [TestCase("Валера", "Выполняется, если имя удачно присваевается",
            TestName = "Позитивный тест геттера Name")]
        public void TestNameGet_CorrectValue(string expected, string message)
        {
            _contact.Name = expected;
            var actual = _contact.Name;

            Assert.AreEqual(expected, actual, "Геттер возвращает неправильное имя");
        }

        /// <summary>
        /// Позитивный тест Get DateOfBurthday
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="message"></param>
        [TestCase("2000.01.01", "Выполняется, если присвоение даты происходит коректно",
            TestName = "Позитивый тесте геттера DateOfBirthday")]
        public void TestDateGet_CorrectValue(DateTime expected, string message)
        {
            _contact.DateOfBirthday = expected;
            var actual = expected;
            Assert.AreEqual(expected, actual, message);
        }

        /// <summary>
        /// Позитивный тест Get Email
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="message"></param>
        [TestCase("Jena@jizni.net", "Выполняется, если почтовый ящик удачно присваевается",
            TestName = "Позитивный тест геттера Email")]
        public void TestEmailGet_CorrectValue(string expected, string message)
        {
            _contact.Email = expected;
            var actual = _contact.Email;

            Assert.AreEqual(expected, actual, "Геттер возвращает неправильный почтовый ящик");
        }

        /// <summary>
        /// Позитивный тест Get VkID
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="message"></param>
        [TestCase("id@HDBread", "Выполняется, если id Вконтакте удачно присваевается",
            TestName = "Позитивный тест геттера Vk")]
        public void TestVkGet_CorrectValue(string expected, string message)
        {
            _contact.Vk = expected;
            var actual = _contact.Vk;

            Assert.AreEqual(expected, actual, "Геттер возвращает неправильный почтовый ящик");
        }

        /// <summary>
        /// Позитивный тест Get PhoneNumber
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="message"></param>
        [TestCase(79528854134, "Выполняется если номер телефона удачно присваевается",
            TestName = "Позитивный тест метода Set PhoneNumber")]
        public void TestPhoneNumberGet_CorrectValue(long expected, string message)
        {
            _phone.Number = expected;
            var actual = _phone.Number;

            Assert.AreEqual(expected, actual, message);
        }


        /// <summary>
        /// Тесты Set Surname
        /// </summary>
        /// <param name="wrongSurname"></param>
        /// <param name="expectedException"></param>
        /// <param name="message"></param>
        [TestCase("Бариннов-Бариннов-Бариннов-Бариннов-Бариннов-Бариннов", typeof(ArgumentException),
            "Должно возникать исключение, если фамилия длиннее 50 символов"
            , TestName = "Присвоение неправильной фамилии больше 50 символов")]
        [TestCase("", typeof(ArgumentNullException), "Должно возникнуть исключение, если фамилия - пустая строка",
            TestName = "Присвоение пустой строки в качестве фамилии")]
        public void TestSurnameSet_ArgumentException(string wrongSurname, Type expectedException, string message)
        {
            NUnit.Framework.Assert.Throws(expectedException, () => { _contact.Surname = wrongSurname; }, message);
        }

        /// <summary>
        /// Тесты Set Name
        /// </summary>
        /// <param name="wrongName"></param>
        /// <param name="expectedException"></param>
        /// <param name="message"></param>
        [TestCase("Валера-Валера-Валера-Валера-Валера-Валера-Валера-Валера-Валера-", typeof(ArgumentException),
            "Должно возникать исключение, если имя длиннее 50 символов"
            , TestName = "Присвоение неправильного имени больше 50 символов")]
        [TestCase("", typeof(ArgumentNullException),"Должно возникнуть исключение, если имя - пустая строка",
            TestName = "Присвоение пустой строки в качестве имени")]
        public void TestNameSet_ArgumentException(string wrongName, Type expectedException, string message)
        {
            NUnit.Framework.Assert.Throws(expectedException, () => { _contact.Name = wrongName; }, message);
        }

        /// <summary>
        /// Тесты Set DateOfBirthday
        /// </summary>
        /// <param name="wrongDate"></param>
        /// <param name="message"></param>
        [TestCase("2090.01.01", typeof(ArgumentException),"Должно возникнуть изсключение, если дата больше нынешней даты",
            TestName = "Ожидается исключение, если дата больше нынешней даты")]
        public void TestDateSet_ArgimenExpected(DateTime wrongDate, Type expectedException ,string message)
        {
           NUnit.Framework.Assert.Throws(expectedException, () => { _contact.DateOfBirthday = wrongDate; }, message);
        }

        /// <summary>
        /// Тесты Set Email
        /// </summary>
        /// <param name="wrongEmail"></param>
        /// <param name="expectedException"></param>
        /// <param name="message"></param>
        [TestCase("jdnkjndkjjndnfbdfkjbnjdfnbkdf@kjnbkdfnkbndfbdfjfbjkdfnbjd.com", typeof(ArgumentException),
            "Должно возникать исключение, если почтовый ящик длиннее 50 символов"
            , TestName = "Присвоение неправильного почтового ящика больше 50 символов")]
        [TestCase("", typeof(ArgumentNullException), "Должно возникнуть исключение, если почтовый ящик - пустая строка",
            TestName = "Присвоение пустой строки в качестве почтового ящика")]
        public void TestEmailSet_ArgumentNullException(string wrongEmail, Type expectedException ,string message)
        {
           NUnit.Framework.Assert.Throws(expectedException, () => { _contact.Email = wrongEmail; }, message);

        }

        /// <summary>
        /// Тесты Set VkID
        /// </summary>
        /// <param name="wrongVkId"></param>
        /// <param name="expectedException"></param>
        /// <param name="message"></param>
        [TestCase("id@jbjhbjbjhbjbbjhjbmhjbhjbjhgjhbhbbhj", typeof(ArgumentException),
            "Должно возникать исключение, если id Вконтакте длиннее 15 символов"
            , TestName = "Присвоение неправильного id Вконтакте больше 15 символов")]
        [TestCase("", typeof(ArgumentNullException),"Должно возникнуть исключение, если id Вконтакте - пустая строка",
            TestName = "Присвоение пустой строки в качестве поля id Вконтакте")]
        public void TestVkSet_ArgumentNullException(string wrongVkId, Type expectedException, string message)
        {
            NUnit.Framework.Assert.Throws(expectedException, () => { _contact.Vk = wrongVkId; }, message);
        }

        /// <summary>
        /// Тест Set PhoneNumber
        /// </summary>
        /// <param name="wrongNumber"></param>
        /// <param name="expectedException"></param>
        /// <param name="message"></param>
        [TestCase(89528854613, typeof(FormatException), "Должно возникнуть исключение, если номер телефона начинается не с символа 7",
            TestName = "Присвоение неправильного номера телефона - начинается не с символа 7")]
        [TestCase(794, typeof(ArgumentException),"Должно возникнуть исключение, если длинна номера телефона не 11 символов",
            TestName = "Присвоение неправильного номера телефона - длинна номера не 11 символов")]
        public void TestPhoneNumberSet_FormatExpected(long wrongNumber, Type expectedException, string message)
        {
            NUnit.Framework.Assert.Throws(expectedException, () => { _phone.Number = wrongNumber; }, message);
        }
    }
}
