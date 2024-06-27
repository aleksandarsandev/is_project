using FoodDeliveryApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Service.Interface
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetDetailsForOrder(Guid? id);
        void CreateNewOrder(Order f);
        void UpdateExistingOrder(Order f);
        void DeleteOrder(Guid id);
    }
}
