using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ClasePedidos
    {
        public ClasePedidos()
        {

        }
        public ClasePedidos(String IDProducto, String Producto, double Precio, int Cantidad)
        {
            this.IDProducto = IDProducto;
            this.Producto = Producto;
            this.Precio = Precio;
            this.Cantidad = Cantidad;
        }
        public String IDProducto { get; set; }
        public String Producto { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
