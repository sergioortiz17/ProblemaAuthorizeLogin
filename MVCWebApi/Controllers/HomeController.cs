using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(); // 4.-aca lo que retorna son las vistas , en este caso me devuelve la ruta relacionada al index
            //5.-hasta aca es una idea para ver que la applicacion es completa, y parecida un poco a angular
            //6.- por ahora solo hay que concentrase en los controladores que van a ser apis
            //7.- los framework ya tenian codigo prediseñado bueno es analogo a estos ejemplos( ojo la parte del front cambia un poco en realcion a angular)
            //8.-uso fiddler a mi no me funciono postman y explica las rutas que traen la info con el metodo get (valuesController)
        }
    }
}
