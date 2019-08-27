using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CD_Conexion
    {
        
        private SqlConnection Conexion = new SqlConnection("Data Source=.;Initial Catalog=ProyectoVitromanteEjemplo1;Integrated Security=True");
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == System.Data.ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == System.Data.ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }

    }
}
