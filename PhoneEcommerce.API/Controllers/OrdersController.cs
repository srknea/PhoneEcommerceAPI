using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneEcommerce.Core.DTOs;
using PhoneEcommerce.Core.Model;
using PhoneEcommerce.Core.Services;
using PhoneEcommerce.Service.Services;

namespace PhoneEcommerce.API.Controllers
{
    [AllowAnonymous]
    public class OrdersController : CustomBaseController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var orders = await _orderService.GetAllAsync();

            var ordersDto = _mapper.Map<List<OrderWithOrderItemsDto>>(orders.ToList());

            return CreateActionResult(CustomResponseDto<List<OrderWithOrderItemsDto>>.Success(200, ordersDto));

        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetById(string orderId)
        {

            var order = await _orderService.GetByIdAsync(orderId);

            var orderDto = _mapper.Map<OrderWithOrderItemsDto>(order);

            return CreateActionResult(CustomResponseDto<OrderWithOrderItemsDto>.Success(200, orderDto));
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDto createOrderDto)
        {
            var order = _mapper.Map<Order>(createOrderDto);
            var createdOrder = await _orderService.AddAsync(order);
            var createdOrderDto = _mapper.Map<OrderWithOrderItemsDto>(createdOrder);
            return CreateActionResult(CustomResponseDto<OrderWithOrderItemsDto>.Success(201, createdOrderDto));
        }

        [HttpPut("{orderId}")]
        public async Task<IActionResult> Update(string orderId, UpdateOrderDto updateVersionDto)
        {

            var order = _mapper.Map<Order>(updateVersionDto);
            order.Id = Guid.Parse(orderId);

            await _orderService.UpdateAsync(order);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> Remove(string orderId)
        {
            var order = await _orderService.GetByIdAsync(orderId);

            await _orderService.RemoveAsync(order);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
