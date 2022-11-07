using RedTechnologies.Repository.Enums;
using RedTechnologies.Repository.Models;
using RedTechnologies.Repository.Repository;
using RedTechnologies.App.Command;
using System;
using RedTechnologies.App.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace RedTechnologies.App.Application
{
    public class OrderAppService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderAppService(IOrderRepository orderRepository, IMapper mapper)
        {
            this._orderRepository = orderRepository;
            this._mapper = mapper;
        }

        public async Task<List<OrderViewModel>> GetAllAsync()
        {
            var orders= await _orderRepository.GetAllAsync();
            return _mapper.Map<List<OrderViewModel>>(orders);
        }

        public async Task<List<OrderViewModel>> GetAllCustomerNameAsync(string customerName)
        {
            var orders = await _orderRepository.GetAllCustomerByNameAsync(customerName);
            return _mapper.Map<List<OrderViewModel>>(orders);
        }
        public async Task<List<OrderViewModel>> GetByOrderTypeAsync(OrderTypeCommand orderTypeCommand)
        {
            var orders = await _orderRepository.GetByOrderTypeAsync((OrderType)orderTypeCommand);
            return _mapper.Map<List<OrderViewModel>>(orders);
        }

        public async Task<OrderViewModel> GetOrderByIdAsync(Guid id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            return _mapper.Map<OrderViewModel>(order);
        }

        public async Task<bool> CreateAsync(OrderCommand orderCommand)
        {
            var order = _mapper.Map<Order>(orderCommand);
            return await _orderRepository.CreateAsync(order);
        }

        public async Task<bool> UpdateAsync(Guid id, OrderCommand orderCommand)
        {
            var order= _mapper.Map<Order>(orderCommand);
            return await _orderRepository.UpdateAsync(id, order);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _orderRepository.DeleteAsync(id);

        }

    }
}
