using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace MVCWebApi.Models
{   [Authorize]
    public class Cliente
    {
        private int idCliente;
        private string nombre;
        private string apellido;
        private string ciudad;
        private int cP;
        private string provincia;
        private string nombreUsuario;
        private int dni;
        private string email;
        private string fotoDni;
        private string password;

        //constructor que recibe parametros
        public Cliente(int idCliente, string nombre, string apellido, string ciudad, int cP, string provincia, string nombreUsuario, int dni, string email, string fotoDni, string password)
        {
            IdCliente = idCliente;
            Nombre = nombre;
            Apellido = apellido;
            Ciudad = ciudad;
            CP = cP;
            Provincia = provincia;
            NombreUsuario = nombreUsuario;
            Dni = dni;
            Email = email;
            FotoDni = fotoDni;
            Password = password;
        }
        //constructor que no recibe parametros
        public Cliente()
        {
        }

        //campos encapsulados y usando la propiedad
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public int CP { get => cP; set => cP = value; }
        public string Provincia { get => provincia; set => provincia = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public int Dni { get => dni; set => dni = value; }
        public string Email { get => email; set => email = value; }
        public string FotoDni { get => fotoDni; set => fotoDni = value; }
        public string Password { get => password; set => password = value; }
    }
}