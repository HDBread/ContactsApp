using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
        private bool _isProjectChanged = false;

        /// <summary>
        /// Объявление нового экземпляра списка
        /// </summary>
        private Project _project = new Project();
        private ProjectManager _projectManager = new ProjectManager();

        public MainForm()
        {
            InitializeComponent();
            _project = _projectManager.LoadFile(_project, String.Empty);
            FillListView(_project.Contacts);
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
            DialogResult dialogResult;
            if(_isProjectChanged != true | ContactsList.Items.Count == 0)
                this.Close();
            else
            {
                dialogResult = MessageBox.Show("Имеются не сохраненные данные. Желаете сохранить их перед выходом?",
                    "Save befor exit",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (dialogResult == DialogResult.Yes)
                {
                    safeAsToolStripMenuItem_Click(sender,e);
                }
                else
                {
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Метод создания нового контакта. Вводимые поля не должны быть пустыми.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditContactForm addContact = new AddEditContactForm();
            if (addContact.ShowDialog() == DialogResult.OK)
            {
                _project.Contacts.Add(addContact.ContactData);
                _isProjectChanged = true;
            }
            FillListView(_project.Contacts);
        }
        
        /// <summary>
        /// Заполнить список контактов. Если в списке уже есть данные (список ранее был заполнен),
        /// то список будет очищен и снова заполнен.
        /// </summary>
        /// <param name="_contact">Список контактов</param>
        public void FillListView(List<Contact> _contact)
        {
            if (ContactsList.Items.Count > 0) ContactsList.Items.Clear();
            foreach (Contact contact in _contact)
            {
                AddNewClient(contact);
            }
        }

        /// <summary>
        /// Добавить нового контакта
        /// </summary>
        /// <param name="contact">Контакт</param>
        public void AddNewClient(Contact contact)
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
                PhoneTextbox.Text = Convert.ToString(_project.Contacts[ContactsList.SelectedIndices[0]].Num.Number);
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
        /// Метод удаления выбранного контакта
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

        /// <summary>
        /// Метод изменения контакта. Контакт должен изменяться поштучно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_Click(object sender, EventArgs e)
        {
            int index = ContactsList.SelectedIndices[0];
            AddEditContactForm editContact = new AddEditContactForm();
            editContact.ContactView(_project.Contacts[index]);
            if (editContact.ShowDialog() == DialogResult.OK)
            {
                _project.Contacts.RemoveAt(index);
                ContactsList.Items[index].Remove();
                _project.Contacts.Insert(index,editContact.ContactData);
                _isProjectChanged = true;
            }
            FillListView(_project.Contacts);
        }

        /// <summary>
        /// Диалог сохранени файла без выбора куда схоранять
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void safeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _projectManager.SaveFile(_project, String.Empty);
            _isProjectChanged = false;
        }

        /// <summary>
        /// Диалог сохранени файла с выбором куда схоранять
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void safeAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        /// <summary>
        /// Диалог открытия файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_isProjectChanged == true)
            {
                MessageBox.Show("Есть несохраненные данные. Желаете сохранить их перед открытием новых?",
                    "Save before open",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    SaveFile();
                }
            }

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
            string fileName = openFile.FileName;
            _project = _projectManager.LoadFile(_project, fileName);
            FillListView(_project.Contacts);
            _isProjectChanged = false;

        }

        private void SaveFile()
        {
            SaveFileDialog saveFileAs = new SaveFileDialog();
            saveFileAs.Filter = "Только текстовые файлы (*.txt) | *.txt";
            saveFileAs.ShowDialog();
            string fileName = saveFileAs.FileName;
            _projectManager.SaveFile(_project, fileName);
            _isProjectChanged = false;
        }
    }
}
