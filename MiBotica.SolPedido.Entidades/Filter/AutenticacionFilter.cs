using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
namespace MiBotica.SolPedido.Entidades.Filter
{
    public class AutenticacionFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Verifica si el usuario no está autenticado
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                // Verifica si la acción actual no es "Index" en el controlador "Login"
                if (filterContext.ActionDescriptor.ControllerDescriptor.ControllerName != "Login" ||
                    filterContext.ActionDescriptor.ActionName != "Index")
                {
                    // Redirige a la página de Login
                    filterContext.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary(
                            new { controller = "Login", action = "Index" }
                        )
                    );
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
