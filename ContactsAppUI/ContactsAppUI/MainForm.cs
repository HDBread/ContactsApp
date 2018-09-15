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

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
        private bool _isProjectChanged = false;

        private List<Contacts> _contact = new List<Contacts>();

        public MainForm()
        {
            InitializeComponent();
           
        }
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form About = new AboutForm();
            About.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditContactForm addContact = new AddEditContactForm();
            if (addContact.ShowDialog() == DialogResult.OK)
            {
                _contact.Add(addContact.GetContact());
            }
            FillListView(_contact);
            _isProjectChanged = true;
        }



        /// <summary>
        /// Заполнить список контактов. Если в списке уже есть данные (список ранее был заполнен),
        /// то список будет очищен и снова заполнен.
        /// </summary>
        /// <param name="_contacts">Список контактов</param>
        public void FillListView(List<Contacts> _contact)
        {
            if (ContactsList.Items.Count > 0) ContactsList.Items.Clear();
            foreach (Contacts contact in _contact)
            {
                AddNewClient(contact);
            }
        }

        /// <summary>
        /// Добавить нового контакта
        /// </summary>
        /// <param name="contact">Контакт</param>
        public void AddNewClient(Contacts contact)
        {
            int index = ContactsList.Items.Add(contact.Surname).Index;
            ContactsList.Items[index].Tag = contact; //свойство Tag теперь ссылается на клиента, пригодится при удалении из списка и редактировании
        }

        private void ContactsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContactsList.SelectedIndices.Count != 0)
            {
                SurnameTextbox.Text = _contact[ContactsList.SelectedIndices[0]].Surname;
                NameTextbox.Text = _contact[ContactsList.SelectedIndices[0]].Name;
                BirthdayDayTool.Value = _contact[ContactsList.SelectedIndices[0]].DateOfBirhday;
                PhoneTextbox.Text = Convert.ToString(_contact[ContactsList.SelectedIndices[0]].PhoneNumber);
                EmailTextbox.Text = _contact[ContactsList.SelectedIndices[0]].Email;
                VkTextbox.Text = _contact[ContactsList.SelectedIndices[0]].Vk;
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
