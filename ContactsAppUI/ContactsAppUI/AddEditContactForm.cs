using System;
using System.Windows.Forms;

namespace ContactsApp
{
    public partial class AddEditContactForm : Form
    {
        public AddEditContactForm()
        {
            InitializeComponent();
        }

        private Contacts _contact = new Contacts();

        public Contacts ContactData => _contact;

        
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
            //TryCatch Surname
            try
            {
                _contact.Surname = SurnameTextbox.Text;

            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SurnameTextbox.Focus();
                return false;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SurnameTextbox.Focus();
                return false;
            }

            //TryCatch Name
            try
            {
                _contact.Name = NameTextbox.Text;

            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                NameTextbox.Focus();
                return false;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                NameTextbox.Focus();
                return false;
            }

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

            //TryCatch PhoneNumber
            try
            {
                _contact.PhoneNumber = Convert.ToInt64(PhoneTextbox.Text);

            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                PhoneTextbox.Focus();
                return false;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                PhoneTextbox.Focus();
                return false;
            }
            catch (FormatException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                PhoneTextbox.Focus();
                return false;
            }

            //TryCatch Email
            try
            {
                _contact.Email = EmailTextbox.Text;

            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                EmailTextbox.Focus();
                return false;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                EmailTextbox.Focus();
                return false;
            }

            //TryCatch Vk
            try
            {
                _contact.Vk = VkTextbox.Text;

            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                VkTextbox.Focus();
                return false;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                VkTextbox.Focus();
                return false;
            }

            return true;
        }

        public void ContactView(Contacts contact)
        {
            SurnameTextbox.Text = contact.Surname;
            NameTextbox.Text = contact.Name;
            BirthdayDayTool.Value = contact.DateOfBirhday;
            PhoneTextbox.Text = Convert.ToString(contact.PhoneNumber);
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
    }
}
