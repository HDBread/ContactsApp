using System;
using System.Windows.Forms;
using ContactsAppUI;

namespace ContactsApp
{
    public partial class AddEditContactForm : Form
    {
        public AddEditContactForm()
        {
            InitializeComponent();
        }

        private Contacts _contacts = new Contacts();

        public Contacts ContactsData => _contacts;
        
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
                _contacts.Surname = SurnameTextbox.Text;

            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SurnameTextbox.Focus();
                return false;
            }
            catch (FieldAccessException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SurnameTextbox.Focus();
                return false;
            }

            //TryCatch Name
            try
            {
                _contacts.Name = NameTextbox.Text;

            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                NameTextbox.Focus();
                return false;
            }
            catch (FieldAccessException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                NameTextbox.Focus();
                return false;
            }

            //TryCatch Birthday
            try
            {
                _contacts.DateOfBirhday = BirthdayDayTool.Value;

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
                _contacts.PhoneNumber = Convert.ToInt64(PhoneTextbox.Text);

            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                PhoneTextbox.Focus();
                return false;
            }
            catch (FieldAccessException e)
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
                _contacts.Email = EmailTextbox.Text;

            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                EmailTextbox.Focus();
                return false;
            }
            catch (FieldAccessException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                EmailTextbox.Focus();
                return false;
            }

            //TryCatch Vk
            try
            {
                _contacts.Vk = VkTextbox.Text;

            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                VkTextbox.Focus();
                return false;
            }
            catch (FieldAccessException e)
            {
                MessageBox.Show(e.Message, "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                VkTextbox.Focus();
                return false;
            }

            return true;
        }
    }
}
