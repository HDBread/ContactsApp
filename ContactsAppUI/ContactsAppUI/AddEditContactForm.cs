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
            string text = SurnameTextbox.Text;
            try
            {
                _contact.Surname = text;
                SurnameTextbox.BackColor = Color.White;
                _checkSurnameResult = true;

            }
            catch (ArgumentNullException e)
            {
                errorToolTip.ToolTipTitle = "Surname Null Error";
                errorToolTip.SetToolTip(SurnameTextbox, e.Message);
                SurnameTextbox.Focus();
                SurnameTextbox.BackColor = Color.LightSalmon;
                _checkSurnameResult = false;

            }
            catch (ArgumentException e)
            {
                errorToolTip.ToolTipTitle = "Surname Length Error";
                errorToolTip.SetToolTip(SurnameTextbox, e.Message);
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
            try
            {
                _contact.Name = NameTextbox.Text;
                NameTextbox.BackColor = Color.White;
                _checkNameResult = true;

            }
            catch (ArgumentNullException e)
            {
                errorToolTip.ToolTipTitle = "Name Null Error";
                errorToolTip.SetToolTip(NameTextbox, e.Message);
                NameTextbox.Focus();
                NameTextbox.BackColor = Color.LightSalmon;
                _checkNameResult = false;
            }
            catch (ArgumentException e)
            {
                errorToolTip.ToolTipTitle = "Name Length Error";
                errorToolTip.SetToolTip(NameTextbox, e.Message);
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
            try
            {
                _contact.Num = new PhoneNumber();
                _contact.Num.Number = Convert.ToInt64(PhoneTextbox.Text);
                PhoneTextbox.BackColor = Color.White;
                _checkPhoneResult = true;

            }
            catch (ArgumentNullException e)
            {
                errorToolTip.ToolTipTitle = "Phone null error";
                errorToolTip.SetToolTip(PhoneTextbox, e.Message);
                PhoneTextbox.Focus();
                PhoneTextbox.BackColor = Color.LightSalmon;
                _checkPhoneResult = false;
            }
            catch (FormatException e)
            {
                errorToolTip.ToolTipTitle = "Phone first number error";
                errorToolTip.SetToolTip(PhoneTextbox, e.Message);
                PhoneTextbox.Focus();
                PhoneTextbox.BackColor = Color.LightSalmon;
                _checkPhoneResult = false;
            }
            catch (ArgumentException e)
            {
                errorToolTip.ToolTipTitle = "Phone length error";
                errorToolTip.SetToolTip(PhoneTextbox, e.Message);
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
            try
            {
                _contact.Email = EmailTextbox.Text;
                EmailTextbox.BackColor = Color.White;
                _checkEmailResult = true;

            }
            catch (ArgumentNullException e)
            {
                errorToolTip.ToolTipTitle = "Email Null Error";
                errorToolTip.SetToolTip(EmailTextbox, e.Message);
                EmailTextbox.Focus();
                EmailTextbox.BackColor = Color.LightSalmon;
                _checkEmailResult = false;
            }
            catch (ArgumentException e)
            {
                errorToolTip.ToolTipTitle = "Email Length Error";
                errorToolTip.SetToolTip(EmailTextbox, e.Message);
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
            try
            {
                _contact.Vk = VkTextbox.Text;
                VkTextbox.BackColor = Color.White;
                _checkVkResult = true;
            }
            catch (ArgumentNullException e)
            {
                errorToolTip.ToolTipTitle = "Vk Null Error";
                errorToolTip.SetToolTip(VkTextbox, e.Message);
                VkTextbox.Focus();
                VkTextbox.BackColor = Color.LightSalmon;
                _checkVkResult = false;
            }
            catch (ArgumentException e)
            {
                errorToolTip.ToolTipTitle = "Vk Length Error";
                errorToolTip.SetToolTip(VkTextbox, e.Message);
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
                _contact.DateOfBirhday = BirthdayDayTool.Value;
                BirthdayDayTool.BackColor = Color.White;
                _checkDataResult = true;
            }
            catch (ArgumentException e)
            {
                errorToolTip.ToolTipTitle = "Birthday value Error";
                errorToolTip.SetToolTip(BirthdayDayTool, e.Message);
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
            BirthdayDayTool.Value = contact.DateOfBirhday;
            PhoneTextbox.Text = Convert.ToString(contact.Num.Number);
            EmailTextbox.Text = contact.Email;
            VkTextbox.Text = contact.Vk;
        }

    }
}
