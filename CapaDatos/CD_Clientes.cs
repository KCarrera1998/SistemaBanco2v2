using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Clientes
    {
    
        CD_Conexion db_conexion = new CD_Conexion();

        public DataTable MtMostrarClientes()
        {
            string QryMostrarClientes = "usp_clientes_mostrar";
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarClientes,db_conexion.MtdAbrirConexion());
            DataTable dtMostrarClientes = new DataTable();
            adapter.Fill(dtMostrarClientes);
            db_conexion.MtdCerrarConexion();
            return dtMostrarClientes;
        }

        public void MtdAgregarClientes(string Nombre, string Direccion, string Departamento, string Pais, string Categoria, string Estado)
        {
            string Usp_crear = "usp_clientes_crear";
            SqlCommand cmd_InsertarClientes = new SqlCommand(Usp_crear,db_conexion.MtdAbrirConexion());
            cmd_InsertarClientes.CommandType = CommandType.StoredProcedure;
            cmd_InsertarClientes.Parameters.AddWithValue("@Nombre",Nombre);
            cmd_InsertarClientes.Parameters.AddWithValue("@Direccion", Direccion);
            cmd_InsertarClientes.Parameters.AddWithValue("@Departamento", Departamento);
            cmd_InsertarClientes.Parameters.AddWithValue("@Pais", Pais);
            cmd_InsertarClientes.Parameters.AddWithValue("@Categoria", Categoria);
            cmd_InsertarClientes.Parameters.AddWithValue("@Estado", Estado);
            cmd_InsertarClientes.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarClientes(int Codigo, string Nombre, string Direccion, string Departamento, string Pais, string Categoria, string Estado)
        {
            string usp_actualizar = "usp_clientes_modificar";
            SqlCommand cmdUspActualizar = new SqlCommand(usp_actualizar,db_conexion.MtdAbrirConexion());
            cmdUspActualizar.CommandType = CommandType.StoredProcedure;
            cmdUspActualizar.Parameters.AddWithValue("@Codigo", Codigo);
            cmdUspActualizar.Parameters.AddWithValue("@Nombre", Nombre);
            cmdUspActualizar.Parameters.AddWithValue("@Direccion", Direccion);
            cmdUspActualizar.Parameters.AddWithValue("@Departamento", Departamento);
            cmdUspActualizar.Parameters.AddWithValue("@Pais", Pais);
            cmdUspActualizar.Parameters.AddWithValue("@Categoria", Categoria);
            cmdUspActualizar.Parameters.AddWithValue("@Estado", Estado);
            cmdUspActualizar.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();
        }

        public void MtdEliminar(int Codigo)
        {
            string usp_eliminar= "usp_clientes_eliminar";
            SqlCommand cmdUsEliminar = new SqlCommand(usp_eliminar, db_conexion.MtdAbrirConexion());
            cmdUsEliminar.CommandType = CommandType.StoredProcedure;
            cmdUsEliminar.Parameters.AddWithValue("@Codigo", Codigo);
            cmdUsEliminar.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();
        }



    }
}
