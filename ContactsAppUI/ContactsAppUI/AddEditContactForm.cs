using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsApp
{
    public partial class AddEditContactForm : Form
    {
        public AddEditContactForm()
        {
            InitializeComponent();
        }
        
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
            var _check = new CheckValue();
            bool _correctImput = true;

            if (_check.IsValueCkeck(SurnameTextbox.Text) == false)
            {
                MessageBox.Show(" Field 'Surname' can't be empty ", "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SurnameTextbox.Focus();
                _correctImput = false;
            }
            else if (_check.IsValueCkeck(NameTextbox.Text) == false)
            {
                MessageBox.Show(" Field 'Name' can't be empty ", "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                NameTextbox.Focus();
                _correctImput = false;
            }
            else if (_check.IsValueCkeck(PhoneTextbox.Text) == false)
            {
                MessageBox.Show(" Field 'PhoneNumber' can't be empty ", "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                PhoneTextbox.Focus();
                _correctImput = false;
            }
            else if (_check.IsValueCkeck(EmailTextbox.Text) == false)
            {
                MessageBox.Show(" Field 'Email' can't be empty ", "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                EmailTextbox.Focus();
                _correctImput = false;
            }
            else if (_check.IsValueCkeck(VkTextbox.Text) == false)
            {
                MessageBox.Show(" Field 'VK' can't be empty ", "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                VkTextbox.Focus();
                _correctImput = false;
            }
            
            if (_correctImput == true)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }

        /// <summary>
        /// Метод получения контакта в виде элемента списка
        /// </summary>
        /// <returns>Возвращает контакт с заполнеными полями</returns>
        public Contacts GetContact()
        {
            return new Contacts()
            {
                Surname = SurnameTextbox.Text, Name = NameTextbox.Text,
                PhoneNumber = Convert.ToInt32(PhoneTextbox.Text), Email = EmailTextbox.Text, Vk = VkTextbox.Text,
                DateOfBirhday = BirthdayDayTool.Value
            };

        }
        
    }
}
