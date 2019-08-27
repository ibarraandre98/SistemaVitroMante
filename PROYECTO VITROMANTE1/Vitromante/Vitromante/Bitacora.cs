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
    public partial class Bitacora : Form
    {
        int valor = 0;
        public Bitacora()
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
        private void MostrarBitacora()
        {
            Cursor.Current = Cursors.WaitCursor;
            var cn = new CN_Clientes();
            DBitacora.DataSource = cn.MBitacora();
            Cursor.Current = Cursors.Default;
        }
        private void MostrarPorFechaBitacora(String Fecha)
        {
            Cursor.Current = Cursors.WaitCursor;
            var cn = new CN_Clientes();
            DBitacora.DataSource = cn.MFBitacora(Fecha);
            Cursor.Current = Cursors.Default;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Bitacora_Load(object sender, EventArgs e)
        {
            MostrarBitacora();
        }

        private void fpp_ValueChanged(object sender, EventArgs e)
        {
            MostrarPorFechaBitacora(Convert.ToString(fpp.Value.ToShortDateString()));
            valor = 1;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MostrarBitacora();
            valor = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            String fechabit;
            if (valor == 0)
            {
                fechabit = "Historial completo";
            }
            else
            {
                fechabit = "Fecha: "+fpp.Value.ToLongDateString();
            }
            try
            {
                if (DBitacora.Rows.Count > 0)
                {
                    DGVPrinter printer = new DGVPrinter();
                    String hora, fecha;
                    hora = DateTime.Now.ToLongTimeString();
                    fecha = DateTime.Now.ToLongDateString();
                    printer.Title = "VITROMANTE";
                    printer.SubTitle = fecha + "\n" + hora + "\nBitacora \n"+fechabit;
                    printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    printer.PageNumbers = true;
                    printer.PageNumberInHeader = true;
                    printer.PorportionalColumns = true;
                    printer.HeaderCellAlignment = StringAlignment.Near;
                    printer.Footer = "Calle Manuel González #416, Zona Centro, CP.89800, El Mante\nTel.(831) 232-1788";
                    printer.FooterSpacing = 15;
                    printer.PrintDataGridView(DBitacora);
                    MessageBox.Show("¡Impresion exitosa! ", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("¡La tabla se encuentra vacia, debe llenarla con algun dato!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("¡Ha ocurrido un error! " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
            Cursor.Current = Cursors.Default;
        }

        private void DBitacora_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
