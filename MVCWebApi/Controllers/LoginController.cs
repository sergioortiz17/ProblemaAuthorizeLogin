using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading;
using MVCWebApi.Models;



namespace MVCWebApi.Controllers
{
    /// <summary>
    /// login controller class for authenticate users
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {


        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }
        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated:{ identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)

            //Si el cuerpo es vacio o llavez vacias o le falta alguna credencial  el control me tira un error 
        {
            if (login == null || login.Email == null || login.Password == null)
            {
                string error = "Email y Password son requeridos";
                return BadRequest(error);
            }

            GestorLoginRequest gLogin = new GestorLoginRequest();
            //Creo el objeto Login pasandole el parametro Username
            LoginRequest credentials = gLogin.Login(login.Email);
            var isUserValid = false;
            //Si el Username o el Password no coinciden el usuario sigue siendo invalido 

            if (credentials != null)
            { 
                if (login.Email == credentials.Email && login.Password == credentials.Password)
                isUserValid = true;
            }
            //Solo si es valido se le crea el token sino trae Unauthorized 
            if (isUserValid)
            {
                var rolename = "User";
                var token = TokenGenerator.GenerateTokenJwt(login.Email, rolename);
                return Ok(token);
            }
            // Unauthorized access
            return Unauthorized();
        }
    }

}