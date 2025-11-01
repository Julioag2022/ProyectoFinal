using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Empleados
    {
        Conexion conn = new Conexion();

        // Consulta datos de empleados en la base de datos 
        public DataTable MtdConsultarEmpleados()
        {
            string Query = "Select * from dbo.tblEmpleados;";
            SqlDataAdapter SqlAdap = new SqlDataAdapter(Query, conn.MtdAbrirConexion());
            DataTable dt = new DataTable();
            SqlAdap.Fill(dt);
            conn.MtdCerrarConexion();
            return dt;
        }

        // Metodo para gregar un nuevo empleado
        public void MtdAgregarEmpleados(string Nombre, int Dpi, string Direccion, DateTime FechaIngreso, double SalarioBase, string TipoEmpleado, string Estado)
        {
            string QueryAgregar = "Insert into tbl_Empleados ( Nombre, Dpi, Direccion, FechaIngreso, SalarioBase, TipoEmpleado, Estado) values ( @Nombre, @Dpi, @Direccion, @FechaIngreso, @SalarioBase, @TipoEmpleado, @Estado);";
            SqlCommand Sqlcmd = new SqlCommand(QueryAgregar,conn.MtdAbrirConexion());
            Sqlcmd.Parameters.AddWithValue("@Nombre", Nombre);
            Sqlcmd.Parameters.AddWithValue("@Dpi", Dpi);
            Sqlcmd.Parameters.AddWithValue("@Direccion", Direccion);
            Sqlcmd.Parameters.AddWithValue("@FechaIngreso", FechaIngreso);
            Sqlcmd.Parameters.AddWithValue("@SalarioBase", SalarioBase);
            Sqlcmd.Parameters.AddWithValue("@TipoEmpleado", TipoEmpleado);
            Sqlcmd.Parameters.AddWithValue("@Estado", Estado);
            Sqlcmd.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

        // Metodo para editar un nuevo empleado
        public void MtdEditarEmpleados(int CodigoEmpleado, string Nombre, int Dpi, string Direccion, DateTime FechaIngreso, double SalarioBase, string TipoEmpleado, string Estado)
        {
            string QueryAgregar = "Update tbl_Empleados set Nombre=@Nombre, Dpi=@Dpi, Direccion=@Direccion, FechaIngreso=@FechaIngreso, SalarioBase=@SalarioBase,  TipoEmpleado=@TipoEmpleado, Estado=@Estado Where CodigoEmpleado=@CodigoEmpleado";
            SqlCommand Sqlcmd = new SqlCommand(QueryAgregar, conn.MtdAbrirConexion());
            Sqlcmd.Parameters.AddWithValue("@CodigoEmpleado", CodigoEmpleado);
            Sqlcmd.Parameters.AddWithValue("@Nombre", Nombre);
            Sqlcmd.Parameters.AddWithValue("@Dpi", Dpi);
            Sqlcmd.Parameters.AddWithValue("@Direccion", Direccion);
            Sqlcmd.Parameters.AddWithValue("@FechaIngreso", FechaIngreso);
            Sqlcmd.Parameters.AddWithValue("@SalarioBase", SalarioBase);
            Sqlcmd.Parameters.AddWithValue("@TipoEmpleado", TipoEmpleado);
            Sqlcmd.Parameters.AddWithValue("@Estado", Estado);
            Sqlcmd.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }


        // Metodo para eliminar un nuevo empleado
        public void MtdEliminarEmpleados(int CodigoEmpleado)
        {
            string QueryAgregar = "Delete tbl_Empleados where CodigoEmpleado=@CodigoEmpleado";
            SqlCommand Sqlcmd = new SqlCommand(QueryAgregar, conn.MtdAbrirConexion());
            Sqlcmd.Parameters.AddWithValue("@CodigoEmpleado", CodigoEmpleado);
            Sqlcmd.ExecuteNonQuery();
            conn.MtdCerrarConexion();
        }

    }
}
