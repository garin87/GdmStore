using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GdmStore.Models;
using GdmStore.Services;
using GdmStore.DTO;
using Microsoft.EntityFrameworkCore;
using GdmStore.Services.Interfaces;

namespace GdmStore.Services
{
    public class OrderProductService : BaseService<OrderProduct>, IOrderProductService
    {
        private readonly DataContext _context;

        private readonly OrderService _orderServise;

        public OrderProductService(DataContext context) : base(context)
        {
            _context = context;
        }
   
        public async Task<OrderProduct> UpdateOrderProduct(int id, OrderProduct orderProduct)
        {
            OrderProduct p = await GetItem(orderProduct.Id);
            p.Amount = orderProduct.Amount;
            p.Order = orderProduct.Order;
            p.Product = orderProduct.Product;

            await _context.SaveChangesAsync();

            return orderProduct;
        }

        public async Task<OrderProduct> UpdateOrderP(OrderDTO orderDTO)
        {
            OrderProduct op = await GetItem(orderDTO.OrderProductId);
            Order o = _context.Orders.Find(orderDTO.OrderId);
            Product product = _context.Products.Find(orderDTO.ProductId);
            await _orderServise.DeleteOrder(o.Id);

            op.Amount = orderDTO.Amount;
            o.NameCompany = orderDTO.NameCompany;
            o.Price = orderDTO.Price;

           
            if (product.Amount >= orderDTO.Amount)
            {
                var newAmout = product.Amount - orderDTO.Amount;
                product.Amount = Math.Round(newAmout, 2);
                await _context.SaveChangesAsync();
            }
            else
            {
                return null;
            }


            return op;
        }


        public async Task<IEnumerable<OrderPDTO>> GetOrderByPruductId(int id)
        {
            var order = await _context.OrderProducts
                                      .Include(o => o.Order)
                                      .Include(op => op.Product)
                                      .Where(or => or.Product.Id == id)
                                      .Select(t => new OrderPDTO
                                      {
                                          Id = t.Id,
                                          NameCompany = t.Order.NameCompany,
                                          Price = t.Order.Price,
                                          DateTime = t.Order.DateTime,
                                          OrderProducts = t.Order.OrderProduct.Select(jj => new OrderProductDTO
                                          {   OrderProductId = jj.Id,
                                              Amount = jj.Amount,
                                              ProductId = jj.ProductId,
                                              OrderId = jj.OrderId
                                          }).ToList(),
                                          ProductOrders = t.Order.OrderProduct.Select(jj => new ProductOrderDTO
                                          {
                                              Number = jj.Product.Number,
                                              Manufacturer = jj.Product.Manufacturer,
                                              NameType = jj.Product.ProductType.NameType,
                                              PrimeCostEUR = jj.Product.PrimeCostEUR
                                          }).ToList(),

                                      })
                                      .ToListAsync();

            return order;

        }

        public async Task<IEnumerable<OrderPDTO>> GetOrderByOrderId(int id)
        {
            var order = await _context.OrderProducts
                                      .Include(o => o.Order)
                                      .Include(op => op.Product)
                                      .Where(o => o.Order.Id == id)
                                      .Select(t => new OrderPDTO
                                      {
                                          Id = t.Id,
                                          NameCompany = t.Order.NameCompany,
                                          Price = t.Order.Price,
                                          DateTime = t.Order.DateTime,
                                          OrderProducts = t.Order.OrderProduct.Select(jj => new OrderProductDTO
                                          {
                                              OrderProductId = jj.Id,
                                              Amount = jj.Amount,
                                              ProductId = jj.ProductId,
                                              OrderId = jj.OrderId
                                          }).ToList(),
                                          ProductOrders = t.Order.OrderProduct.Select(jj => new ProductOrderDTO
                                          {
                                              Number = jj.Product.Number,
                                              Manufacturer = jj.Product.Manufacturer,
                                              NameType = jj.Product.ProductType.NameType,
                                              PrimeCostEUR = jj.Product.PrimeCostEUR
                                          }).ToList(),

                                      })
                                      .ToListAsync();

            return order;

        }

    }
}
