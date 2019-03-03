using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace psdmggo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //VScrollBar q = new VScrollBar();
            //q.Dock = DockStyle.Right;
            //groupBox1.Controls.Add(q);
            //groupBox1.Controls.Add(new Button());
        }

        private void diplayadd_Click(object sender, EventArgs e)
        {
            textBox1.Text +=  damagetext.Text + "\r\n";
            int gg = 0;
        }
        tjt tt = null;
        private void display_Click(object sender, EventArgs e)
        {
            resstruct[,] icefairy = yyfx.dmgcodetodata(textBox1.Text);
            
            if ( tt == null || tt.IsDisposed)
            {
                tt = new tjt(icefairy, 0);
                tt.Show();
            }
            else
            {
                tt.Activate();
            }
        }

        private void display1_Click(object sender, EventArgs e)
        {
            resstruct[,] icefairy = yyfx.dmgcodetodata(textBox1.Text);
            if (tt == null || tt.IsDisposed)
            {
                tt = new tjt(icefairy, 1);
                tt.Show();
            }
            else
            {
                tt.Activate();
            }
        }
    }
}
