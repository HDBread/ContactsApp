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
using System.IO;
using Newtonsoft.Json;

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
        private bool _isProjectChanged = false;

        /// <summary>
        /// Объявление нового экземпляра списка
        /// </summary>
        private Project _project = new Project();

        public MainForm()
        {
            InitializeComponent();
            ProjectManager projectManager = new ProjectManager();
            _project = projectManager.LoadFile(_project);
        }
        
        /// <summary>
        /// Открыть окно About
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form About = new AboutForm();
            About.ShowDialog();
        }

        /// <summary>
        /// Кнопка выхода из программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Кнопка создания нового контакта. Вводимые поля не должны быть пустыми.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditContactForm addContact = new AddEditContactForm();
            if (addContact.ShowDialog() == DialogResult.OK)
            {
                _project.Contacts.Add(addContact.ContactsData);
            }
            FillListView(_project.Contacts);
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

        /// <summary>
        /// Вывод выбранного контакта для просмотра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContactsList.SelectedIndices.Count != 0)
            {
                SurnameTextbox.Text = _project.Contacts[ContactsList.SelectedIndices[0]].Surname;
                NameTextbox.Text = _project.Contacts[ContactsList.SelectedIndices[0]].Name;
                BirthdayDayTool.Value = _project.Contacts[ContactsList.SelectedIndices[0]].DateOfBirhday;
                PhoneTextbox.Text = Convert.ToString(_project.Contacts[ContactsList.SelectedIndices[0]].PhoneNumber);
                EmailTextbox.Text = _project.Contacts[ContactsList.SelectedIndices[0]].Email;
                VkTextbox.Text = _project.Contacts[ContactsList.SelectedIndices[0]].Vk;
            }
            else
            {
                SurnameTextbox.Text = string.Empty;
                NameTextbox.Text = string.Empty;
                BirthdayDayTool.Value = new DateTime(2000,01,01);
                PhoneTextbox.Text = string.Empty;
                EmailTextbox.Text = string.Empty;
                VkTextbox.Text = string.Empty;
            }
        }

        /// <summary>
        /// Кнопка удаления выбранного контакта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
          DialogResult _dialogResult = MessageBox.Show("Are you sure you want to delete the contact?", "Remove Contact",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (_dialogResult == DialogResult.Yes)
            {
                int index = ContactsList.SelectedIndices[0];
                _project.Contacts.RemoveAt(index);
                ContactsList.Items[index].Remove();
                _isProjectChanged = true;
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            ProjectManager projectManager = new ProjectManager();
            projectManager.SaveFile(_project);
        }
    }
}
