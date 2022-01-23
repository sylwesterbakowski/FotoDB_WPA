using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FotoDB_WPA.Logic.Design_Patterns.Mediator
{
    public class ShoppingFotoModelMediator : IShoppingFotoModelMediator
    {
        private readonly IFotoModelService _fotoModelService;
        private readonly INotificationFotoModelService _notificationFotoModelService;
        private readonly IShoppingFotoModelService _shoppingFotoModelService;

        public ShoppingFotoModelMediator(
                                            IFotoModelService fotoModelService, 
                                            INotificationFotoModelService notificationFotoModelService, 
                                            IShoppingFotoModelService shoppingFotoModelService)
        {
            _fotoModelService = fotoModelService;
            _shoppingFotoModelService = shoppingFotoModelService;
            _notificationFotoModelService = notificationFotoModelService;
        }

        public void Handle(int id)
        {
            // Fetch Product from Database
            var product = _fotoModelService.GetFoto(id);

            // Add Product to Basket
            _shoppingFotoModelService.AddToBasket(product);

            // Send Notification to User
            _notificationFotoModelService.SendNotification(product);
        }
    }
}
