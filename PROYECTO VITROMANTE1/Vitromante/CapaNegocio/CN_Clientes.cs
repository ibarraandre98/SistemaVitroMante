using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
using System.Data.SqlClient;
using System.Collections;

namespace CapaNegocio
{
    public class CN_Clientes
    {
        ArrayList al;
        DataTable tablapedinfo;
        private CD_Clientes objetoCD = new CD_Clientes();
        public DataTable MostrarClientes()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public DataTable MPed1(String fecha)
        {
            DataTable tablaped = new DataTable();
            tablaped = objetoCD.MPed1(fecha);
            return tablaped;
        }

        public DataTable MPed()
        {
            DataTable tablaped = new DataTable();
            tablaped = objetoCD.MPed();
            return tablaped;
        }
        public DataTable MPedInfo1(String idped)
        {
            DataTable tablaped = new DataTable();
            tablaped.Clear();
            tablaped = objetoCD.MPedInfo1(idped);
            return tablaped;
        }
        public ArrayList MPedInfo(String idped)
        {
            al = new ArrayList();
            al = objetoCD.MPedInfo(Convert.ToInt32(idped));
            return al;
        }
        public DataTable tablapedinfo1()
        {
            return tablapedinfo;
        }
        public DataTable BProd(String BDato, String opc)
        {
            DataTable BProductos = new DataTable();
            BProductos = objetoCD.BProd(BDato, opc);
            return BProductos;
        }
        public DataTable MostrarProductos()
        {
            DataTable tablaprod = new DataTable();
            tablaprod = objetoCD.MostrarProd();
            return tablaprod;
        }
        public void insertar(String nombre, String ApP, String ApM, String calle, String ncasa, String colonia, String cp, String ciudad, String estado, String telefono, String email)
        {
            objetoCD.insertar(nombre, ApP, ApM, calle, ncasa, colonia, cp, ciudad, estado, telefono, email);
        }
        public void editar(String id, String nombre, String ApP, String ApM, String calle, String ncasa, String colonia, String cp, String ciudad, String estado, String telefono, String email)
        {
            objetoCD.editar(Convert.ToInt32(id), nombre, ApP, ApM, calle, ncasa, colonia, cp, ciudad, estado, telefono, email);
        }
        public void eliminar(String id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }
        public void InsertarProd(String id, String producto, String cunitario, String precio, String utilidad, String cant, String descripcion, String unidad)
        {
            objetoCD.InsertarProd(id, producto, Convert.ToDouble(cunitario), Convert.ToDouble(precio), Convert.ToDouble(utilidad), Convert.ToInt32(cant), descripcion, unidad);
        }
        public void EditarProd(String id, String producto, String cunitario, String precio, String utilidad, String cant, String descripcion, String unidad, String iddd)
        {
            objetoCD.EditarProd(id, producto, Convert.ToDouble(cunitario), Convert.ToDouble(precio), Convert.ToDouble(utilidad), Convert.ToInt32(cant), descripcion, unidad, iddd);
        }
        public void EliminarProducto(String id)
        {
            objetoCD.EliminarProd(id);
        }
        public void hacerpedido(String IDPedido, String Cliente, String Domicilio, String IDProducto, String Producto, String Precio, String Telefono, String FechaPedido, String FechaEntrega, String Cantidad)
        {
            objetoCD.hacerpedido(Convert.ToInt32(IDPedido), Cliente, Domicilio, IDProducto, Producto, Convert.ToDouble(Precio), Telefono, FechaPedido, FechaEntrega, Convert.ToInt32(Cantidad));
        }
        public int pedmax()
        {
            return objetoCD.pedmax();
        }
        public void EditarPedido(String IDProducto, int Cantidad, String Producto)
        {
            objetoCD.EditarPedido(IDProducto, Cantidad, Producto);
        }
        public void EliminarPedido(int IDPedido)
        {
            objetoCD.EliminarPedido(IDPedido);
        }
        public DataTable MostrarPagos()
        {
            DataTable tablapag = new DataTable();
            tablapag = objetoCD.MostrarPag();
            return tablapag;
        }
        public void InsertarPagos(String Descripcion, String Monto, String Fecha)
        {
            objetoCD.InsertarPagos(Descripcion, Convert.ToDouble(Monto), Fecha);
        }
        public void EditarPagos(String ID, String Descripcion, String Monto, String Fecha)
        {
            objetoCD.EditarPagos(Convert.ToInt32(ID),Descripcion,Convert.ToDouble(Monto),Fecha);
        }
        public void EliminarPagos(String ID)
        {
            objetoCD.EliminarPagos(Convert.ToInt32(ID));
        }
        public DataTable MostrarIngresos()
        {
            DataTable tablaing = new DataTable();
            tablaing = objetoCD.MostrarIng();
            return tablaing;
        }
        public void InsertarIngresos(String Descripcion, String Monto, String Fecha)
        {
            objetoCD.InsertarIngresos(Descripcion, Convert.ToDouble(Monto), Fecha);
        }
        public void EditarIngresos(String ID, String Descripcion, String Monto, String Fecha)
        {
            objetoCD.EditarIngresos(Convert.ToInt32(ID), Descripcion, Convert.ToDouble(Monto), Fecha);
        }
        public void EliminarIngresos(String ID)
        {
            objetoCD.EliminarIngresos(Convert.ToInt32(ID));
        }
        public DataTable MBitacora()
        {
            DataTable tablaBitacora = new DataTable();
            tablaBitacora = objetoCD.MBitacora();
            return tablaBitacora;
        }
        public DataTable MFBitacora(String Fecha)
        {
            DataTable tablaFBitacora = new DataTable();
            tablaFBitacora = objetoCD.MFBitacora(Fecha);
            return tablaFBitacora;
        }
        public void EliminarTodoProductos()
        {
            objetoCD.EliminarTodoProductos();
        }
    }
}
