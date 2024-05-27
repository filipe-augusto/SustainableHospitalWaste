using SustainableHospitalWaste.Business.Interfaces;
using SustainableHospitalWaste.Entities;
using System;
using System.Web.Mvc;

namespace SustainableHospitalWaste.Web.Controllers
{
    public class WasteGroupController : BaseController
    {
        private readonly IWasteGroupBusiness _wasteGroupBusiness;

        public WasteGroupController(IWasteGroupBusiness wasteGroupBusiness)
        {
            _wasteGroupBusiness = wasteGroupBusiness;
        }

        public ActionResult Index()
        {
            try
            {
                var wasteGroups = _wasteGroupBusiness.ReadAll();
                return View(wasteGroups);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                var wasteGroup = _wasteGroupBusiness.Read(id);
                if (wasteGroup == null)
                {
                    return HttpNotFound();
                }
                return View(wasteGroup);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WasteGroup wasteGroup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _wasteGroupBusiness.Create(wasteGroup);
                    return RedirectToAction("Index");
                }

                return View(wasteGroup);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var wasteGroup = _wasteGroupBusiness.Read(id);
                if (wasteGroup == null)
                {
                    return HttpNotFound();
                }
                return View(wasteGroup);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WasteGroup wasteGroup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _wasteGroupBusiness.Update(wasteGroup);
                    return RedirectToAction("Index");
                }
                return View(wasteGroup);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var wasteGroup = _wasteGroupBusiness.Read(id);
                if (wasteGroup == null)
                {
                    return HttpNotFound();
                }
                return View(wasteGroup);
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _wasteGroupBusiness.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return HandleError(ex);
            }
        }


        protected ActionResult HandleError(Exception ex)
        {
            // Log o erro (você pode implementar um serviço de logging)
            // Logger.LogError(ex);

            // Redireciona para uma página de erro
            return View("Error", new HandleErrorInfo(ex, RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString()));
        }
    }
}