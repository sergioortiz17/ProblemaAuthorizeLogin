using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCWebApi.Controllers
{   
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" }; //9.-este devuelve una lista de string 
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";     //10.-este devuelve un valor string 
        }


        //11.-Ojo esto que continua no esta configurado porque no esta el modelo (osea las condiciones para ir a acceder los da)
        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5    esto seria como pasarle un valor que este seria el identificador
        public void Delete(int id)
            // una igualdad seria una forma de instanciar , y luego como pasariamos los dATOS   
        {
        }
    }
}
