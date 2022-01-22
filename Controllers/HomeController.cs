using FotoDB_WPA.Logic.Design_Patterns.Builder;
using FotoDB_WPA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPlanWystawyDirector _planWystawyDirector;

        public HomeController(ILogger<HomeController> logger, IPlanWystawyDirector planWystawyDirector)
        {
            _logger = logger;
            _planWystawyDirector = planWystawyDirector;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Cennik()
        {
            CennikPlansWystawy cennik = new CennikPlansWystawy();

            //Buduj Plan wystawy stałej
            var permanentPlanWystawyBuilder = new PermanentPlanWystawyBuilder();
            _planWystawyDirector.SetPlanWystawyBuilder(permanentPlanWystawyBuilder);
            _planWystawyDirector.BuildPermanentPlanWystawy();
            cennik.PermanentPlanWystawy = permanentPlanWystawyBuilder.GetPlanWystawy();

            //Buduj Plan wystawy czasowej
            var temporaryPlanWystawyBuilder = new TemporaryPlanWystawyBuilder();
            _planWystawyDirector.SetPlanWystawyBuilder(temporaryPlanWystawyBuilder);
            _planWystawyDirector.BuildTemporaryPlanWystawy();
            cennik.TemporaryPlanWystawy = temporaryPlanWystawyBuilder.GetPlanWystawy();

            //Buduj Plan wystawy stałej w wersji custom
            var customPlanWystawyBuilder = new PermanentPlanWystawyBuilder();
            customPlanWystawyBuilder.BuildObrazEksponat();
            customPlanWystawyBuilder.BuildRzezbaEksponat();
            cennik.CustomPlanWystawy = customPlanWystawyBuilder.GetPlanWystawy();


            return View(cennik);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
