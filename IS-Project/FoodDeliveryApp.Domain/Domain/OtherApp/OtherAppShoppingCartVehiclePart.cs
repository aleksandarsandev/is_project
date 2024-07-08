using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Domain.Domain.OtherApp
{
    public class OtherAppShoppingCartVehiclePart
    {
        public Guid? ProductShoppingCartsId { get; set; }
        public Guid? ShoppingCartsId { get; set; }
        public OtherAppVehiclePart? ProductShoppingCarts { get; set; }

        public OtherAppShoppingCart? ShoppingCart { get; set; }

    }
}
