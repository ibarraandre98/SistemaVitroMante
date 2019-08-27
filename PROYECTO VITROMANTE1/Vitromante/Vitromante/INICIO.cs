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
    public partial class INICIO : Form
    {
        public INICIO()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar el sistema?", "Finalizar sesion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("¡Salida exitosa!", "Finalizar sesion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            else
            {
                MessageBox.Show("¡Ha cancelado la salida del sistema!", "Cancelacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            res.Visible = true;
            maxi.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            hora.Text = DateTime.Now.ToString("hh:mm");
            fecha.Text = DateTime.Now.ToShortDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CLIENTES cli = new CLIENTES();
            Cursor.Current = Cursors.WaitCursor;
            cli.Show();
            Cursor.Current = Cursors.Default;
        }

        private void res_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            maxi.Visible = true;
            res.Visible = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form existe = Application.OpenForms.OfType<Form>().Where(pre => pre.Name == "Productos").SingleOrDefault<Form>();
            if (existe != null)
            {
                existe.WindowState = FormWindowState.Normal;
                existe.BringToFront();
            }
            else
            {
                Productos pro = new Productos();
                Cursor.Current = Cursors.WaitCursor;
                pro.ShowDialog(); //Para bloquear todo lo demas y solo dejar en funcionamiento el formulario
                Cursor.Current = Cursors.Default;
                
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrincipalPedidos ped = new PrincipalPedidos();
            ped.Show();
        }

        private void hora_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var pi = new PagosIngresos();
            pi.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var lb = new LoginBitacora();
            lb.ShowDialog();
        }
        private void pendientes()
        {
            CN_Clientes obj = new CN_Clientes();
            DataTable dt = new DataTable();
            listView1.Clear();
            dt = obj.MPed1(Convert.ToString(DateTime.Now.ToLongDateString()));
            listView1.View = View.Tile;
            int cont = 1;
            if (dt.Rows.Count == 0)
            {
                ListViewGroup pedido = new ListViewGroup("Pedidos", HorizontalAlignment.Left);
                listView1.Items.Add(new ListViewItem("¡No hay ningun pedido para el dia de hoy!", pedido));
                listView1.Groups.Add(pedido);
            }
            else
            {
                foreach (DataRow item in dt.Rows)
                {
                    ListViewGroup pedido = new ListViewGroup("Pedido #" + cont, HorizontalAlignment.Left);
                    listView1.Items.Add(new ListViewItem("IDPedido: " + Convert.ToString(item["IDPedido"]), pedido));
                    listView1.Items.Add(new ListViewItem("Cliente: " + Convert.ToString(item["Cliente"]), pedido));
                    listView1.Items.Add(new ListViewItem("Domicilio: " + Convert.ToString(item["Domicilio"]), pedido));
                    listView1.Items.Add(new ListViewItem("Fecha Pedido: " + Convert.ToString(item["FechaPedido"]), pedido));
                    listView1.Items.Add(new ListViewItem("Telefono: " + Convert.ToString(item["Telefono"]), pedido));
                    DataTable dt2 = new DataTable();
                    dt2.Clear();
                    dt2 = obj.MPedInfo1(Convert.ToString(item["IDPedido"]));
                    int cont2 = 1;
                    foreach (DataRow item1 in dt2.Rows)
                    {
                        listView1.Items.Add(new ListViewItem("Producto #" + cont2, pedido));
                        listView1.Items.Add(new ListViewItem("IDProducto: " + Convert.ToString(item1["IDProducto"]), pedido));
                        listView1.Items.Add(new ListViewItem("Producto: " + Convert.ToString(item1["Producto"]), pedido));
                        listView1.Items.Add(new ListViewItem("Precio: " + Convert.ToString(item1["Precio"]), pedido));
                        listView1.Items.Add(new ListViewItem("Cantidad: " + Convert.ToString(item1["Cantidad"]), pedido));
                        cont2++;
                    }
                    listView1.Groups.Add(pedido);
                    cont++;
                }
            }
            

            

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void INICIO_Load(object sender, EventArgs e)
        {
            pendientes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pendientes();
        }
    }
}
