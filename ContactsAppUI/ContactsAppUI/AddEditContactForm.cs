using System;
using System.Drawing;
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

        
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //TODO: проверка перед передачи данных в список
        /// <summary>
        /// Кнопка ОК. Выполняется проверка на не пустые поля 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            if (CheckCorrectInput() == true)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// Метод проверки правильности вводимых полей контакта
        /// </summary>
        /// <returns>Истину, если все поля введены правильно</returns>
        public bool CheckCorrectInput()
        {

            //TryCatch Birthday
            try
            {
                _contact.DateOfBirhday = BirthdayDayTool.Value;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                BirthdayDayTool.Focus();
                return false;

            }

            return true;
        }

        public void ContactView(Contact contact)
        {
            SurnameTextbox.Text = contact.Surname;
            NameTextbox.Text = contact.Name;
            BirthdayDayTool.Value = contact.DateOfBirhday;
            PhoneTextbox.Text = Convert.ToString(contact.Num.Number);
            EmailTextbox.Text = contact.Email;
            VkTextbox.Text = contact.Vk;
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
        }

        /// <summary>
        /// Метод проверки ввода фамилии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurnameTextbox_TextChanged(object sender, EventArgs e)
        {
            string text = SurnameTextbox.Text;
            try
            {
                _contact.Surname = text;
                SurnameTextbox.BackColor = Color.White;

            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SurnameTextbox.Focus();
                SurnameTextbox.BackColor = Color.LightSalmon;

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SurnameTextbox.Focus();
                SurnameTextbox.BackColor = Color.LightSalmon;

            }

        }

        /// <summary>
        /// Метод проверки ввода имени
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameTextbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.Name = NameTextbox.Text;
                NameTextbox.BackColor = Color.White;

            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                NameTextbox.Focus();
                NameTextbox.BackColor = Color.LightSalmon;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                NameTextbox.Focus();
                NameTextbox.BackColor = Color.LightSalmon;
            }
        }

        //TODO: Как задать дату?
        /// <summary>
        /// Метод проверки ввода даты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        private void DataTextbox_TextChanged(object sender, EventArgs ex)
        {
            try
            {
                _contact.DateOfBirhday = BirthdayDayTool.Value;

            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                BirthdayDayTool.Focus();
                
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

            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                PhoneTextbox.Focus();
                PhoneTextbox.BackColor = Color.LightSalmon;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                PhoneTextbox.Focus();
                PhoneTextbox.BackColor = Color.LightSalmon;
            }
            catch (FormatException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                PhoneTextbox.Focus();
                PhoneTextbox.BackColor = Color.LightSalmon;
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

            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                EmailTextbox.Focus();
                EmailTextbox.BackColor = Color.LightSalmon;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                EmailTextbox.Focus();
                EmailTextbox.BackColor = Color.LightSalmon;
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
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                VkTextbox.Focus();
                VkTextbox.BackColor = Color.LightSalmon;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                VkTextbox.Focus();
                VkTextbox.BackColor = Color.LightSalmon;
            }
        }

    }
}
