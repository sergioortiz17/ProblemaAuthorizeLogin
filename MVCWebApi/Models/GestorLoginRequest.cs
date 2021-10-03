using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using MVCWebApi.Models;
using System.Data;

namespace MVCWebApi.Models
{
    public class GestorLoginRequest
    {
        public LoginRequest Login(string user)
        {
            LoginRequest loginRequest = null; // creo el objeto del tipo LoginRequest que por el momento puede ser vacio

            //Conecto a la db para poder ir a buscar el objeto
            string connection = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();
           
            //DATOS QUE VOY A ENVIAR A LA CONSULTA SQL
            //le pongo un nombre a la coneccion que voy a usar
            using (
                SqlConnection conn = new SqlConnection(connection))
            {
                
                conn.Open(); //Abro la conexion 

                SqlCommand comm = conn.CreateCommand(); //Declaro que voy a usar un comando sql
                comm.CommandText = "login"; // el comando se va a llamar login 
                comm.CommandType = CommandType.StoredProcedure; // y es un procedimiento de almacenado
                
                comm.Parameters.Add(new SqlParameter("@email", user)); // este es el parametro que le voy a pasar 
                

                SqlDataReader dr = comm.ExecuteReader(); // variables que quiero leer 

                if (dr.Read())
                {
                   
                    string email = dr.GetString(0).Trim();
                
                    string password = dr.GetString(1).Trim();
                    //Me traen estos dos datos que si existen me crean este objeto
                    loginRequest = new LoginRequest(email, password);
                }
               // else loginRequest = new LoginRequest(null, null);
                dr.Close();
            }
            //Me retorna el objeto que creo 
            return loginRequest;

        }

    }


}