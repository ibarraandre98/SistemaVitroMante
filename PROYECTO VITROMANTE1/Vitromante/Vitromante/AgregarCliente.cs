using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace Vitromante
{

    public partial class AgregarCliente : Form
    {
        CN_Clientes objetoCN = new CN_Clientes();
        private string idd = null;
        private Boolean ed = false;
        
        public AgregarCliente()
        {
            InitializeComponent();
        }
        private void MostrarClientes()
        {
            CN_Clientes MostrarUnaVez = new CN_Clientes();
            dataGridView1.DataSource = MostrarUnaVez.MostrarClientes();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nombre.Text.Equals("") || app.Text.Equals("")|| (nombre.Text.Equals("") && app.Text.Equals("")))
            {
                MessageBox.Show("¡Debe de ingresar al menos un nombre y un apellido!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (ed == false)
                {
                    try
                    {
                        objetoCN.insertar(nombre.Text, app.Text, apm.Text, calle.Text, numcasa.Text, col.Text, codpos.Text, ciudad.Text, estado.Text, tel.Text, email.Text);
                        MessageBox.Show("¡Se ha agregado cliente con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarClientes();
                        nombre.Text = "";
                        app.Text = "";
                        apm.Text = "";
                        calle.Text = "";
                        numcasa.Text = "";
                        col.Text = "";
                        codpos.Text = "";
                        ciudad.Text = "";
                        estado.Text = "";
                        tel.Text = "";
                        email.Text = "";
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("¡Ha ocurrido un error! "+ exc, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                if (ed == true)
                {
                    try
                    {
                        objetoCN.editar(idd, nombre.Text, app.Text, apm.Text, calle.Text, numcasa.Text, col.Text, codpos.Text, ciudad.Text, estado.Text, tel.Text, email.Text);
                        MessageBox.Show("¡Se ha editado correctamente el cliente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarClientes();
                        ed = false;
                        idd = null;
                        nombre.Text = "";
                        app.Text = "";
                        apm.Text = "";
                        calle.Text = "";
                        numcasa.Text = "";
                        col.Text = "";
                        codpos.Text = "";
                        ciudad.Text = "";
                        estado.Text = "";
                        tel.Text = "";
                        email.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("¡No se pudieron editar los datos !"+ ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }
        private void AgregarCliente_Load(object sender, EventArgs e)
        {
            MostrarClientes();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void editar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ed = true;
                idd= dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                nombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                app.Text = dataGridView1.CurrentRow.Cells["Apellido_Paterno"].Value.ToString();
                apm.Text = dataGridView1.CurrentRow.Cells["Apellido_Materno"].Value.ToString();
                calle.Text = dataGridView1.CurrentRow.Cells["Calle"].Value.ToString();
                numcasa.Text = dataGridView1.CurrentRow.Cells["NumCasa"].Value.ToString();
                col.Text = dataGridView1.CurrentRow.Cells["Colonia"].Value.ToString();
                codpos.Text = dataGridView1.CurrentRow.Cells["Codigo_Postal"].Value.ToString();
                ciudad.Text = dataGridView1.CurrentRow.Cells["Ciudad"].Value.ToString();
                estado.Text = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
                tel.Text = dataGridView1.CurrentRow.Cells["Telefono"].Value.ToString();
                email.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
            }
            else
            {
                MessageBox.Show("¡No ha elegido a ningun cliente para modificar!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void eli_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    if(MessageBox.Show("¿Esta seguro de eliminar el cliente?","Eliminar cliente",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                    {
                        idd = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                        objetoCN.eliminar(idd);
                        MessageBox.Show("¡Se ha eliminado el cliente con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarClientes();
                    }
                    else
                    {
                        MessageBox.Show("¡No se ha eliminado el cliente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show("¡Ha ocurrido un error! "+ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                
            }
            else
            {
                MessageBox.Show("¡No ha elegido a ningun cliente para eliminar!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                dataGridView1.CurrentCell = null;
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    r.Visible = false;
                }
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    r.Visible = false;
                }
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell c in r.Cells)
                    {
                        if ((c.Value.ToString().ToUpper()).IndexOf(textBox1.Text.ToUpper()) == 0)
                        {
                            r.Visible = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                MostrarClientes();
            }
        }
    }
}
