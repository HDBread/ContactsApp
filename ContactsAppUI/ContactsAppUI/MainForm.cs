using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ContactsApp
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Объявление нового экземпляра списка контактов
        /// </summary>
        private Project _project = new Project();

        /// <summary>
        /// Экземпляр списка контактов после поиска
        /// </summary>
        private readonly Project _projectForFind = new Project();
        

        /// <summary>
        /// Загрузка данных при запуске программы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _project = ProjectManager.LoadFile(_project, String.Empty);
            FillListView(_project.Contacts);
        }

        /// <summary>
        /// Открыть окно About
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Форма для показа окна About
            Form About = new AboutForm();
            About.ShowDialog();
        }

        /// <summary>
        /// Кнопка выхода из программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Метод создания нового контакта. Вводимые поля не должны быть пустыми.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            AddEditContactForm addContact = new AddEditContactForm();
            if (addContact.ShowDialog() == DialogResult.OK)
            {
                _project.Contacts.Add(addContact.ContactData);
                SaveFile();
            }
            FillListView(_project.Contacts);
        }

        /// <summary>
        /// Заполнить список контактов. Если в списке уже есть данные (список ранее был заполнен),
        /// то список будет очищен и снова заполнен.
        /// </summary>
        /// <param name="contacts">Список контактов</param>
        public void FillListView(List<Contact> contacts)
        {
            if (ContactsList.Items.Count > 0) ContactsList.Items.Clear();

            contacts = _project.SortContacts(contacts);

            foreach (Contact contact in contacts)
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
            string contactSurnameAndName = contact.Surname + " " + contact.Name;
            int index = ContactsList.Items.Add(contactSurnameAndName).Index;
            ContactsList.Items[index].Tag = contact; //свойство Tag теперь ссылается на клиента, пригодится при удалении из списка и редактировании
        }

        /// <summary>
        /// Вывод выбранного контакта для просмотра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var project = (FindTextbox.Text == string.Empty) ? _project : _projectForFind;

            if (ContactsList.SelectedIndices.Count != 0)
            {
                SurnameTextbox.Text = project.Contacts[ContactsList.SelectedIndices[0]].Surname;
                NameTextbox.Text = project.Contacts[ContactsList.SelectedIndices[0]].Name;
                BirthdayDayTool.Value = project.Contacts[ContactsList.SelectedIndices[0]].DateOfBirthday;
                PhoneTextbox.Text = project.Contacts[ContactsList.SelectedIndices[0]].Num.Number.ToString();
                EmailTextbox.Text = project.Contacts[ContactsList.SelectedIndices[0]].Email;
                VkTextbox.Text = project.Contacts[ContactsList.SelectedIndices[0]].Vk;
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
            var project = (FindTextbox.Text == string.Empty) ? _project : _projectForFind;

            DialogResult _dialogResult = MessageBox.Show("Are you sure you want to delete the contact?", "Remove Contact",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (_dialogResult == DialogResult.Yes)
            {
                int index = ContactsList.SelectedIndices[0];
                project.Contacts.RemoveAt(index);
                ContactsList.Items[index].Remove();
                SaveFile();
            }
        }

        /// <summary>
        /// Метод изменения контакта. Контакт должен изменяться поштучно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_Click(object sender, EventArgs e)
        {
            var project = (FindTextbox.Text == string.Empty) ? _project : _projectForFind;

            int index = ContactsList.SelectedIndices[0];
            AddEditContactForm editContact = new AddEditContactForm();
            editContact.ContactView(project.Contacts[index]);
            if (editContact.ShowDialog() == DialogResult.OK)
            {
                project.Contacts.RemoveAt(index);
                ContactsList.Items[index].Remove();
                project.Contacts.Insert(index,editContact.ContactData);
                FillListView(project.Contacts);
                SaveFile();
            }
            
        }

        /// <summary>
        /// Диалог сохранени файла без выбора куда схоранять
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        /// <summary>
        /// Диалог сохранени файла с выбором куда схоранять
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        /// <summary>
        /// Диалог открытия файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
            string fileName = openFile.FileName;
            _project = ProjectManager.LoadFile(_project, fileName);
            FillListView(_project.Contacts);

        }

        /// <summary>
        /// Метод для сохранения файла с выбором ферикории сохранения
        /// </summary>
        private void SaveFileAs()
        {
            SaveFileDialog saveFileAs = new SaveFileDialog();
            saveFileAs.Filter = "Только текстовые файлы (*.txt) | *.txt";
            saveFileAs.ShowDialog();
            string fileName = saveFileAs.FileName;
            ProjectManager.SaveFile(_project, fileName);
        }

        /// <summary>
        /// Метод сохранения файла без выбора дериктории сохранения
        /// </summary>
        private void SaveFile()
        {
            ProjectManager.SaveFile(_project, String.Empty);
        }

        private void FindTextbox_TextChanged(object sender, EventArgs e)
        { 
            _projectForFind.Contacts = _projectForFind.SortContacts(_project.Contacts, FindTextbox.Text);

            FillListView(_projectForFind.Contacts);
        }

    }
}
