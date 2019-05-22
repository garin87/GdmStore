using GdmStore.DTO;
using GdmStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GdmStore.Services.Interfaces
{
      interface IOrderProductService : IBaseServices<OrderProduct>
    {
        Task<OrderProduct> UpdateOrderProduct(int id, OrderProduct orderProduct);
        Task<OrderProduct> UpdateOrderP(OrderDTO orderDTO);
        Task<IEnumerable<OrderPDTO>> GetOrderByPruductId(int id);
    }
}
