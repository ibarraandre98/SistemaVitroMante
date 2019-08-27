using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using DGVPrinterHelper;

namespace Vitromante
{
    public partial class BuscarPedidos : Form
    {
        int valorped = 0;
        String ncliente,direccion, telefono,fechaclientepedido,fechaclienteentrega;
        private SqlConnection Conexion = new SqlConnection("Data Source=.;Initial Catalog=ProyectoVitromanteEjemplo1;Integrated Security=True");
        public BuscarPedidos()
        {
            InitializeComponent();
        }
        private void MostrarPedidos()
        {
            CN_Clientes mp = new CN_Clientes();
            Pedidos.DataSource = mp.MPed();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BuscarPedidos_Load(object sender, EventArgs e)
        {
            MostrarPedidos();
        }

        private void fp_ValueChanged(object sender, EventArgs e)
        {
            MostrarFechaPedido(fp.Value.ToLongDateString());
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.Refresh();
            label9.Text = "#";
            tot.Text = "0.00 $";
            valorped = 1;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            MostrarPedidos();
            dataGridView2.Enabled = true;
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.Refresh();
            valorped = 0;
            Cursor.Current = Cursors.WaitCursor;
        }

        private void Pedidos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dataGridView2.Enabled = true;
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.Refresh();
            String IDPed = Pedidos.CurrentRow.Cells["IDPedido"].Value.ToString();
            ncliente= Pedidos.CurrentRow.Cells["Cliente"].Value.ToString();
            direccion= Pedidos.CurrentRow.Cells["Domicilio"].Value.ToString();
            telefono= Pedidos.CurrentRow.Cells["Telefono"].Value.ToString();
            fechaclientepedido= Pedidos.CurrentRow.Cells["FechaPedido"].Value.ToString();
            fechaclienteentrega= Pedidos.CurrentRow.Cells["FechaEntrega"].Value.ToString();
            MostrarPedidosInfo(IDPed);
            double total = 0;
            label9.Text = "#" + IDPed;
            foreach (DataGridViewRow item1 in dataGridView2.Rows)
            {
                int canti = Convert.ToInt32(item1.Cells["Cantidad"].Value);
                double suma = Convert.ToDouble(item1.Cells["Precio"].Value);
                double tota = suma * canti;
                total = total + tota;
            }
            tot.Text = Convert.ToString(total) + " $";
            Cursor.Current = Cursors.Default;
        }
        private void MostrarPedidosInfo(String idped)
        {
            Conexion.Open();
            SqlCommand com = new SqlCommand("Select IDProducto,Producto,Precio,Cantidad  from Pedidos where IDPedido=" + idped, Conexion);
            SqlDataAdapter ada = new SqlDataAdapter(com);
            DataTable tabped = new DataTable();
            ada.Fill(tabped);
            dataGridView2.DataSource = tabped;
            Conexion.Close();
        }
        private void MostrarFechaPedido(String fechap)
        {
            Conexion.Open();
            SqlCommand com = new SqlCommand("Select Distinct IDPedido, Cliente, Domicilio, FechaPedido, FechaEntrega, Telefono from Pedidos where FechaPedido='"+fechap+"' order by IDPedido", Conexion);
            SqlDataAdapter ada = new SqlDataAdapter(com);
            DataTable tabped = new DataTable();
            ada.Fill(tabped);
            Pedidos.DataSource = tabped;
            Conexion.Close();
        }
        private void MostrarFechaEntrega(String fechae)
        {
            Conexion.Open();
            SqlCommand com = new SqlCommand("Select Distinct IDPedido, Cliente, Domicilio, FechaPedido, FechaEntrega, Telefono from Pedidos where FechaEntrega='" + fechae + "' order by IDPedido", Conexion);
            SqlDataAdapter ada = new SqlDataAdapter(com);
            DataTable tabped = new DataTable();
            ada.Fill(tabped);
            Pedidos.DataSource = tabped;
            Conexion.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("¡Debe seleccionar un pedido!", "Seleccione pedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (MessageBox.Show("¿Esta seguro de eliminar el pedido?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int IDPedido = Convert.ToInt32(Pedidos.CurrentRow.Cells["IDPedido"].Value.ToString());
                    CN_Clientes edpedi = new CN_Clientes();

                    foreach (DataGridViewRow item1 in dataGridView2.Rows)
                    {
                        edpedi.EditarPedido(Convert.ToString(item1.Cells["IDProducto"].Value), Convert.ToInt32(item1.Cells["Cantidad"].Value), Convert.ToString(item1.Cells["Producto"].Value));
                    }
                    foreach (DataGridViewRow item in dataGridView2.Rows)
                    {
                        edpedi.EliminarPedido(IDPedido);
                    }
                    MessageBox.Show("¡Pedido eliminado con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView2.DataSource = null;
                    dataGridView2.Rows.Clear();
                    dataGridView2.Columns.Clear();
                    dataGridView2.Refresh();
                    dataGridView2.Columns.Add("IDProducto", "IDProducto");
                    dataGridView2.Columns.Add("Producto", "Producto");
                    dataGridView2.Columns.Add("Precio", "Precio");
                    dataGridView2.Columns.Add("Cantidad", "Cantidad");
                    tot.Text = "0.00 $";
                    label9.Text = "#";
                    MostrarPedidos();
                }
                else
                {
                    MessageBox.Show("¡Ha cancelado la eliminacion!", "Cancelacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
                
            Cursor.Current = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            String fechaped;
            if (valorped == 0) fechaped = "Historial completo";
            else if (valorped == 1) fechaped = "Fecha Pedido: " + fp.Value.ToLongDateString();
            else fechaped = "Fecha Entrega: " + dateTimePicker1.Value.ToLongDateString();
            if (Pedidos.Rows.Count > 0)
            {
                DGVPrinter printer = new DGVPrinter();
                String hora, fecha;
                hora = DateTime.Now.ToLongTimeString();
                fecha = DateTime.Now.ToLongDateString();
                printer.Title = "VITROMANTE";
                printer.SubTitle = fecha + "\n" + hora + "\nPEDIDOS\n"+fechaped;
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = true;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "Calle Manuel González #416, Zona Centro, CP.89800, El Mante\nTel.(831) 232-1788";
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(Pedidos);
            }
            else
            {
                MessageBox.Show("¡La tabla se encuentra vacia, debe llenarla con algun dato!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            Cursor.Current = Cursors.Default;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            MostrarFechaEntrega(dateTimePicker1.Value.ToLongDateString());
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.Refresh();
            label9.Text = "#";
            tot.Text = "0.00 $";
            valorped = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (dataGridView2.Rows.Count > 0)
            {
                DGVPrinter printer = new DGVPrinter();
                String hora, fecha;
                hora = DateTime.Now.ToLongTimeString();
                fecha = DateTime.Now.ToLongDateString();
                printer.Title = "VITROMANTE";
                printer.SubTitle = "NOTA DE PEDIDO\nPedido:" + label9.Text + "\nCliente: " +
                    ncliente + " Direccion: " + direccion + "\nFecha Pedido: " + fechaclientepedido + "\nFecha Entrega: " + fechaclienteentrega
                    + "\nTelefono: " + telefono + "\nTotal: " + tot.Text + "\n";
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;

                printer.PageNumbers = true;
                printer.PageNumberInHeader = true;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "Calle Manuel González #416, Zona Centro, CP.89800, El Mante\nTel.(831) 232-1788\nGenerado: " + fecha + " , " + hora;
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(dataGridView2);
            }
            else
            {
                MessageBox.Show("¡La tabla se encuentra vacia, debe llenarla con algun dato!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
