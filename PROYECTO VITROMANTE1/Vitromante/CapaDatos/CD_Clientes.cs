using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using CapaDatos;
namespace CapaDatos
{
    public class CD_Clientes
    {
        private CD_Conexion conexion = new CD_Conexion();
        public ClasePedidos claped;
        SqlDataReader leer;
        SqlDataReader leerp;
        SqlDataReader leerped;
        SqlDataReader leerpag;
        SqlDataReader leering;
        SqlDataReader leerbit;
        SqlDataReader leerpedinicio;
        DataTable dtpedinicio = new DataTable();
        ArrayList al=new ArrayList();
        DataTable tabla = new DataTable();
        DataTable tablaprod = new DataTable();
        DataTable tablaped = new DataTable();
        DataTable tablapedinfo = new DataTable();
        DataTable tablapag = new DataTable();
        DataTable tablaing = new DataTable();
        DataTable tablabit = new DataTable();
        SqlCommand comando = new SqlCommand();
        SqlCommand comandop = new SqlCommand();
        SqlCommand comandoped = new SqlCommand();
        SqlCommand comandopag = new SqlCommand();
        SqlCommand comandoing = new SqlCommand();
        SqlCommand comandobit = new SqlCommand();
        public DataTable Mostrar() {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarClientes";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarPag()
        {
            comandopag.Connection = conexion.AbrirConexion();
            comandopag.CommandText = "MostrarPagos";
            comandopag.CommandType = CommandType.StoredProcedure;
            leerpag = comandopag.ExecuteReader();
            tablapag.Load(leerpag);
            conexion.CerrarConexion();
            return tablapag;
        }
        public DataTable MostrarIng()
        {
            comandoing.Connection = conexion.AbrirConexion();
            comandoing.CommandText = "MostrarIngresos";
            comandoing.CommandType = CommandType.StoredProcedure;
            leering = comandoing.ExecuteReader();
            tablaing.Load(leering);
            conexion.CerrarConexion();
            return tablaing;
        }

        public DataTable MPed1(String fecha)
        {
            comandoped.Connection = conexion.AbrirConexion();
            comandoped.CommandText = "Select Distinct IDPedido,Cliente,Domicilio,FechaPedido,FechaEntrega,Telefono from Pedidos where FechaEntrega='"+fecha+"' order by IDPedido";
            comandoped.CommandType = CommandType.Text;
            leerped = comandoped.ExecuteReader();
            tablaped.Load(leerped);
            conexion.CerrarConexion();
            return tablaped;
        }

        public DataTable MPed()
        {
            comandoped.Connection = conexion.AbrirConexion();
            comandoped.CommandText = "Select Distinct IDPedido,Cliente,Domicilio,FechaPedido,FechaEntrega,Telefono from Pedidos order by IDPedido";
            comandoped.CommandType = CommandType.Text;
            leerped = comandoped.ExecuteReader();
            tablaped.Load(leerped);
            conexion.CerrarConexion();
            return tablaped;
        }

        public DataTable MPedInfo1(String idped)
        {
            dtpedinicio.Clear();
            comandoped.Connection = conexion.AbrirConexion();
            comandoped.CommandText = "Select IDProducto,Producto,Precio,Cantidad  from Pedidos where IDPedido=" + idped;
            comandoped.CommandType = CommandType.Text;
            leerpedinicio = comandoped.ExecuteReader();
            dtpedinicio.Load(leerpedinicio);
            conexion.CerrarConexion();
            return dtpedinicio;
        }

        public ArrayList MPedInfo(int idped)
        {
            comandoped.Connection = conexion.AbrirConexion();
            comandoped.CommandText = "Select IDProducto,Producto,Precio,Cantidad  from Pedidos where IDPedido=" + idped;
            comandoped.CommandType = CommandType.Text;
            leerped = comandoped.ExecuteReader();
            al.Add(new ClasePedidos(leerped.GetString(0), leerped.GetString(1), Convert.ToDouble(leerped.GetString(2)), Convert.ToInt32(leerped.GetString(3))));
            conexion.CerrarConexion();
            return al;
        }
        public DataTable BProd(String BDato,String opc)
        {
            comandop.Connection = conexion.AbrirConexion();
            if (opc.Equals("0"))
            {
                comandop.CommandText = "Select * from Productos where Producto like'" + BDato + "%'";
            }
            else
            {
                comandop.CommandText = "Select * from Productos where ID like'" + BDato + "%'";
            }
            
            comandop.CommandType = CommandType.Text;
            leerp = comandop.ExecuteReader();
            tablaprod.Load(leerp);
            conexion.CerrarConexion();
            return tablaprod;
        }
        public DataTable MostrarProd()
        {
            comandop.Connection = conexion.AbrirConexion();
            comandop.CommandText = "MostrarProductos";
            comandop.CommandType = CommandType.StoredProcedure;
            leerp = comandop.ExecuteReader();
            tablaprod.Load(leerp);
            conexion.CerrarConexion();
            return tablaprod;

        }
        public void insertar(String nombre,String ApP,String ApM,String calle,String ncasa,String colonia,String cp,String ciudad,String estado,String telefono,String email)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText= "InsertarClientess";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@ApP",ApP);
            comando.Parameters.AddWithValue("@ApM",ApM);
            comando.Parameters.AddWithValue("@calle",calle);
            comando.Parameters.AddWithValue("@ncasa",ncasa);
            comando.Parameters.AddWithValue("@colonia",colonia);
            comando.Parameters.AddWithValue("@cp",cp);
            comando.Parameters.AddWithValue("@ciudad",ciudad);
            comando.Parameters.AddWithValue("@estado",estado);
            comando.Parameters.AddWithValue("@telefono",telefono);
            comando.Parameters.AddWithValue("@email",email);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            
        }
        public void editar(int id,String nombre, String ApP, String ApM, String calle, String ncasa, String colonia, String cp, String ciudad, String estado, String telefono, String email)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarClientess";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", id);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@ApP", ApP);
            comando.Parameters.AddWithValue("@ApM", ApM);
            comando.Parameters.AddWithValue("@calle", calle);
            comando.Parameters.AddWithValue("@ncasa", ncasa);
            comando.Parameters.AddWithValue("@colonia", colonia);
            comando.Parameters.AddWithValue("@cp", cp);
            comando.Parameters.AddWithValue("@ciudad", ciudad);
            comando.Parameters.AddWithValue("@estado", estado);
            comando.Parameters.AddWithValue("@telefono", telefono);
            comando.Parameters.AddWithValue("@email", email);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarClientess";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public void InsertarProd(String id,String producto,double cunitario,double precio,double utilidad,int cant,String descripcion,String unidad)
        {
            comandop.Connection = conexion.AbrirConexion();
            comandop.CommandText = "InsertarProductos";
            comandop.CommandType = CommandType.StoredProcedure;
            comandop.Parameters.AddWithValue("@id",id);
            comandop.Parameters.AddWithValue("@producto",producto);
            comandop.Parameters.AddWithValue("@costounitario",cunitario);
            comandop.Parameters.AddWithValue("@precio",precio);
            comandop.Parameters.AddWithValue("@utilidad",utilidad);
            comandop.Parameters.AddWithValue("@cantidad",cant);
            comandop.Parameters.AddWithValue("@descripcion",descripcion);
            comandop.Parameters.AddWithValue("@unidad",unidad);
            comandop.ExecuteNonQuery();
            comandop.Parameters.Clear();
        }
        public void EditarProd(String id, String producto, double cunitario, double precio, double utilidad, int cant, String descripcion, String unidad,String iddd)
        {
            comandop.Connection = conexion.AbrirConexion();
            comandop.CommandText = "Update Productos set ID='"+id+ "',Producto='"+producto+ "',[Costo Unitario]="+cunitario+ ",Precio="+precio+ ",Utilidad="+utilidad+"," +
                "Cantidad="+cant+ ",Descripcion='"+descripcion+ "',[Unidad De Medida]='"+unidad+ "' where ID='"+iddd+"';";
            comandop.CommandType = CommandType.Text;
            comandop.ExecuteNonQuery();
           // comandoped.CommandText="Update Productos set Cantidad='"++"' where ID='"++"'";
        }
        public void EliminarProd(String id)
        {
            comandop.Connection = conexion.AbrirConexion();
            comandop.CommandText = "EliminarProducto";
            comandop.CommandType = CommandType.StoredProcedure;
            comandop.Parameters.AddWithValue("@id", id);
            comandop.ExecuteNonQuery();
            comandop.Parameters.Clear();
        }
        public int pedmax()
        {
            comandoped.Connection = conexion.AbrirConexion();
            comandoped.CommandText = "select MAX(IDPEDIDO)+1 FROM Pedidos";
            comandoped.CommandType = CommandType.Text;
            int maxId;
            String mid = Convert.ToString(comandoped.ExecuteScalar());
            if (mid.Equals(""))
            {
                maxId = 1;
            }
            else
            {
                maxId= Convert.ToInt32(comandoped.ExecuteScalar());
            }

            return maxId;
        }
        public void hacerpedido(int IDPedido, String Cliente, String Domicilio, String IDProducto, String Producto, double Precio, String Telefono, String FechaPedido, String FechaEntrega, int Cantidad)
        {
            comandoped.Connection = conexion.AbrirConexion();
            comandoped.CommandText = "InsertarPedidos";
            comandoped.CommandType = CommandType.StoredProcedure;
            comandoped.Parameters.AddWithValue("@IDPedido", IDPedido);
            comandoped.Parameters.AddWithValue("@Cliente", Cliente);
            comandoped.Parameters.AddWithValue("@Domicilio", Domicilio);
            comandoped.Parameters.AddWithValue("@IDProducto", IDProducto);
            comandoped.Parameters.AddWithValue("@Producto", Producto);
            comandoped.Parameters.AddWithValue("@Precio", Precio);
            comandoped.Parameters.AddWithValue("@Telefono", Telefono);
            comandoped.Parameters.AddWithValue("@FechaPedido", FechaPedido);
            comandoped.Parameters.AddWithValue("@FechaEntrega", FechaEntrega);
            comandoped.Parameters.AddWithValue("@Cantidad", Cantidad);
            comandoped.ExecuteNonQuery();
            comandoped.Parameters.Clear();

            comandoped.CommandText = "update Productos set Cantidad= ((select Cast(Cantidad as int) from Productos where ID='"+IDProducto+"')-"+Cantidad+") where ID='"+IDProducto+"'";
            comandoped.CommandType = CommandType.Text;
            comandoped.ExecuteNonQuery();
            comandoped.Parameters.Clear();
        }
        public void EditarPedido(String IDProducto,int Cantidad,String Producto)
        {
            comandoped.Connection = conexion.AbrirConexion();
            comandoped.CommandText = "IF NOT EXISTS(SELECT ID FROM PRODUCTOS WHERE ID='"+IDProducto+"')" +
                "INSERT INTO PRODUCTOS (ID,PRODUCTO,CANTIDAD,[Costo Unitario],Precio,Utilidad) VALUES('" + IDProducto+"','"+Producto+"',"+Cantidad+",0,0,0)" +
                " ELSE " +
                " update Productos set Cantidad=((select Cast(Cantidad as int) from Productos where ID='" + IDProducto + "')+" + Cantidad + ") where ID='" + IDProducto + "'";
            //comandoped.CommandText = "update Productos set Cantidad=((select Cast(Cantidad as int) from Productos where ID='" + IDProducto + "')+" + Cantidad + ") where ID='" + IDProducto + "'";
            comandoped.CommandType = CommandType.Text;
            comandoped.ExecuteNonQuery();
            comandoped.Parameters.Clear();
        }
        public void EliminarPedido(int IDPedido)
        {
            comandoped.Connection = conexion.AbrirConexion();
            comandoped.CommandText = "delete from Pedidos where IDPedido=" + IDPedido;
            comandoped.CommandType = CommandType.Text;
            comandoped.ExecuteNonQuery();
            comandoped.Parameters.Clear();
        }
        public void InsertarPagos(String Descripcion,double Monto,String Fecha)
        {
            comandopag.Connection = conexion.AbrirConexion();
            comandopag.CommandText = "InsertarPagos";
            comandopag.CommandType = CommandType.StoredProcedure;
            comandopag.Parameters.AddWithValue("@Descripcion",Descripcion);
            comandopag.Parameters.AddWithValue("@Monto",Monto);
            comandopag.Parameters.AddWithValue("@Fecha",Fecha);
            comandopag.ExecuteNonQuery();
            comandopag.Parameters.Clear();
        }
        public void EditarPagos(int ID, String Descripcion, double Monto, String Fecha)
        {
            comandopag.Connection = conexion.AbrirConexion();
            comandopag.CommandText = "EditarPagos";
            comandopag.CommandType = CommandType.StoredProcedure;
            comandopag.Parameters.AddWithValue("@ID",ID);
            comandopag.Parameters.AddWithValue("@Descripcion",Descripcion);
            comandopag.Parameters.AddWithValue("@Monto",Monto);
            comandopag.Parameters.AddWithValue("@Fecha",Fecha);
            comandopag.ExecuteNonQuery();
            comandopag.Parameters.Clear();
        }
        public void EliminarPagos(int ID)
        {
            comandopag.Connection = conexion.AbrirConexion();
            comandopag.CommandText = "EliminarPagos";
            comandopag.CommandType = CommandType.StoredProcedure;
            comandopag.Parameters.AddWithValue("@ID",ID);
            comandopag.ExecuteNonQuery();
            comandopag.Parameters.Clear();
        }



