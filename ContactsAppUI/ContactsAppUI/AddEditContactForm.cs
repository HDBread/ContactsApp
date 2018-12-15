using System;
using System.Drawing;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;

namespace ContactsApp
{
    public partial class AddEditContactForm : Form
    {
        public AddEditContactForm()
        {
            InitializeComponent();
        }

        private Contact _contact = new Contact();

        public Contact ContactData => _contact;

        #region Флаги правильности ввода параметров

        /// <summary>
        /// Флаг верности ввода фамилии
        /// </summary>
        private bool _checkSurnameResult = false;

        /// <summary>
        /// Флаг верности ввода имени
        /// </summary>
        private bool _checkNameResult = false;

        /// <summary>
        /// Флаг верности ввода Даты
        /// </summary>
        private bool _checkDataResult = false;

        /// <summary>
        /// Флаг верности ввода номера телефона
        /// </summary>
        private bool _checkPhoneResult = false;

        /// <summary>
        /// Флаг верности ввода почового ящика
        /// </summary>
        private bool _checkEmailResult = false;

        /// <summary>
        /// Флаг верности ввода Id Вконтакте
        /// </summary>
        private bool _checkVkResult = false;

        #endregion

        /// <summary>
        /// Кнопка Cancel. Закрывает форму.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Кнопка ОК. Выполняется метод на валидацию даных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {

            if (_checkSurnameResult == true & _checkNameResult == true & _checkDataResult == true &
                _checkPhoneResult == true & _checkEmailResult == true & _checkVkResult == true)
            {
                DialogResult = DialogResult.OK;
                this.Close();

            }
        }

