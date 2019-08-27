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
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using DGVPrinterHelper;

namespace Vitromante
{
    public partial class Productos : Form
    {
        private SqlConnection Conexion = new SqlConnection("Data Source=.;Initial Catalog=ProyectoVitromanteEjemplo1;Integrated Security=True");
        CN_Clientes objetoCN = new CN_Clientes();
        SqlCommand com;
        Boolean ed = false;
        String iddd=null;
        int valor = 0;
        public Productos()
        {
            try
            {
                InitializeComponent();
                um.SelectedIndex = 0;
                busq.SelectedIndex = 0;
            }catch(Exception ex)
            {
                MessageBox.Show("¡Ha ocurrido un error! " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }
        private void EliminarTodoProductos()
        {
            objetoCN.EliminarTodoProductos();
        }
        private void MostrarProductos()
        {
            CN_Clientes MostrarUnaVez = new CN_Clientes();
            dataGridView1.DataSource = MostrarUnaVez.MostrarProductos();
            foreach (DataGridViewColumn Col in dataGridView1.Columns)
            {
                Col.SortMode = DataGridViewColumnSortMode.NotSortable;//Evitar que las columnas se ordenen
            }
        }
        private void BusquedaProductos(String BDato,String opc)
        {
            CN_Clientes BProd = new CN_Clientes();
            Cursor.Current = Cursors.WaitCursor;
            dataGridView1.DataSource = BProd.BProd(BDato,opc);
            Cursor.Current = Cursors.Default;
        }
        private void Productos_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (valor == 1)
            {
                if (MessageBox.Show("¿Desea cancelar la importacion?", "Cancelacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MostrarProductos();
                    valor = 0;
                    button2.Enabled = true;
                    eli.Enabled = true;
                    editar.Enabled = true;
                    textBox1.Enabled = true;
                    MessageBox.Show("¡Cancelacion exitosa!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                }
            else
            {
                Dispose();
            }
            Cursor.Current = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (valor == 1)
            {
                try
                {
                    if (dataGridView1.Columns.Count == 8)
                    {
                        EliminarTodoProductos();
                        foreach (DataGridViewRow item in dataGridView1.Rows)
                        {
                            objetoCN.InsertarProd(Convert.ToString(item.Cells["ID"].Value), Convert.ToString(item.Cells["Producto"].Value),
                                Convert.ToString(item.Cells["Costo Unitario"].Value), Convert.ToString(item.Cells["Precio"].Value), Convert.ToString(item.Cells["Utilidad"].Value),
                                Convert.ToString(item.Cells["Cantidad"].Value), Convert.ToString(item.Cells["Descripcion"].Value),
                                Convert.ToString(item.Cells["Unidad De Medida"].Value));
                        }
                        valor = 0;
                        button2.Enabled = true;
                        eli.Enabled = true;
                        editar.Enabled = true;
                        textBox1.Enabled =true;
                        MessageBox.Show("¡Cambios hechos exitosamente!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarProductos();
                    }
                    else
                    {
                        MessageBox.Show("¡Error el numero de columnas no coincide, deben de ser 8 columnas, resuelvalo y vuelva a importar el archivo Excel! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    
                }catch(FormatException ex)
                {
                    MessageBox.Show("¡Ciertas columnas no tienen el formato correcto, resuelvalo y vuelva a importar el archivo Excel!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("¡Ha ocurrido un error! " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else { 
            if (CodProd.Text.Equals("") || Prod.Text.Equals("") || cu.Text.Equals("") || pre.Text.Equals("") || uti.Text.Equals("") || cant.Text.Equals("") || des.Text.Equals("") || um.Text.Equals("")
                || (CodProd.Text.Equals("") && Prod.Text.Equals("") && cu.Text.Equals("") && pre.Text.Equals("") && uti.Text.Equals("") && cant.Text.Equals("") && des.Text.Equals("") && um.Text.Equals("")))
            {
                MessageBox.Show("¡No puede dejar campos en blanco!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (ed == false)
                {
                    try
                    {
                        if (dataGridView1.RowCount >= 0)
                        {
                            Boolean existe = false;
                                foreach (DataGridViewRow item in dataGridView1.Rows)
                                {
                                    if (Convert.ToString(item.Cells["ID"].Value).Equals(CodProd.Text))
                                    {
                                        MessageBox.Show("¡No se puede ingresar este producto, el codigo de producto ya esta en uso!", "Codigo repetido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        existe = true;
                                        break;
                                    }
                                }
                            if (existe == false)
                            {

                                objetoCN.InsertarProd(CodProd.Text, Prod.Text, cu.Text, pre.Text, uti.Text, cant.Text, des.Text, um.SelectedItem.ToString());
                                MessageBox.Show("¡Se ha agregado el producto con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Cursor.Current = Cursors.WaitCursor;
                                MostrarProductos();
                                Cursor.Current = Cursors.Default;
                                CodProd.Clear();
                                Prod.Clear();
                                cu.Clear();
                                pre.Clear();
                                uti.Clear();
                                cant.Clear();
                                des.Clear();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("¡Ha ocurrido un error! " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                //Editar
                if (ed == true)
                {
                    try
                    {
                        if (dataGridView1.RowCount > 0)
                        {
                            Boolean existe = false;
                            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                            {
                                if (dataGridView1.Rows[i].Cells["ID"].Value.ToString() == CodProd.Text && iddd != CodProd.Text)
                                {
                                    MessageBox.Show("¡No se puede editar este producto, el codigo de producto ya esta en uso!", "Codigo repetido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    existe = true;
                                    break;
                                }
                            }
                            if (existe == false)
                            {
                                objetoCN.EditarProd(CodProd.Text, Prod.Text, cu.Text, pre.Text, uti.Text, cant.Text, des.Text, um.SelectedItem.ToString(), iddd);
                                MessageBox.Show("¡Se ha editado el producto con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ed = false;
                                Cursor.Current = Cursors.WaitCursor;
                                MostrarProductos();
                                Cursor.Current = Cursors.Default;
                                CodProd.Clear();
                                Prod.Clear();
                                cu.Clear();
                                pre.Clear();
                                uti.Clear();
                                cant.Clear();
                                des.Clear();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("¡Ha ocurrido un error! " + ex, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }



            }
        }
            Cursor.Current = Cursors.Default;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void editar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ed = true;
                
                //Asignar a cada variable cada celda del datagridview
                iddd = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                CodProd.Text = iddd;
                Prod.Text= dataGridView1.CurrentRow.Cells["Producto"].Value.ToString();
                cu.Text = dataGridView1.CurrentRow.Cells["Costo Unitario"].Value.ToString();
                pre.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                uti.Text = dataGridView1.CurrentRow.Cells["Utilidad"].Value.ToString();
                cant.Text = dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString();
                des.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                um.Text= dataGridView1.CurrentRow.Cells["Unidad De Medida"].Value.ToString();
            }
            Cursor.Current = Cursors.Default;
        }

        private void eli_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    if(MessageBox.Show("¿Esta seguro de eliminar el producto?","Eliminar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objetoCN.EliminarProducto(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
                        MessageBox.Show("¡Se ha eliminado el producto con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor.Current = Cursors.WaitCursor;
                        MostrarProductos();
                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {
                        MessageBox.Show("¡No se ha eliminado el producto!", "Cancelacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show("¡Ha ocurrido un error! "+ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                
            }
            Cursor.Current = Cursors.Default;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != "Buscar")
            {
                if (busq.SelectedIndex == 0)
                {
                    BusquedaProductos(textBox1.Text, "0");
                }
                else
                {
                    BusquedaProductos(textBox1.Text, "1");
                }
                
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                MostrarProductos();
                Cursor.Current = Cursors.Default;
            }
        }

        private void cu_TextChanged(object sender, EventArgs e)
        {

        }
        public bool solonumeros1(int code)
        {
            bool resultado;
            if (code == 46 && cu.Text.Contains("."))//se evalua si es punto y si es punto se rebiza si ya existe en el textbox
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
        public bool solonumeros2(int code)
        {
            bool resultado;
            if (code == 46 && pre.Text.Contains("."))//se evalua si es punto y si es punto se rebiza si ya existe en el textbox
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
        public bool solonumeros3(int code)
        {
            bool resultado;
            if (code == 46 && uti.Text.Contains("."))//se evalua si es punto y si es punto se rebiza si ya existe en el textbox
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

        private void cu_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = solonumeros1(Convert.ToInt32(e.KeyChar));
        }

        private void pre_TextChanged(object sender, EventArgs e)
        {
        }

        private void uti_TextChanged(object sender, EventArgs e)
        {

        }

        private void pre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = solonumeros2(Convert.ToInt32(e.KeyChar));
        }

        private void uti_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = solonumeros3(Convert.ToInt32(e.KeyChar));
        }

        private void cant_TextChanged(object sender, EventArgs e)
        {

        }

        private void cant_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            exportaraexcel(dataGridView1);
            MessageBox.Show("¡Exportado con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Cursor.Current = Cursors.Default;
        }
        public void exportaraexcel(DataGridView tabla)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

                excel.Application.Workbooks.Add(true);

                int IndiceColumna = 0;

                foreach (DataGridViewColumn col in tabla.Columns) // Columnas
                {

                    IndiceColumna++;

                    excel.Cells[1, IndiceColumna] = col.Name;

                }

                int IndeceFila = 0;

                foreach (DataGridViewRow row in tabla.Rows) // Filas
                {

                    IndeceFila++;

                    IndiceColumna = 0;

                    foreach (DataGridViewColumn col in tabla.Columns)
                    {

                        IndiceColumna++;

                        excel.Cells[IndeceFila + 1, IndiceColumna] = row.Cells[col.Name].Value;

                    }

                }

                excel.Visible = true;
                Cursor.Current = Cursors.Default;
            }
            catch(Exception ex)
            {
                MessageBox.Show("¡Ha ocurrido un error! " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Importar imp = new Importar();
            if(imp.importarExcel(dataGridView1, "Hoja1") == true)
            {
                MessageBox.Show("¡Importado con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                valor = 1;
                eli.Enabled = false;
                editar.Enabled = false;
                button2.Enabled = false;
                textBox1.Enabled = false;
            }
            else
            {
                MessageBox.Show("¡Cancelado!", "Cancelacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarProductos();
                valor = 0;
                eli.Enabled = true;
                editar.Enabled = true;
                button2.Enabled = true;
                textBox1.Enabled = true;
            }
            Cursor.Current = Cursors.Default;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (dataGridView1.Rows.Count > 0)
            {
                DGVPrinter printer = new DGVPrinter();
                String hora, fecha;
                hora = DateTime.Now.ToLongTimeString();
                fecha = DateTime.Now.ToLongDateString();
                printer.Title = "VITROMANTE";
                printer.SubTitle = fecha + "\n"+hora+"\nPRODUCTOS";
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

        private void button5_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            CodProd.Clear();
            Prod.Clear();
            pre.Clear();
            cu.Clear();
            uti.Clear();
            cant.Clear();
            des.Clear();
            Cursor.Current = Cursors.Default;
        }
    }
}
