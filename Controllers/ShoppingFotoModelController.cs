using FotoDB_WPA.Logic.Design_Patterns.Mediator;
using Microsoft.AspNetCore.Mvc;
using FotoDB_WPA.ILogic;
using FotoDB_WPA.Logic;
using FotoDB_WPA.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA.Controllers
{
    public class ShoppingFotoModelController : Controller
    {
        //private readonly IFotoModelService _fotoModelService;
        //private readonly INotificationFotoModelService _notificationFotoModelService;
        //private readonly IShoppingFotoModelService _shoppingFotoModelService;

        //public ShoppingFotoModelControler(IFotoModelService fotoModelService,
        //                                    INotificationFotoModelService notificationFotoModelService,
        //                                    IShoppingFotoModelService shoppingFotoModelService)
        //{
        //    _fotoModelService = fotoModelService;
        //    _notificationFotoModelService = notificationFotoModelService;
        //    _shoppingFotoModelService = shoppingFotoModelService;

        //}
        private readonly IShoppingFotoModelMediator _shoppingFotoModelMediator;

        public ShoppingFotoModelController(IShoppingFotoModelMediator shoppingFotoModelMediator)
        {
            _shoppingFotoModelMediator = shoppingFotoModelMediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult AddToBasket(int id)
        //{
        //    // Fetch Product from Database
        //    var product = _fotoModelService.GetFoto(id);

        //    // Add Product to Basket
        //    _shoppingFotoModelService.AddToBasket(product);

        //    // Send Notification to User
        //    _notificationFotoModelService.SendNotification(product);

        //    return View();
        //}
        [HttpPost]
        public IActionResult AddToBasket(int id)
        {
            _shoppingFotoModelMediator.Handle(id);

            return View();
        }

    }
}
