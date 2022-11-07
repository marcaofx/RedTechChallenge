using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedTechnologies.App.Application;
using RedTechnologies.App.Command;
using RedTechnologies.Repository.Repository;
using System;
using System.Threading.Tasks;

namespace RedTechnologies.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private OrderAppService _orderAppService;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderAppService = new OrderAppService(orderRepository, mapper);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(new ResultHttp { Code = 200, Msg = "success", Data = await _orderAppService.GetAllAsync() });
            }
            catch (InvalidOperationException iex)
            {
                return BadRequest(new ResultHttp { Code = 400, Msg = iex.Message, Data = "" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultHttp { Code = 500, Msg = ex.Message, Data = "" });
            }

        }

        [HttpGet("type")]
        public async Task<IActionResult> Get(OrderTypeCommand orderTypeCommand)
        {
            try
            {
                return Ok(new ResultHttp { Code = 200, Msg = "success", Data = await _orderAppService.GetByOrderTypeAsync(orderTypeCommand) });
            }
            catch (InvalidOperationException iex)
            {
                return BadRequest(new ResultHttp { Code = 400, Msg = iex.Message, Data = "" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultHttp { Code = 500, Msg = ex.Message, Data = "" });
            }

        }

        [HttpGet("customer/{name}")]
        public async Task<IActionResult> GetAllCustomerByName(string name)
        {
            try
            {
                return Ok(new ResultHttp { Code = 200, Msg = "success", Data = await _orderAppService.GetAllCustomerNameAsync(name) });
            }
            catch (InvalidOperationException iex)
            {
                return BadRequest(new ResultHttp { Code = 400, Msg = iex.Message, Data = "" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultHttp { Code = 500, Msg = ex.Message, Data = "" });
            }

        }

        [HttpGet("orderById")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            try
            {
                return Ok(new ResultHttp { Code = 200, Msg = "success", Data = await _orderAppService.GetOrderByIdAsync(id) });
            }
            catch (InvalidOperationException iex)
            {
                return BadRequest(new ResultHttp { Code = 400, Msg = iex.Message, Data = "" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultHttp { Code = 500, Msg = ex.Message, Data = "" });
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCommand orderCommand)
        {
            try
            {
                return Ok(new ResultHttp { Code = 200, Msg = "success", Data = await _orderAppService.CreateAsync(orderCommand) });
            }
            catch (InvalidOperationException iex)
            {
                return BadRequest(new ResultHttp { Code = 400, Msg = iex.Message, Data = "" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultHttp { Code = 500, Msg = ex.Message, Data = "" });
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] OrderCommand orderCommand)
        {
            try
            {
                return Ok(new ResultHttp { Code = 200, Msg = "success", Data = await _orderAppService.UpdateAsync(id, orderCommand) });
            }
            catch (InvalidOperationException iex)
            {
                return BadRequest(new ResultHttp { Code = 400, Msg = iex.Message, Data = "" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultHttp { Code = 500, Msg = ex.Message, Data = "" });
            }

        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            try
            {
                return Ok(new ResultHttp { Code = 200, Msg = "success", Data = await _orderAppService.DeleteAsync(id) });
            }
            catch (InvalidOperationException iex)
            {
                return BadRequest(new ResultHttp { Code = 400, Msg = iex.Message, Data = "" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultHttp { Code = 500, Msg = ex.Message, Data = "" });
            }

        }
    }
}
