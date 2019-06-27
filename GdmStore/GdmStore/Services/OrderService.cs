using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GdmStore.Models;
using GdmStore.DTO;
using GdmStore.Controllers;
using Microsoft.EntityFrameworkCore;
using GdmStore.Services.Interfaces;

namespace GdmStore.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        private readonly DataContext _context;

        public OrderService(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Order> DeleteOrder(int id)
        {
            Order order = _context.Orders
              .Where(o => o.Id == id)
              .FirstOrDefault();

            var product = _context.OrderProducts
                                  .Include(k => k.Product)
                                  .Where(f => f.OrderId == id).Select(dd => dd.Product).FirstOrDefault();
            if (product != null)
            {
                await UpdateOrderAmount(id);
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> UpdateOrder(int id, Order order)
        {
            Order p = await GetItem(order.Id);
            p.NameCompany = order.NameCompany;
            p.Price = order.Price;
            p.DateTime = order.DateTime;

            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<OrderDTO> AddOrders(OrderDTO orderDTO)
        {
            var EntryOrder = _context.Orders.Find(orderDTO.Id);
            if (EntryOrder != null) return orderDTO;

            var order = new Order
            {
                Id = orderDTO.Id,
                NameCompany = orderDTO.NameCompany,
                Price = orderDTO.Price,
                DateTime = DateTime.Now

            };

            _context.Orders.Add(order);

            var orderProduct = new OrderProduct
            {  
                OrderId = order.Id,
                ProductId = orderDTO.ProductId,
                Amount = orderDTO.Amount
            };

            _context.OrderProducts.Add(orderProduct);

         
            Product product = _context.Products.Find(orderDTO.ProductId);
            if(product.Amount >= orderDTO.Amount)
            {
                var newAmout = product.Amount - orderDTO.Amount;
                product.Amount = Math.Round(newAmout, 2);
                await _context.SaveChangesAsync();
            }
            else
            {
               return null;
            }
            
            return orderDTO;
        }

        public async Task<Order> DeleteOrders(int id)
        {
            var order =  _context.Orders
                   .Include(p => p.OrderProduct)
                   .Where(i => i.Id == id)
                   .FirstOrDefault();

            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Product> UpdateOrderAmount(int id)
        {
            Product pr = _context.OrderProducts
                           .Include(aa => aa.Product)
                           .Where(k => k.OrderId == id).Select(dd => dd.Product).FirstOrDefault();

            var valueAmount = _context.OrderProducts
                            .Include(op => op.Product)
                            .Include(prod => prod.Order)
                            .Where(i => i.Order.Id == id)
                            .FirstOrDefault().Product.Amount;

            var valueOPAmount = _context.OrderProducts
                             .Include(op => op.Product)
                             .Include(prod => prod.Order)
                             .Where(i => i.Order.Id == id)
                             .FirstOrDefault().Amount;

            pr.Amount = valueAmount + valueOPAmount;
            await _context.SaveChangesAsync();

            return pr;
        }



        public async Task<IEnumerable<Order>> GetOrders()
        {
            var order = await _context.Orders
                                      .Include(o => o.OrderProduct)
                                      .Select(t => new Order
                                      {  
                                          Id = t.Id,
                                          NameCompany = t.NameCompany,
                                          Price = t.Price,
                                          DateTime = t.DateTime,
                                          OrderProduct = t.OrderProduct.Select( h => new OrderProduct
                                          {   
                                              Id = h.Id,
                                              Amount = h.Amount,
                                              OrderId = h.Order.Id,
                                              ProductId = h.Product.Id
       
                                          }).ToList(),
                                          
                                      })
                                      .ToListAsync();

            return order;

        }

        public async Task<IEnumerable<OrderPDTO>> GetOrderProduct()
        {
            var order = await _context.Orders
                                      .Include(o => o.OrderProduct)
                                        .ThenInclude(op => op.Product)
                                      .Select(t => new OrderPDTO
                                      {
                                          Id = t.Id,
                                          NameCompany = t.NameCompany,
                                          Price = t.Price,
                                          DateTime = t.DateTime,
                                          OrderProducts = t.OrderProduct.Select(jj => new OrderProductDTO {
                                              Amount = jj.Amount,
                                              ProductId = jj.ProductId,
                                              OrderId = jj.OrderId
                                          }).ToList(),
                                          ProductOrders = t.OrderProduct.Select(jj => new ProductOrderDTO
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

        public async Task<IEnumerable<OrderPDTO>> GetOrderByNameCompany(string nameCompany)
        {
            var order = await _context.Orders
                                      .Include(o => o.OrderProduct)
                                        .ThenInclude(op => op.Product)
                                      .Where(s => s.NameCompany == nameCompany)
                                      .Select(t => new OrderPDTO
                                      {
                                          Id = t.Id,
                                          NameCompany = t.NameCompany,
                                          Price = t.Price,
                                          DateTime = t.DateTime,
                                          OrderProducts = t.OrderProduct.Select(jj => new OrderProductDTO
                                          {
                                              Amount = jj.Amount,
                                              ProductId = jj.ProductId,
                                              OrderId = jj.OrderId
                                          }).ToList(),
                                          ProductOrders = t.OrderProduct.Select(jj => new ProductOrderDTO
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



        //public async Task<IEnumerable<OrderPDTO>> GetOrderByPruductId(int id)
        //{
        //    var order = await _context.Orders
        //                              .Include(o => o.OrderProduct)
        //                                .ThenInclude(op => op.Product)
        //                              .Where(or => or.OrderProduct.Where(b => b.ProductId == id))
        //                              .Select(t => new OrderPDTO
        //                              {
        //                                  Id = t.Id,
        //                                  NameCompany = t.NameCompany,
        //                                  Price = t.Price,
        //                                  DateTime = t.DateTime,
        //                                  OrderProducts = t.OrderProduct.Select(jj => new OrderProductDTO
        //                                  {
        //                                      Amount = jj.Amount,
        //                                      ProductId = jj.ProductId,
        //                                      OrderId = jj.OrderId
        //                                  }).ToList(),
        //                                  ProductOrders = t.OrderProduct.Select(jj => new ProductOrderDTO
        //                                  {
        //                                      Number = jj.Product.Number,
        //                                      Manufacturer = jj.Product.Manufacturer,
        //                                      NameType = jj.Product.ProductType.NameType,
        //                                      PrimeCostEUR = jj.Product.PrimeCostEUR
        //                                  }).ToList(),

        //                              })
        //                              .ToListAsync();

        //    return order;

        //}
    }
}
