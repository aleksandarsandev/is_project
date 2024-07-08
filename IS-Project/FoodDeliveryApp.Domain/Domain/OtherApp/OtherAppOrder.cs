using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Domain.Domain.OtherApp
{
    public class OtherAppOrder
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? ApplicationUserId { get; set; }
        public Guid? ShoppingCardId { get; set; }
        public Guid? ShoppingCartId { get; set; }
        public int IsDone { get; set; }

        public OtherAppShoppingCart? ShoppingCart { get; set; }
    }
}
