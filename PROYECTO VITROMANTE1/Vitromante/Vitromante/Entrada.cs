using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vitromante
{
    public partial class Entrada : Form
    {
        public Entrada()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lineShape1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("¡Contacte al administrador del programa para que le proporcione la contraseña!", "Contraseña olvidada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void btnacceder_Click(object sender, EventArgs e)
        {
            if (usuario.Text.ToLower() == "vitromante" && contra.Text == "muski")
            {
                INICIO ini = new INICIO();
                MessageBox.Show("¡Ha iniciado sesion con exito!","Inicio exitoso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ini.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("El usuario y/o la contraseña son incorrectos", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }

        private void maxi_Click(object sender, EventArgs e)
        {
        }

        private void mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void res_Click(object sender, EventArgs e)
        {
        }

        private void usuario_Enter(object sender, EventArgs e)
        {
            if (usuario.Text == "USUARIO")
            {
                usuario.Text = "";
            }
        }

        private void contra_Enter(object sender, EventArgs e)
        {
            if (contra.Text == "CONTRASEÑA")
            {
                contra.Text = "";
                contra.UseSystemPasswordChar = true;
            }
        }

        private void contra_TextChanged(object sender, EventArgs e)
        {

        }

        private void contra_Leave(object sender, EventArgs e)
        {
            if (contra.Text == "")
            {
                contra.Text = "CONTRASEÑA";
                contra.UseSystemPasswordChar = false;
            }
        }

        private void usuario_Leave(object sender, EventArgs e)
        {
            if (usuario.Text == "")
            {
                usuario.Text = "USUARIO";
            }
        }
        int posX = 0;
        int posY = 0;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }
    }
}
