using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace Vitromante
{
    public class Importar
    {
        OleDbConnection conn;
        OleDbDataAdapter MyDataAdapter;
        DataTable dt;
        public Importar()
        {

        }
        public Boolean importarExcel(DataGridView dgv, String nombreHoja)
        {
            String ruta = "";
            try
            {
                OpenFileDialog openfile1 = new OpenFileDialog();
                openfile1.Filter = "Excel Files |*.xlsx";
                openfile1.Title = "Seleccione el archivo de Excel";
                if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openfile1.FileName.Equals("") == false)
                    {
                        ruta = openfile1.FileName;
                        conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" + ruta + ";Extended Properties='Excel 12.0 Xml;HDR=Yes'");
                        MyDataAdapter = new OleDbDataAdapter("Select * from [" + nombreHoja + "$]", conn);
                        dt = new DataTable();
                        MyDataAdapter.Fill(dt);
                        dgv.DataSource = dt;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("¡Ha cancelado la importacion!", "Cancelacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡Ha ocurrido un error! " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
        }
    }
}