        /// <summary>
        /// Проверка ввода только цифр
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }

            if ((PhoneTextbox.Text.Length == 11) && number != 8)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Метод проверки ввода фамилии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurnameTextbox_TextChanged(object sender, EventArgs ex)
        {
            UpperFirstSimbol(sender);
            try
            {
                _contact.Surname = SurnameTextbox.Text;
                SurnameTextbox.BackColor = Color.White;
                errorProvider.SetError(SurnameTextbox, String.Empty);
                _checkSurnameResult = true;

            }
            catch (ArgumentNullException e)
            {
                errorProvider.SetError(SurnameTextbox, e.Message);
                SurnameTextbox.Focus();
                SurnameTextbox.BackColor = Color.LightSalmon;
                _checkSurnameResult = false;

            }
            catch (ArgumentException e)
            {
                errorProvider.SetError(SurnameTextbox, e.Message);
                SurnameTextbox.Focus();
                SurnameTextbox.BackColor = Color.LightSalmon;
                _checkSurnameResult = false;

            }

        }

        /// <summary>
        /// Метод проверки ввода имени
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameTextbox_TextChanged(object sender, EventArgs ex)
        {
            UpperFirstSimbol(sender);
            try
            {
                _contact.Name = NameTextbox.Text;
                NameTextbox.BackColor = Color.White;
                errorProvider.SetError(NameTextbox, String.Empty);
                _checkNameResult = true;

            }
            catch (ArgumentNullException e)
            {
                errorProvider.SetError(NameTextbox, e.Message);
                NameTextbox.Focus();
                NameTextbox.BackColor = Color.LightSalmon;
                _checkNameResult = false;
            }
            catch (ArgumentException e)
            {
                errorProvider.SetError(NameTextbox, e.Message);
                NameTextbox.Focus();
                NameTextbox.BackColor = Color.LightSalmon;
                _checkNameResult = false;
            }
        }

        /// <summary>
        /// Метод проверки ввода номера телефона
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        private void PhoneTextbox_TextChanged(object sender, EventArgs ex)
        {
            UpperFirstSimbol(sender);
            try
            {
                _contact.Num = new PhoneNumber();
                _contact.Num.Number = Convert.ToInt64(PhoneTextbox.Text);
                PhoneTextbox.BackColor = Color.White;
                errorProvider.SetError(PhoneTextbox, String.Empty);
                _checkPhoneResult = true;

            }
            catch (ArgumentNullException e)
            {
                errorProvider.SetError(PhoneTextbox, e.Message);
                PhoneTextbox.Focus();
                PhoneTextbox.BackColor = Color.LightSalmon;
                _checkPhoneResult = false;
            }
            catch (FormatException e)
            {
                errorProvider.SetError(PhoneTextbox, e.Message);
                PhoneTextbox.Focus();
                PhoneTextbox.BackColor = Color.LightSalmon;
                _checkPhoneResult = false;
            }
            catch (ArgumentException e)
            {
                errorProvider.SetError(PhoneTextbox, e.Message);
                PhoneTextbox.Focus();
                PhoneTextbox.BackColor = Color.LightSalmon;
                _checkPhoneResult = false;
            }
        }

        /// <summary>
        /// Метод проверки ввода почтового ящика
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        private void EmailTextbox_TextChanged(object sender, EventArgs ex)
        {
            UpperFirstSimbol(sender);
            try
            {
                _contact.Email = EmailTextbox.Text;
                EmailTextbox.BackColor = Color.White;
                errorProvider.SetError(EmailTextbox,String.Empty);
                _checkEmailResult = true;

            }
            catch (ArgumentNullException e)
            {
                errorProvider.SetError(EmailTextbox, e.Message);
                EmailTextbox.Focus();
                EmailTextbox.BackColor = Color.LightSalmon;
                _checkEmailResult = false;
            }
            catch (ArgumentException e)
            {
                errorProvider.SetError(EmailTextbox, e.Message);
                EmailTextbox.Focus();
                EmailTextbox.BackColor = Color.LightSalmon;
                _checkEmailResult = false;
            }
        }

        /// <summary>
        /// Метод проверки ввода id Вконтакте
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        private void VkTextbox_TextChanged(object sender, EventArgs ex)
        {
            UpperFirstSimbol(sender);
            try
            {
                _contact.Vk = VkTextbox.Text;
                VkTextbox.BackColor = Color.White;
                errorProvider.SetError(VkTextbox,String.Empty);
                _checkVkResult = true;
            }
            catch (ArgumentNullException e)
            {
                errorProvider.SetError(VkTextbox,e.Message);
                VkTextbox.Focus();
                VkTextbox.BackColor = Color.LightSalmon;
                _checkVkResult = false;
            }
            catch (ArgumentException e)
            {
                errorProvider.SetError(VkTextbox,e.Message);
                VkTextbox.Focus();
                VkTextbox.BackColor = Color.LightSalmon;
                _checkVkResult = false;
            }
        }
    
        /// <summary>
        /// Метод проверки ввода дня рождения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BirthdayDayTool_ValueChanged(object sender, EventArgs ex)
        {
            try
            {
                _contact.DateOfBirthday = BirthdayDayTool.Value;
                BirthdayDayTool.BackColor = Color.White;
                errorProvider.SetError(BirthdayDayTool,String.Empty);
                _checkDataResult = true;
            }
            catch (ArgumentException e)
            {
                errorProvider.SetError(BirthdayDayTool,e.Message);
                BirthdayDayTool.BackColor = Color.LightSalmon;
                BirthdayDayTool.Focus();
                _checkDataResult = false;
            }
        }

        /// <summary>
        /// Отображение информации экземпляра контакта
        /// </summary>
        /// <param name="contact">Экземпляр контакта</param>
        public void ContactView(Contact contact)
        {
            SurnameTextbox.Text = contact.Surname;
            NameTextbox.Text = contact.Name;
            BirthdayDayTool.Value = contact.DateOfBirthday;
            PhoneTextbox.Text = Convert.ToString(contact.Num.Number);
            EmailTextbox.Text = contact.Email;
            VkTextbox.Text = contact.Vk;
        }

        /// <summary>
        /// Метод задания первого символа в верхний регистр
        /// </summary>
        /// <param name="sender"></param>
        private void UpperFirstSimbol(object sender)
        {
            if (((TextBox)sender).Text.Length == 1)
                ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
        }

    }
}
