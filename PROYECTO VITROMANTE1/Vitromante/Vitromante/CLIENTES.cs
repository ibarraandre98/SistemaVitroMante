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
using DGVPrinterHelper;

namespace Vitromante
{
    public partial class CLIENTES : Form
    {
        CN_Clientes objetoCN = new CN_Clientes();
        private string idd = null;
        private Boolean ed = false;
        public CLIENTES()
        {
            InitializeComponent();
        }
        private void MostrarClientes()
        {
            CN_Clientes MostrarUnaVez = new CN_Clientes();
            dataGridView1.DataSource = MostrarUnaVez.MostrarClientes();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (nombre.Text.Equals("") || app.Text.Equals("") || (nombre.Text.Equals("") && app.Text.Equals("")))
            {
                MessageBox.Show("¡Debe de ingresar al menos un nombre y un apellido!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (ed == false)
                {
                    try
                    {
                        objetoCN.insertar(nombre.Text, app.Text, apm.Text, calle.Text, numcasa.Text, col.Text, codpos.Text, ciudad.Text, estado.Text, tel.Text, email.Text);
                        MessageBox.Show("¡Se ha agregado cliente con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor.Current = Cursors.WaitCursor;
                        MostrarClientes();
                        Cursor.Current = Cursors.Default;
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
                        MessageBox.Show("¡Se ha editado correctamente el cliente!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button1.Text = "Agregar";
                        Cursor.Current = Cursors.WaitCursor;
                        MostrarClientes();
                        Cursor.Current = Cursors.Default;
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
                        MessageBox.Show("¡No se pudieron editar los datos! "+ ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            hora.Text = DateTime.Now.ToString("hh:mm");
            fecha.Text = DateTime.Now.ToShortDateString();
        }

        private void hora_Click(object sender, EventArgs e)
        {

        }

        private void fecha_Click(object sender, EventArgs e)
        {

        }

        private void maxi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            res.Visible = true;
            maxi.Visible = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void res_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            maxi.Visible = true;
            res.Visible = false;
        }

        private void mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    if (MessageBox.Show("¿Esta seguro de eliminar el cliente?", "Eliminar cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        idd = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                        objetoCN.eliminar(idd);
                        MessageBox.Show("¡Se ha eliminado el cliente con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor.Current = Cursors.WaitCursor;
                        MostrarClientes();
                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {
                        MessageBox.Show("¡No se ha eliminado el cliente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("¡Ha ocurrido un error! "+ ex, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            else
            {
                MessageBox.Show("¡No ha elegido a ningun cliente para eliminar!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Cursor.Current = Cursors.Default;
        }

        private void CLIENTES_Load(object sender, EventArgs e)
        {
                MostrarClientes();
        }

        private void eli_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != ""&&textBox1.Text!="Buscar")
            {
                dataGridView1.CurrentCell = null;
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
                            Cursor.Current = Cursors.WaitCursor;
                            r.Visible = true;
                            Cursor.Current = Cursors.Default;
                            break;
                        }
                    }
                }
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                MostrarClientes();
                Cursor.Current = Cursors.Default;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ed = true;
                idd = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                nombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                app.Text = dataGridView1.CurrentRow.Cells["Apellido Paterno"].Value.ToString();
                apm.Text = dataGridView1.CurrentRow.Cells["Apellido Materno"].Value.ToString();
                calle.Text = dataGridView1.CurrentRow.Cells["Calle"].Value.ToString();
                numcasa.Text = dataGridView1.CurrentRow.Cells["NumCasa"].Value.ToString();
                col.Text = dataGridView1.CurrentRow.Cells["Colonia"].Value.ToString();
                codpos.Text = dataGridView1.CurrentRow.Cells["Codigo Postal"].Value.ToString();
                ciudad.Text = dataGridView1.CurrentRow.Cells["Ciudad"].Value.ToString();
                estado.Text = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
                tel.Text = dataGridView1.CurrentRow.Cells["Telefono"].Value.ToString();
                email.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
                button1.Text = "Actualizar";
            }
            else
            {
                MessageBox.Show("¡No ha elegido a ningun cliente para modificar!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Cursor.Current = Cursors.Default;
        }

        private void tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }

        private void numcasa_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }

        private void codpos_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
                textBox1.Clear();
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = "Buscar";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void tel_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (dataGridView1.Rows.Count > 0)
            {
                DGVPrinter printer = new DGVPrinter();
                String hora, fecha;
                hora = DateTime.Now.ToLongTimeString();
                fecha = DateTime.Now.ToLongDateString();
                printer.Title = "VITROMANTE";
                printer.SubTitle = fecha + "\n" + hora + "\nClientes";
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = true;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "Calle Manuel González #416, Zona Centro, CP.89800, El Mante\nTel.(831) 232-1788";
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(dataGridView1);
            }
            else
            {
                MessageBox.Show("¡La tabla se encuentra vacia, debe llenarla con algun dato!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            Cursor.Current = Cursors.Default;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
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
            Cursor.Current = Cursors.Default;
        }
    }
}
