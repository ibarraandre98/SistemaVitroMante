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
    public partial class LoginBitacora : Form
    {
        public LoginBitacora()
        {
            InitializeComponent();
        }

        private void btnacceder_Click(object sender, EventArgs e)
        {
            if (usuario.Text.ToLower() == "admin" && contra.Text == "1234")
            {
                Cursor.Current = Cursors.WaitCursor;
                var bit = new Bitacora();
                MessageBox.Show("¡Ingreso correcto!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bit.ShowDialog();
                Cursor.Current = Cursors.Default;
                this.Close();
            }
            else
            {
                MessageBox.Show("¡El usuario y/o la contraseña son incorrectos!", "Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void usuario_Enter(object sender, EventArgs e)
        {
            if (usuario.Text == "USUARIO")
            {
                usuario.Text = "";
            }
        }

        private void usuario_Leave(object sender, EventArgs e)
        {
            if (usuario.Text == "")
            {
                usuario.Text = "USUARIO";
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

        private void contra_Leave(object sender, EventArgs e)
        {
            if (contra.Text == "")
            {
                contra.Text = "CONTRASEÑA";
                contra.UseSystemPasswordChar = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("¡Contacte al administrador del programa para que le proporcione la contraseña!","Contraseña olvidada",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }
    }
}
