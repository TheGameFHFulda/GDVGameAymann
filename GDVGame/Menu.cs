using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDVGame
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void buttonStart_Click (object sender, EventArgs e)
        {
            Level2 form = new Level2();
            form.ShowDialog();
        }
        private void buttonExit_Click (object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
