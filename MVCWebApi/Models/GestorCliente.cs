using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MVCWebApi.Models;
using System.Configuration;
 

namespace MVCWebApi.Models

{
    public class GestorCliente
    {
        //ACA RECIBE UN OBJETO CLIENTE
        public int Registrar(Cliente oCliente)
        {
            //accedo a la cadena de conexion con 
            string connection = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            //creo este objeto de conexion para que viva en ese epacio de codigo
            using (SqlConnection conn = new SqlConnection(connection))
               

            {
                conn.Open();

                // creo este objeto SqlCommand que permite ejecutar los select
                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = "pil_registrar"; // especifico el nombre del stored procedure
                comm.CommandType = CommandType.StoredProcedure; //reafirmo que es un stored procedure

                //aca le paso los parametros de ese objeto Cliente
                comm.Parameters.Add(new SqlParameter("@nombre", oCliente.Nombre));
                comm.Parameters.Add(new SqlParameter("@apellido", oCliente.Apellido));
                comm.Parameters.Add(new SqlParameter("@ciudad", oCliente.Ciudad));
                comm.Parameters.Add(new SqlParameter("@cp", oCliente.CP));
                comm.Parameters.Add(new SqlParameter("@provincia", oCliente.Provincia));
                comm.Parameters.Add(new SqlParameter("@nombreusuario", oCliente.NombreUsuario));
                comm.Parameters.Add(new SqlParameter("@dni", oCliente.Dni));
                comm.Parameters.Add(new SqlParameter("@email", oCliente.Email));
                comm.Parameters.Add(new SqlParameter("@fotodni", oCliente.FotoDni));
                comm.Parameters.Add(new SqlParameter("@password", oCliente.Password));

                //comm.ExecuteNonQuery(); //me devuelve el numero de filas que fueron afectadas ejecuta no devuelve 2Execute duplican el registro
                return Convert.ToInt32(comm.ExecuteScalar()); // con esto todas las rutas de acceso devuelven almenos un int

            }
        }

        //ACA DEVUELVE UN OBJETO CLIENTE
        public Cliente ObtenerCliente(int idCliente)
        {
            Cliente cliente = null;

            //Conecto a la db para poder ir a buscar el objeto
            string connection = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (
                SqlConnection conn = new SqlConnection(connection))
            {
                
                conn.Open();

                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = "obtener_cliente";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@id", idCliente));

                SqlDataReader dr = comm.ExecuteReader();

                if (dr.Read())
                {
                    string nombre = dr.GetString(1).Trim();
                    string apellido = dr.GetString(2).Trim();
                    string ciudad = dr.GetString(3).Trim();
                    int cP = dr.GetInt32(4);
                    string provincia = dr.GetString(5).Trim();
                    string nombreUsuario = dr.GetString(6).Trim();
                    int dni = dr.GetInt32(7);
                    string email = dr.GetString(8).Trim();
                    string fotoDni = dr.GetString(9).Trim();
                    int password = dr.GetInt32(10);

                    cliente = new Cliente(idCliente, nombre, apellido, ciudad, cP, provincia, nombreUsuario, dni, email, fotoDni, password);
                }

                dr.Close();
            }

            return cliente;

        }

        public void Eliminar(int idCliente)
        {
            string connection = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                SqlCommand comm = new SqlCommand("eliminar_cliente", conn);
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@id", idCliente));

                comm.ExecuteNonQuery();
            }

        }

        
        
        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            string connection = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                SqlCommand comm = conn.CreateCommand();
                comm.CommandText = "listar_clientes";
                comm.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    int idCliente = dr.GetInt32(0);
                    string nombre = dr.GetString(1).Trim();
                    string apellido = dr.GetString(2).Trim();
                    string ciudad = dr.GetString(3).Trim();
                    int cP = dr.GetInt32(4);
                    string provincia = dr.GetString(5).Trim();
                    string nombreUsuario = dr.GetString(6).Trim();
                    int dni = dr.GetInt32(7);
                    string email = dr.GetString(8).Trim();
                    string fotoDni = dr.GetString(9).Trim();
                    int password = dr.GetInt32(10);
                    Cliente cliente = new Cliente(idCliente, nombre, apellido, ciudad, cP, provincia, nombreUsuario, dni, email, fotoDni, password);
                    lista.Add(cliente);
                }

                dr.Close();
            }

            return lista;
        } 
    }
}