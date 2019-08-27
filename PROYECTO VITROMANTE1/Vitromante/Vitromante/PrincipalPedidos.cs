using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vitromante
{
    public partial class PrincipalPedidos : Form
    {
        public PrincipalPedidos()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            hora.Text = DateTime.Now.ToString("hh:mm");
            fecha.Text = DateTime.Now.ToShortDateString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void res_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            maxi.Visible = true;
            res.Visible = false;
        }

        private void maxi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            res.Visible = true;
            maxi.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pedidos ped = new Pedidos();
            Cursor.Current = Cursors.WaitCursor;
            ped.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void maxi_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            res.Visible = true;
            maxi.Visible = false;
        }

        private void res_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            maxi.Visible = true;
            res.Visible = false;
        }

        private void maxi_Click_2(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            maxi.Visible = false;
            res.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BuscarPedidos bp = new BuscarPedidos();
            Cursor.Current = Cursors.WaitCursor;
            bp.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void button1_MouseCaptureChanged(object sender, EventArgs e)
        {

        }
        private void button1_OnMouseLeaveButton(object sender, EventArgs e)
        {
           
        }
    }
}
