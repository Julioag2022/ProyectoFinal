using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexion
    {
        
        // 🔹 Cadena de conexión a tu base de datos en Azure SQL
        private SqlConnection db_conexion = new SqlConnection(
            "Server=tcp:sqldatabasedemo.database.windows.net,1433;" +
            "Database=ProyectoFinal;" +
            "User ID=Emmanuel@sqldatabasedemo;" +
            "Password=Mbappe2025;" +
            "Encrypt=True;" +
            "TrustServerCertificate=True;" +   // ✅ Igual que en tu SSMS
            "Connection Timeout=30;"
            );

        // Metodo para abrir la conexión a la base de datos
        public SqlConnection MtdAbrirConexion()
        {
            if (db_conexion.State == System.Data.ConnectionState.Closed)
            {
                db_conexion.Open();
            }

            return db_conexion;
        }

        // Metodo para cerrar la conexión a la base de datos
        public SqlConnection MtdCerrarConexion()
        {
            if (db_conexion.State == System.Data.ConnectionState.Open)
            {
                db_conexion.Close();
            }

            return db_conexion;
        }
    }
}
