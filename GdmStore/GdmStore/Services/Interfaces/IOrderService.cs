using GdmStore.DTO;
using GdmStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GdmStore.Services.Interfaces
{
    public interface IOrderService : IBaseServices<Order>
    {
        Task<Order> DeleteOrder(int id);
        Task<Order> UpdateOrder(int id, Order order);
        Task<OrderDTO> AddOrders(OrderDTO orderDTO);
        Task<Order> DeleteOrders(int id);
        Task<Product> UpdateOrderAmount(int id);
        Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<OrderPDTO>> GetOrderProduct();
        Task<IEnumerable<OrderPDTO>> GetOrderByNameCompany(string nameCompany);
    }
}
