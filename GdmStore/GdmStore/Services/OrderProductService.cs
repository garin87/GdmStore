using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GdmStore.Models;
using GdmStore.DTO;
using Microsoft.EntityFrameworkCore;

namespace GdmStore.Services
{
    public class OrderProductService
    {
        private readonly DataContext _context;

        public OrderProductService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<OrderProduct> GetAll()
        {
            return _context.OrderProducts.ToList();
        }

        public async Task<OrderProduct> GetOrderProduct(int id)
        {
            return await _context.OrderProducts.FindAsync(id);
        }

        public async Task<OrderProduct> AddOrderProduct(OrderProduct orderProduct)
        {
            _context.OrderProducts.Add(orderProduct);
            await _context.SaveChangesAsync();
            return orderProduct;
        }

        public async Task<OrderProduct> DeleteOrderProduct(int id)
        {
            OrderProduct orderProduct = _context.OrderProducts
              .Where(o => o.Id == id)
              .FirstOrDefault();

            _context.OrderProducts.Remove(orderProduct);
            await _context.SaveChangesAsync();
            return orderProduct;
        }

        public async Task<OrderProduct> UpdateOrderProduct(int id, OrderProduct orderProduct)
        {
            OrderProduct p = await GetOrderProduct(orderProduct.Id);
            p.Amount = orderProduct.Amount;
            p.Order = orderProduct.Order;
            p.Product = orderProduct.Product;

            await _context.SaveChangesAsync();

            return orderProduct;
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
                                          {
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
