using Microsoft.EntityFrameworkCore;
using RedTechnologies.Repository.Enums;
using RedTechnologies.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedTechnologies.Repository.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            using (var dbContext = new dbContext())
                return await dbContext.Orders.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetByOrderTypeAsync(OrderType orderType)
        {
            using (var dbContext = new dbContext())
                return await dbContext.Orders.Where(c => (int)c.Type == (int)orderType).ToListAsync();

        }

        public async Task<Order> GetOrderByIdAsync(Guid id)
        {
            using (var dbContext = new dbContext())
                return await dbContext.Orders.FirstOrDefaultAsync(c => c.Id == id);

        }
        public async Task<bool> CreateAsync(Order order)
        {
            using (var dbContext = new dbContext())
            {
                order.Id = Guid.NewGuid();
                order.CreatedDate = DateTime.UtcNow;
                await dbContext.Orders.AddAsync(order);
                return await dbContext.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateAsync(Guid id, Order order)
        {
            using (var dbContext = new dbContext())
            {
                var orderObj = await dbContext.Orders.FirstOrDefaultAsync(c => c.Id == id);
                if (orderObj == null)
                    throw new InvalidOperationException($"It was not possible to get the order by Id= {id}.The order was not found to update!");

                orderObj.Type = order.Type;
                orderObj.CustomerName = String.IsNullOrEmpty(order.CustomerName) ? orderObj.CustomerName : order.CustomerName;
                orderObj.CreatedByUserName = order.CreatedByUserName == null ? orderObj.CreatedByUserName : order.CreatedByUserName;

                return await dbContext.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            using (var dbContext = new dbContext())
            {
                var orderItem = await dbContext.Orders.FindAsync(id);

                if (orderItem == null)
                    throw new InvalidOperationException($"The Order was not found by Id= {id}.");

                dbContext.Orders.Remove(orderItem);
                return await dbContext.SaveChangesAsync() > 0;
            }
        }

    }
}
