using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsApp
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void GitLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Линк остается видимым
            this.GitLink.LinkVisited = true;
            //Навигация по URL
            System.Diagnostics.Process.Start("http://github.com/hdbread/ContactsApp");
        }
    }
}
