using RedTechnologies.Repository.Enums;
using RedTechnologies.Repository.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedTechnologies.Repository.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<IEnumerable<Order>> GetByOrderTypeAsync(OrderType orderType);
        Task<bool> CreateAsync(Order order);
        Task<bool> UpdateAsync(Guid id, Order order);
        Task<bool> DeleteAsync(Guid id);

    }
}
