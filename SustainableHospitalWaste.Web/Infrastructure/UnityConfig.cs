using SustainableHospitalWaste.Business.Interfaces;
using SustainableHospitalWaste.Business.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace SustainableHospitalWaste.Web.Infrastructure
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Register your types here
            container.RegisterType<IWasteGroupBusiness, WasteGroupBusiness>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}