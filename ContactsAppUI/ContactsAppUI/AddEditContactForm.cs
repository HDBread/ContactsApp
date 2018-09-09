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

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (SurnameTextbox.Text == "")
            {
                MessageBox.Show(" Field 'Surname' can't be empty ", "Add Contact Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            
        }

        public Contacts GetContact()
        {
            return new Contacts()
            {
                Surname = SurnameTextbox.Text, Name = NameTextbox.Text,
                PhoneNumber = Convert.ToInt32(PhoneTextbox.Text), Email = EmailTextbox.Text, vk = VkTextbox.Text,
                DateOfBirhday = BirthdayDayTool.Value
            };

        }
    }
}
