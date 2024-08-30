using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NormDBChecker
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void списокПользователейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersList ul = new UsersList();
            ul.MdiParent = this;
            ul.Show();
        }
    }
}
