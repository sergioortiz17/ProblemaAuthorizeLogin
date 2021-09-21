using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCWebApi.Models;
//using MVCWebApi.Security;


namespace MVCWebApi.Controllers
{
    [Authorize]
    public class ClienteController : ApiController
    {
        // GET api/<controller> YAAA ME FUNCIONAA
        public IEnumerable<Cliente> Get()
        {
            GestorCliente gCliente = new GestorCliente();
            return gCliente.ObtenerClientes();
        }

        // GET api/<controller>/5 YAAAA ME FUNCIONA
        public Cliente Get(int id)
        {
            GestorCliente gestorCliente = new GestorCliente();
            return gestorCliente.ObtenerCliente(id);
        }

        // POST api/<controller> YAAA ME FUNCIONA
        public Cliente Post([FromBody] Cliente value)
        {
            GestorCliente gCliente = new GestorCliente();
            value.IdCliente = gCliente.Registrar(value);
            return value;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        
    }
}