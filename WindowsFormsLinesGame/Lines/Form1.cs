using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lines
{
    public partial class FormLimes : Form
    {
        Dasht dt;
        public FormLimes()
        {
            InitializeComponent();
            dt = new Dasht(this);
        }

        private void FormLimes_Paint(object sender, PaintEventArgs e)
        {
           Graphics g =  e.Graphics;
           dt.Paint(g);
        }

        private void FormLimes_MouseClick(object sender, MouseEventArgs e)
        {
            dt.Click(e.X, e.Y);
            Invalidate();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt.New();
            Invalidate();
        }
    }
}
