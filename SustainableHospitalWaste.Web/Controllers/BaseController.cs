using System;
using System.Web.Mvc;

namespace SustainableHospitalWaste.Web.Controllers
{
    public class BaseController : Controller
    {
        protected ActionResult HandleError(Exception ex)
        {
            // Log o erro (você pode implementar um serviço de logging)
            // Logger.LogError(ex);

            // Redireciona para uma página de erro
            return View("Error", new HandleErrorInfo(ex, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString()));
        }
    }
}