        public void InsertarIngresos(String Descripcion, double Monto, String Fecha)
        {
            comandoing.Connection = conexion.AbrirConexion();
            comandoing.CommandText = "InsertarIngresos";
            comandoing.CommandType = CommandType.StoredProcedure;
            comandoing.Parameters.AddWithValue("@Descripcion", Descripcion);
            comandoing.Parameters.AddWithValue("@Monto", Monto);
            comandoing.Parameters.AddWithValue("@Fecha", Fecha);
            comandoing.ExecuteNonQuery();
            comandoing.Parameters.Clear();
        }
        public void EditarIngresos(int ID, String Descripcion, double Monto, String Fecha)
        {
            comandoing.Connection = conexion.AbrirConexion();
            comandoing.CommandText = "EditarIngresos";
            comandoing.CommandType = CommandType.StoredProcedure;
            comandoing.Parameters.AddWithValue("@ID", ID);
            comandoing.Parameters.AddWithValue("@Descripcion", Descripcion);
            comandoing.Parameters.AddWithValue("@Monto", Monto);
            comandoing.Parameters.AddWithValue("@Fecha", Fecha);
            comandoing.ExecuteNonQuery();
            comandoing.Parameters.Clear();
        }
        public void EliminarIngresos(int ID)
        {
            comandoing.Connection = conexion.AbrirConexion();
            comandoing.CommandText = "EliminarIngresos";
            comandoing.CommandType = CommandType.StoredProcedure;
            comandoing.Parameters.AddWithValue("@ID", ID);
            comandoing.ExecuteNonQuery();
            comandoing.Parameters.Clear();
        }
        public DataTable MBitacora()
        {
            comandobit.Connection = conexion.AbrirConexion();
            comandobit.CommandText = "MostrarBitacora";
            comandobit.CommandType = CommandType.StoredProcedure;
            leerbit = comandobit.ExecuteReader();
            tablabit.Load(leerbit);
            conexion.CerrarConexion();
            return tablabit;
        }
        public DataTable MFBitacora(String Fecha)
        {
            comandobit.Connection = conexion.AbrirConexion();
            comandobit.CommandText = "MFBitacora";
            comandobit.CommandType = CommandType.StoredProcedure;
            comandobit.Parameters.AddWithValue("@Fecha", Fecha);
            leerbit = comandobit.ExecuteReader();
            tablabit.Load(leerbit);
            conexion.CerrarConexion();
            return tablabit;
        }
        public void EliminarTodoProductos()
        {
            comandop.Connection = conexion.AbrirConexion();
            comandop.CommandText = "delete from Productos";
            comandop.CommandType = CommandType.Text;
            comandop.ExecuteNonQuery();
            comandop.Parameters.Clear();
        }
    }
}
