using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using CapaNegocio;
using DGVPrinterHelper;

namespace Vitromante
{
    public partial class PagosIngresos : Form
    {
        private int edicionPag = 0;
        private int edicionIng = 0;
        private String idPag = null;
        private String idIng = null;
        private String ideliPag = null;
        private String ideliIng = null;
        int valorpag = 0;
        int valoring = 0;
        private SqlConnection Conexion = new SqlConnection("Data Source=.;Initial Catalog=ProyectoVitromanteEjemplo1;Integrated Security=True");
        CN_Clientes cn = new CN_Clientes();
        public PagosIngresos()
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception ex)
            {
                MessageBox.Show("¡Ha ocurrido un error! " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dispose();
            
        }
        public bool solonumeros(int code)
        {
            bool resultado;
            if (code == 46 && MontoPag.Text.Contains("."))//se evalua si es punto y si es punto se rebiza si ya existe en el textbox
            {
                resultado = true;
            }
            else if ((((code >= 48) && (code <= 57)) || (code == 8) || code == 46)) //se evaluan las teclas validas
            {
                resultado = false;
            }
            else
            {
                resultado = true;
            }

            return resultado;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = solonumeros(Convert.ToInt32(e.KeyChar));
        }
        private void MostrarPagos()
        {
            cn = new CN_Clientes();
            DPagos.DataSource = cn.MostrarPagos();
        }
        private void MostrarIngresos()
        {
            var cnn = new CN_Clientes();
            DIngresos.DataSource = cnn.MostrarIngresos();
        }

        private void PagosIngresos_Load(object sender, EventArgs e)
        {
            MostrarPagos();
            MostrarIngresos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if ((DescripcionPag.Text.Equals("") || MontoPag.Text.Equals("")) || (DescripcionPag.Text.Equals("") && MontoPag.Text.Equals("")))
                {
                    MessageBox.Show("¡No debe haber espacios en blanco!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (edicionPag == 0)
                    {
                        cn.InsertarPagos(DescripcionPag.Text, MontoPag.Text, FechaPag.Text);
                        MessageBox.Show("¡Pago insertado con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarPagos();
                        DescripcionPag.Text = "";
                        MontoPag.Text = "";
                        FechaPag.Value = DateTime.Now;
                        DescripcionPag.Focus();
                    }
                    else
                    {
                        cn.EditarPagos(idPag, DescripcionPag.Text, MontoPag.Text, FechaPag.Text);
                        MessageBox.Show("¡Pago editado con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarPagos();
                        edicionPag = 0;
                        idPag = null;
                        BGuardarPag.Text = "Guardar";
                        DescripcionPag.Text = "";
                        MontoPag.Text = "";
                        FechaPag.Value = DateTime.Now;
                        DescripcionPag.Focus();
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (System.FormatException)
            {
                MessageBox.Show("¡Ingrese cantidades correctas!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch(Exception ex)
            {
                MessageBox.Show("¡Ha ocurrido un error! "+ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }

        private void Pagos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Pagos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            edicionPag = 1;
            BGuardarPag.Text = "Actualizar";
            idPag = DPagos.CurrentRow.Cells["ID"].Value.ToString();
            DescripcionPag.Text = DPagos.CurrentRow.Cells["Descripcion"].Value.ToString();
            MontoPag.Text= DPagos.CurrentRow.Cells["Monto"].Value.ToString();
            FechaPag.Value= Convert.ToDateTime(DPagos.CurrentRow.Cells["Fecha"].Value.ToString());
            Cursor.Current = Cursors.Default;
        }

        private void Pagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ideliPag= DPagos.CurrentRow.Cells["ID"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (DPagos.Rows.Count == 0)
            {
                MessageBox.Show("¡No puede eliminar ya que no existen registros!", "Vacio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (MessageBox.Show("¿Esta seguro de eliminar el pedido?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (ideliPag == null)
                        {
                            MessageBox.Show("¡Haga click en un registro y seguidamente eliminelo!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            cn.EliminarPagos(ideliPag);
                            MessageBox.Show("¡Ha eliminado el registro con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MostrarPagos();
                            DescripcionPag.Focus();
                            if (edicionPag == 1)
                            {
                                edicionPag = 0;
                                BGuardarPag.Text = "Guardar";
                                DescripcionPag.Text = "";
                                MontoPag.Text = "";
                                FechaPag.Value = DateTime.Now;
                            }
                            ideliPag = null;
                        }
                        Cursor.Current = Cursors.Default;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("¡Ha ocurrido un error! "+ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("¡Ha cancelado la eliminacion!", "Cancelacion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
        }

        private void fpp_ValueChanged(object sender, EventArgs e)
        {
            if (BFechaPag.Text != "")
            {
                valorpag = 1;
                DPagos.CurrentCell = null;
                foreach (DataGridViewRow r in DPagos.Rows)
                {
                    r.Visible = false;
                }
                foreach (DataGridViewRow r in DPagos.Rows)
                {
                    foreach (DataGridViewCell c in r.Cells)
                    {
                        if ((c.Value.ToString().ToUpper()).IndexOf(BFechaPag.Text.ToUpper()) == 0)
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
                MostrarPagos();
                Cursor.Current = Cursors.Default;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            MostrarPagos();
            valorpag = 0;
            Cursor.Current = Cursors.Default;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            MostrarIngresos();
            Cursor.Current = Cursors.Default;
        }




        private void button2_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if ((DescripcionIng.Text.Equals("") || MontoIng.Text.Equals("")) || (DescripcionIng.Text.Equals("") && MontoIng.Text.Equals("")))
                {
                    MessageBox.Show("¡No debe haber espacios en blanco!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (edicionIng == 0)
                    {
                        cn.InsertarIngresos(DescripcionIng.Text, MontoIng.Text, FechaIng.Text);
                        MessageBox.Show("¡Ingreso insertado con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarIngresos();
                        DescripcionIng.Text = "";
                        MontoIng.Text = "";
                        FechaIng.Value = DateTime.Now;
                        DescripcionIng.Focus();
                    }
                    else
                    {
                        cn.EditarIngresos(idIng, DescripcionIng.Text, MontoIng.Text, FechaIng.Text);
                        MessageBox.Show("¡Ingreso editado con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarIngresos();
                        edicionIng = 0;
                        idIng = null;
                        BGuardarIng.Text = "Guardar";
                        DescripcionIng.Text = "";
                        MontoIng.Text = "";
                        FechaIng.Value = DateTime.Now;
                        DescripcionIng.Focus();
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (System.FormatException)
            {
                MessageBox.Show("¡Ingrese cantidades correctas!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡Ha ocurrido un error! " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void DIngresos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ideliIng = DIngresos.CurrentRow.Cells["ID1"].Value.ToString();
        }

        private void DIngresos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            edicionIng = 1;
            BGuardarIng.Text = "Actualizar";
            idIng = DIngresos.CurrentRow.Cells["ID1"].Value.ToString();
            DescripcionIng.Text = DIngresos.CurrentRow.Cells["Descripcion1"].Value.ToString();
            MontoIng.Text = DIngresos.CurrentRow.Cells["Monto1"].Value.ToString();
            FechaIng.Value = Convert.ToDateTime(DIngresos.CurrentRow.Cells["Fecha1"].Value.ToString());
            Cursor.Current = Cursors.Default;
        }
        public bool solonumeros1(int code)
        {
            bool resultado;
            if (code == 46 && MontoIng.Text.Contains("."))//se evalua si es punto y si es punto se rebiza si ya existe en el textbox
            {
                resultado = true;
            }
            else if ((((code >= 48) && (code <= 57)) || (code == 8) || code == 46)) //se evaluan las teclas validas
            {
                resultado = false;
            }
            else
            {
                resultado = true;
            }

            return resultado;
        }
        private void MontoIng_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = solonumeros1(Convert.ToInt32(e.KeyChar));
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (BFechaIng.Text != "")
            {
                DIngresos.CurrentCell = null;
                foreach (DataGridViewRow r in DIngresos.Rows)
                {
                    r.Visible = false;
                }
                foreach (DataGridViewRow r in DIngresos.Rows)
                {
                    foreach (DataGridViewCell c in r.Cells)
                    {
                        if ((c.Value.ToString().ToUpper()).IndexOf(BFechaIng.Text.ToUpper()) == 0)
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
                MostrarIngresos();
                Cursor.Current = Cursors.Default;
            }
        }

        private void BEliminarIng_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (DIngresos.Rows.Count == 0)
            {
                MessageBox.Show("¡No puede eliminar ya que no existen registros!", "Vacio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (MessageBox.Show("¿Esta seguro de eliminar el pedido?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (ideliIng == null)
                        {
                            MessageBox.Show("¡Haga click en un registro y seguidamente eliminelo!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            cn.EliminarIngresos(ideliIng);
                            MessageBox.Show("¡Ha eliminado el registro con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MostrarIngresos();
                            DescripcionIng.Focus();
                            if (edicionIng == 1)
                            {
                                edicionIng = 0;
                                BGuardarIng.Text = "Guardar";
                                DescripcionIng.Text = "";
                                MontoIng.Text = "";
                                FechaIng.Value = DateTime.Now;
                            }
                            ideliIng = null;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("¡Ha ocurrido un error! "+ ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("¡Ha cancelado la eliminacion!", "Cancelacion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            Cursor.Current = Cursors.Default;
        }

        private void MontoIng_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                String fechapag;
                if (valorpag == 0)
                {
                    fechapag = "Historial Completo";
                }
                else
                {
                    fechapag = "Fecha: " + BFechaPag.Value.ToLongDateString();
                }

                if (DPagos.Rows.Count > 0)
                {
                    DGVPrinter printer = new DGVPrinter();
                    String hora, fecha;
                    hora = DateTime.Now.ToLongTimeString();
                    fecha = DateTime.Now.ToLongDateString();
                    printer.Title = "VITROMANTE";
                    printer.SubTitle = fecha + "\n" + hora + "\nPagos\n" + fechapag;
                    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    printer.PageNumbers = true;
                    printer.PageNumberInHeader = true;
                    printer.PorportionalColumns = true;
                    printer.HeaderCellAlignment = StringAlignment.Near;
                    printer.Footer = "Calle Manuel González #416, Zona Centro, CP.89800, El Mante\nTel.(831) 232-1788";
                    printer.FooterSpacing = 15;
                    printer.PrintDataGridView(DPagos);
                }
                else
                {
                    MessageBox.Show("¡La tabla se encuentra vacia, debe llenarla con algun dato!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                Cursor.Current = Cursors.Default;
            }
            catch(Exception ex)
            {
                MessageBox.Show("¡Ha ocurrido un error! " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                String fechaing;
                if (valoring == 0)
                {
                    fechaing = "Historial completo";
                }
                else
                {
                    fechaing = "Fecha: " + BFechaIng.Value.ToLongDateString();
                }
                if (DIngresos.Rows.Count > 0)
                {
                    DGVPrinter printer = new DGVPrinter();
                    String hora, fecha;
                    hora = DateTime.Now.ToLongTimeString();
                    fecha = DateTime.Now.ToLongDateString();
                    printer.Title = "VITROMANTE";
                    printer.SubTitle = fecha + "\n" + hora + "\nIngresos\n" + fechaing;
                    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    printer.PageNumbers = true;
                    printer.PageNumberInHeader = true;
                    printer.PorportionalColumns = true;
                    printer.HeaderCellAlignment = StringAlignment.Near;
                    printer.Footer = "Calle Manuel González #416, Zona Centro, CP.89800, El Mante\nTel.(831) 232-1788";
                    printer.FooterSpacing = 15;
                    printer.PrintDataGridView(DIngresos);
                }
                else
                {
                    MessageBox.Show("¡La tabla se encuentra vacia, debe llenarla con algun dato!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡Ha ocurrido un error! " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }
    }
}
