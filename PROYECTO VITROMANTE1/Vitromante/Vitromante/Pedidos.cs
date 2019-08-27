using System;
using System.Collections;
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
using Microsoft.VisualBasic;
using DGVPrinterHelper;

namespace Vitromante
{
    public partial class Pedidos : Form
    {
        
        static int bandera = 0;
        private SqlConnection Conexion = new SqlConnection("Data Source=.;Initial Catalog=ProyectoVitromanteEjemplo1;Integrated Security=True");
        static double total;
        public static String ClienteID = "";
        ListView lv;

        ArrayList al = new ArrayList();
        ArrayList all = new ArrayList();
        ClasePedidos cp = new ClasePedidos();
        CN_Clientes objetoCN = new CN_Clientes();
        public Pedidos()
        {
            try
            {
                InitializeComponent();
                fe.MinDate = System.DateTime.Now;
                fp.Value = System.DateTime.Now;
                busq.SelectedIndex = 0;
                pedmax();
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡Ha ocurrido un error! " + ex, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }
       
        private void MostrarPedidosInfo(String idped)
        {
            Cursor.Current = Cursors.WaitCursor;
            Conexion.Open();
            lv = new ListView();
            al = new ArrayList();
            SqlCommand com = new SqlCommand("Select IDProducto,Producto,Precio,Cantidad  from Pedidos where IDPedido=" + idped, Conexion);
            SqlDataReader sdr;
            sdr = com.ExecuteReader();
            DataTable tabped = new DataTable();
            DataTable tabped4 = new DataTable();
            while (sdr.Read())
            {
                al.Add(new ClasePedidos(sdr.GetValue(0).ToString(), sdr.GetValue(1).ToString(), Convert.ToDouble(sdr.GetValue(2)), Convert.ToInt32(sdr.GetValue(3))));
            }
            dataGridView2.DataSource = al;
            Conexion.Close();
            Conexion.Open();
            SqlCommand com1 = new SqlCommand("Select IDProducto,Producto,Precio,Cantidad  from Pedidos where IDPedido=" + idped, Conexion);
            SqlDataAdapter ada = new SqlDataAdapter(com1);
            ada.Fill(tabped4);
            dataGridView4.DataSource = tabped4;
            Conexion.Close();
            Cursor.Current = Cursors.Default;
        }
        private void MostrarPedidos()
        {
            CN_Clientes MPedido = new CN_Clientes();
            dataGridView3.DataSource = MPedido.MPed();
        }
        private void MostrarClientes()
        {
            CN_Clientes MostrarUnaVez = new CN_Clientes();
            clientes.DataSource = MostrarUnaVez.MostrarClientes();
            foreach (DataGridViewColumn Col in dataGridView1.Columns)
            {
                Col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void MostrarProductos()
        {
            CN_Clientes MostrarUnaVez = new CN_Clientes();
            dataGridView1.DataSource = MostrarUnaVez.MostrarProductos();
        }
        private void BusquedaProductos(String BDato, String opc)
        {
            CN_Clientes BProd = new CN_Clientes();
            Cursor.Current = Cursors.WaitCursor;
            dataGridView1.DataSource = BProd.BProd(BDato, opc);
            Cursor.Current = Cursors.Default;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void pedmax()
        {
            label9.Text = "#" + Convert.ToString(objetoCN.pedmax());
        }
        private int pedidomax()
        {
            return objetoCN.pedmax();
        }
        private void Pedidos_Load(object sender, EventArgs e)
        {
            MostrarProductos();
            MostrarClientes();
            MostrarPedidos();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != "Buscar")
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
                dataGridView1.CurrentCell = null;
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    r.Visible = false;
                }
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell c in r.Cells)
                    {
                            Cursor.Current = Cursors.WaitCursor;
                            r.Visible = true;
                            Cursor.Current = Cursors.Default;
                    }
                }
                Cursor.Current = Cursors.Default;
            }
        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((!textBox2.Text.Equals("") || !textBox4.Text.Equals("")) && (!textBox2.Text.Equals("") && !textBox4.Text.Equals("")))
                {
                    if (dataGridView2.Rows.Count == 0)
                    {
                        MessageBox.Show("¡No se puede realizar ninguna operacion si la tabla esta vacia!", "Vacio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else { 
                    Cursor.Current = Cursors.WaitCursor;
                    if (bandera == 0)
                    {
                        int IDPedido = pedidomax();
                        CN_Clientes pedi = new CN_Clientes();
                        foreach (DataGridViewRow item in dataGridView2.Rows)
                        {
                            pedi.hacerpedido(Convert.ToString(IDPedido), textBox2.Text, textBox4.Text, Convert.ToString(item.Cells["IDProducto"].Value), Convert.ToString(item.Cells["Producto"].Value), Convert.ToString(item.Cells["Precio"].Value), textBox5.Text, fp.Text, fe.Text, Convert.ToString(item.Cells["Cantidad"].Value));
                        }
                            MessageBox.Show("¡Se ha realizado el pedido con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (MessageBox.Show("¿Desea imprimir la nota?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                realizarimpresion();
                            }
                            else
                            {

                            }
                            } else if (bandera == 1)
                    {
                        int IDPedido = Convert.ToInt32(dataGridView3.CurrentRow.Cells["IDPedido"].Value.ToString());
                        CN_Clientes edpedi = new CN_Clientes();

                        foreach (DataGridViewRow item1 in dataGridView4.Rows)
                        {
                            edpedi.EditarPedido(Convert.ToString(item1.Cells["IDProducto1"].Value), Convert.ToInt32(item1.Cells["Cantidad1"].Value), Convert.ToString(item1.Cells["Producto1"].Value));
                        }
                        foreach (DataGridViewRow item in dataGridView2.Rows)
                        {
                            edpedi.EliminarPedido(IDPedido);
                        }
                        foreach (DataGridViewRow item in dataGridView2.Rows)
                        {
                            edpedi.hacerpedido(Convert.ToString(IDPedido), textBox2.Text, textBox4.Text, Convert.ToString(item.Cells["IDProducto"].Value), Convert.ToString(item.Cells["Producto"].Value), Convert.ToString(item.Cells["Precio"].Value), textBox5.Text, fp.Text, fe.Text, Convert.ToString(item.Cells["Cantidad"].Value));
                        }
                            MessageBox.Show("¡Pedido editado con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (MessageBox.Show("¿Desea imprimir la nota?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                realizarimpresion();
                            }
                            else
                            {

                            }
                        }

                        dataGridView5.Rows.Clear();
                        bandera = 0;
                    edit.Text = "Agregar";
                    dataGridView2.DataSource = null;
                    dataGridView2.Rows.Clear();
                    dataGridView2.Columns.Clear();
                    dataGridView2.Refresh();
                    dataGridView2.Columns.Add("IDProducto", "IDProducto");
                    dataGridView2.Columns.Add("Producto", "Producto");
                    dataGridView2.Columns.Add("Precio", "Precio");
                    dataGridView2.Columns.Add("Cantidad", "Cantidad");

                    pedmax();
                    textBox2.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    tot.Text = "0.00 $";
                    MostrarProductos();
                    MostrarPedidos();
                    dataGridView2.Enabled = false;
                        al = new ArrayList();
                        Cursor.Current = Cursors.Default;
                }
                }
                else
                {
                    MessageBox.Show("¡No puede dejar espacios en blanco!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("¡No se pudo realizar el pedido! "+ ex, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox3.Text != "Buscar")
            {
                clientes.CurrentCell = null;
                foreach (DataGridViewRow r in clientes.Rows)
                {
                    r.Visible = false;
                }
                foreach (DataGridViewRow r in clientes.Rows)
                {
                    foreach (DataGridViewCell c in r.Cells)
                    {
                        if ((c.Value.ToString().ToUpper()).IndexOf(textBox3.Text.ToUpper()) == 0)
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

        private void textBox3_Enter(object sender, EventArgs e)
        {

        }

        private void clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void clientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            String nombre = clientes.CurrentRow.Cells["Nombre"].Value.ToString();
            String app = clientes.CurrentRow.Cells["Apellido Paterno"].Value.ToString();
            String apm = clientes.CurrentRow.Cells["Apellido Materno"].Value.ToString();
            ClienteID = clientes.CurrentRow.Cells["Id"].Value.ToString();
            String tel = clientes.CurrentRow.Cells["Telefono"].Value.ToString();
            String direccion = clientes.CurrentRow.Cells["Calle"].Value.ToString() + " " + clientes.CurrentRow.Cells["NumCasa"].Value.ToString() + " " + clientes.CurrentRow.Cells["Colonia"].Value.ToString() + " " + clientes.CurrentRow.Cells["Ciudad"].Value.ToString();
            textBox2.Text = nombre + " " + app + " " + apm;
            textBox4.Text = direccion;
            textBox5.Text = tel;
            Cursor.Current = Cursors.Default;
        }

        private void fe_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            al = new ArrayList();
            bandera = 0;
            edit.Text = "Agregar";
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.Refresh();
            dataGridView5.Rows.Clear();
            pedmax();
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            tot.Text = "0.00 $";
            MostrarProductos();
            dataGridView2.Enabled = true;
            foreach (DataGridViewRow item1 in dataGridView2.Rows)
            {
                String codigo = item1.Cells["IDProducto"].Value.ToString();
                String producto = item1.Cells["Producto"].Value.ToString();
                int ca = Convert.ToInt32(item1.Cells["Cantidad"].Value.ToString());
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    int cantidad2 = Convert.ToInt32(item.Cells["Cantidad"].Value);
                    if (codigo.Equals(item.Cells["ID"].Value))
                    {
                        item.Cells["Cantidad"].Value = cantidad2 - ca;
                    }
                }
            }
            dataGridView2.Columns.Add("IDProducto", "IDProducto");
            dataGridView2.Columns.Add("Producto", "Producto");
            dataGridView2.Columns.Add("Precio", "Precio");
            dataGridView2.Columns.Add("Cantidad", "Cantidad");
            MessageBox.Show("¡Limpiado con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Cursor.Current = Cursors.Default;
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            String codigo = dataGridView2.CurrentRow.Cells["IDProducto"].Value.ToString();
            String producto = dataGridView2.CurrentRow.Cells["Producto"].Value.ToString();
            String prec= dataGridView2.CurrentRow.Cells["Precio"].Value.ToString();
            int ca = Convert.ToInt32(dataGridView2.CurrentRow.Cells["Cantidad"].Value.ToString());
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                int cantidad2 = Convert.ToInt32(item.Cells["Cantidad"].Value);
                if (codigo.Equals(item.Cells["ID"].Value))
                {
                    item.Cells["Cantidad"].Value = cantidad2 + ca;
                }
            }

            Boolean exi = false;
            foreach(DataGridViewRow item in dataGridView5.Rows)
            {
                int cantida= Convert.ToInt32(item.Cells["Cantidad2"].Value);
                if (codigo.Equals(item.Cells["IDProducto2"].Value))
                {
                    item.Cells["Cantidad2"].Value = cantida + ca;
                    exi = true;
                }
            }
            if (exi == false)
            {
                dataGridView5.Rows.Add(codigo,producto,prec,ca);
            }
            

            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.Refresh();
            foreach (ClasePedidos item in al)
            {
                if (codigo.Equals(item.IDProducto))
                {
                    item.IDProducto = null;
                    
                }
            }
            foreach (ClasePedidos item in al)
            {
                all.Add(new ClasePedidos(item.IDProducto, item.Producto, Convert.ToDouble(item.Precio), Convert.ToInt32(item.Cantidad)));
            }
            al.Clear();
            foreach (ClasePedidos item in all)
            {
                if (item.IDProducto==null)
                {

                }
                else
                {
                    al.Add(new ClasePedidos(item.IDProducto,item.Producto,Convert.ToDouble(item.Precio),Convert.ToInt32(item.Cantidad)));
                }
            }
            all.Clear();
            total = 0;
            dataGridView2.DataSource = al;
            foreach (DataGridViewRow item1 in dataGridView2.Rows)
            {
                int canti = Convert.ToInt32(item1.Cells["Cantidad"].Value);
                double suma = Convert.ToDouble(item1.Cells["Precio"].Value);
                double tota = suma * canti;
                total = total + tota;
            }
            tot.Text = Convert.ToString(total) + " $";
            dataGridView2.Refresh();
            Cursor.Current = Cursors.Default;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            al = new ArrayList();
            Cursor.Current = Cursors.WaitCursor;
            dataGridView2.Enabled = true;
            bandera = 1;
            edit.Text = "Editar";
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView2.Refresh();
            dataGridView5.Rows.Clear();
            MostrarProductos();
            /*dataGridView2.Columns[1].HeaderText = "IDProducto";
            dataGridView2.Columns[2].HeaderText = "Producto";
            dataGridView2.Columns[3].HeaderText = "Precio";
            dataGridView2.Columns[4].HeaderText = "Cantidad";*/
            String IDPed = dataGridView3.CurrentRow.Cells["IDPedido"].Value.ToString();
            textBox2.Text = dataGridView3.CurrentRow.Cells["Cliente"].Value.ToString();
            textBox4.Text = dataGridView3.CurrentRow.Cells["Domicilio"].Value.ToString();
            textBox5.Text = dataGridView3.CurrentRow.Cells["Telefono"].Value.ToString();
            MostrarPedidosInfo(IDPed);
            label9.Text = "#" + IDPed;
            fp.Value = Convert.ToDateTime(dataGridView3.CurrentRow.Cells["FechaPedido"].Value.ToString());
            total = 0;
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

        private void fp_ValueChanged(object sender, EventArgs e)
        {

        }

        private void fpp_ValueChanged(object sender, EventArgs e)
        {
            if (fpp.Text != "")
            {
                dataGridView3.CurrentCell = null;
                foreach (DataGridViewRow r in dataGridView3.Rows)
                {
                    r.Visible = false;
                }
                foreach (DataGridViewRow r in dataGridView3.Rows)
                {
                    foreach (DataGridViewCell c in r.Cells)
                    {
                        if ((c.Value.ToString().ToUpper()).IndexOf(fpp.Text.ToUpper()) == 0)
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
                MostrarPedidos();
                Cursor.Current = Cursors.Default;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MostrarPedidos();
        }
        private Boolean saberSiEsNumero(String numero)
        {
            try
            {
                int n = Convert.ToInt32(numero);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Boolean existe = false;
            String codigo = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            String producto = dataGridView1.CurrentRow.Cells["Producto"].Value.ToString();
            String precio = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
            int cantidad = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString());
            if (cantidad == 0)
            {
                MessageBox.Show("¡La cantidad de este articulo es nula!", "Nulo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                String envc = Convert.ToString(Interaction.InputBox("Ingrese cantidad"));
                if (envc == null || envc.Equals("")||envc.Equals("0"))
                {
                    MessageBox.Show("¡Se ha cancelado el envio de unidades!", "Cancelacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (saberSiEsNumero(envc)==false)
                {
                    MessageBox.Show("¡Debe ingresar solamente numeros enteros!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    int envcant = Convert.ToInt32(envc);
                    int cantidad2 = 1;
                    if (cantidad <= 0 || envcant > cantidad)
                    {
                        MessageBox.Show("¡No hay suficiente cantidad!", "Cantidad insuficiencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (envcant <= 0)
                    {
                        MessageBox.Show("¡Error no puede realizar esta accion!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        if (bandera == 0 && dataGridView2.Rows.Count >= 0)
                        {
                            foreach (DataGridViewRow item in dataGridView2.Rows)
                            {
                                cantidad2 = Convert.ToInt32(item.Cells["Cantidad"].Value);
                                if (codigo.Equals(Convert.ToString(item.Cells["IDProducto"].Value)))
                                {
                                    item.Cells["Cantidad"].Value = cantidad2 + envcant;
                                    total = 0;

                                    foreach (DataGridViewRow item1 in dataGridView2.Rows)
                                    {
                                        int canti = Convert.ToInt32(item1.Cells["Cantidad"].Value);
                                        double suma = Convert.ToDouble(item1.Cells["Precio"].Value);
                                        double tota = suma * canti;
                                        total = total + tota;
                                    }
                                    existe = true;
                                }
                            }
                            if (existe == false)
                            {
                                al.Add(new ClasePedidos(codigo, producto, Convert.ToDouble(precio), envcant));
                                dataGridView2.DataSource = null;
                                dataGridView2.Columns.Clear();
                                dataGridView2.Rows.Clear();
                                dataGridView2.DataSource = al;
                                dataGridView2.Refresh();
                                total = 0;

                                foreach (DataGridViewRow item in dataGridView2.Rows)
                                {
                                    int canti = Convert.ToInt32(item.Cells["Cantidad"].Value);
                                    double suma = Convert.ToDouble(item.Cells["Precio"].Value);
                                    double tota = suma * canti;
                                    total = total + tota;
                                }

                            }
                            dataGridView1.CurrentRow.Cells["Cantidad"].Value = cantidad - envcant;
                        }
                        else if (dataGridView2.Rows.Count > 0 && bandera == 1)
                        {
                            DataTable dt2 = new DataTable();
                            DataRow datarow;
                            dt2 = dataGridView2.DataSource as DataTable;
                            Boolean exi = false;
                                foreach (DataGridViewRow item in dataGridView2.Rows)
                                {
                                    if (Convert.ToString(item.Cells["IDProducto"].Value).Equals(codigo))
                                    {
                                        item.Cells["Cantidad"].Value = Convert.ToInt32(item.Cells["Cantidad"].Value) + envcant;
                                        exi = true;
                                    }
                                }
                            if (exi == false)
                            {
                                al.Add(new ClasePedidos(codigo,producto,Convert.ToDouble(precio),envcant));
                                dataGridView2.DataSource = null;
                                dataGridView2.DataSource=al;
                            }
                            dataGridView1.CurrentRow.Cells["Cantidad"].Value = cantidad - envcant;
                        }
                        else if (dataGridView2.Rows.Count == 0 && bandera == 1)
                        {
                            DataTable dt2 = new DataTable();
                            DataRow datarow;
                            dt2 = dataGridView2.DataSource as DataTable;
                            Boolean exi = false;
                            if (dataGridView2.Rows.Count > 0)
                            {
                                foreach (DataRow item in dt2.Rows)
                                {
                                    if (item["IDProducto"].Equals(codigo))
                                    {
                                        item["Cantidad"] = Convert.ToUInt32(item["Cantidad"]) + envcant;
                                        exi = true;
                                    }
                                }
                            }
                            if (exi == false)
                            {
                                dataGridView2.DataSource = null;
                                dataGridView2.Rows.Clear();
                                dataGridView2.Columns.Clear();
                                dataGridView2.Refresh();
                                al.Add(new ClasePedidos(codigo, producto, Convert.ToDouble(precio), envcant));
                                dataGridView2.DataSource = null;
                                dataGridView2.DataSource = al;
                                total = 0;

                                foreach (DataGridViewRow item in dataGridView2.Rows)
                                {
                                    int canti = Convert.ToInt32(item.Cells["Cantidad"].Value);
                                    double suma = Convert.ToDouble(item.Cells["Precio"].Value);
                                    double tota = suma * canti;
                                    total = total + tota;
                                }

                            }
                            dataGridView1.CurrentRow.Cells["Cantidad"].Value = cantidad - envcant;
                        }
                    }
                    total = 0;
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
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (dataGridView2.Rows.Count > 0)
            {
                DGVPrinter printer = new DGVPrinter();
                String hora, fecha;
                hora = DateTime.Now.ToLongTimeString();
                fecha = DateTime.Now.ToLongDateString();
                printer.Title = "VITROMANTE";
                printer.SubTitle = "NOTA DE PEDIDO\nPedido:" + label9.Text+"\nCliente: "+
                    textBox2.Text+" Direccion: " + textBox4.Text+"\nFecha Pedido: " +fp.Text+"\nFecha Entrega: "+fe.Text
                    +"\nTelefono: "+textBox5.Text+"\nTotal: "+tot.Text+"\n";
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                
                printer.PageNumbers = true;
                printer.PageNumberInHeader = true;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "Calle Manuel González #416, Zona Centro, CP.89800, El Mante\nTel.(831) 232-1788\nGenerado: "+fecha + " , " + hora;
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(dataGridView2);
            }
            else
            {
                MessageBox.Show("¡La tabla se encuentra vacia, debe llenarla con algun dato!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            Cursor.Current = Cursors.Default;
        }
        private void realizarimpresion()
        {
            DGVPrinter printer = new DGVPrinter();
            String hora, fecha;
            hora = DateTime.Now.ToLongTimeString();
            fecha = DateTime.Now.ToLongDateString();
            printer.Title = "VITROMANTE";
            printer.SubTitle = "NOTA DE PEDIDO\nPedido:" + label9.Text + "\nCliente: " +
                textBox2.Text + " Direccion: " + textBox4.Text + "\nFecha Pedido: " + fp.Text + "\nFecha Entrega: " + fe.Text
                + "\nTelefono: " + textBox5.Text + "\nTotal: " + tot.Text + "\n";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;

            printer.PageNumbers = true;
            printer.PageNumberInHeader = true;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Calle Manuel González #416, Zona Centro, CP.89800, El Mante\nTel.(831) 232-1788\nGenerado: " + fecha + " , " + hora;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView2);
        }
    }
}
