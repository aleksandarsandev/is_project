using FoodDeliveryApp.Domain.Domain;
using FoodDeliveryApp.Repository;
using FoodDeliveryApp.Repository.Interface;
using FoodDeliveryApp.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Service.Implementation
{
    public class OrderService : IOrderService
    {

        private readonly IRepository<Order> _orderRepository;
        private readonly ApplicationDbContext _context;

        public OrderService(IRepository<Order> orderRepository, ApplicationDbContext context)
        {
            _orderRepository = orderRepository;
            _context = context;
        }

        public void CreateNewOrder(Order f)
        {
            _orderRepository.Insert(f);
            //DeliveryOrder deliveryOrder = f.DeliveryOrder;
            //if (!deliveryOrder.Orders.Contains(f))
            //{
            //    deliveryOrder.Orders.Add(f);
            //}
            //_context.SaveChanges();
        }

        public void DeleteOrder(Guid id)
        {
            Order order = _orderRepository.Get(id);
            _orderRepository.Delete(order);
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAll().ToList();
        }

        public Order GetDetailsForOrder(Guid? id)
        {
            return _orderRepository.Get(id);
        }

        public void UpdateExistingOrder(Order f)
        {
            var exsistingOrder = _orderRepository.Get(f.Id);
            if(exsistingOrder == null)
            {
                throw new ArgumentException("Order not found");
            }
            exsistingOrder.DeliveryOrder = f.DeliveryOrder;
            exsistingOrder.DeliveryOrderId = f.DeliveryOrderId;
            exsistingOrder.FoodItemId = f.FoodItemId;
            exsistingOrder.FoodItem = f.FoodItem;

            // Mark the existing entity as modified
            _context.Entry(exsistingOrder).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
