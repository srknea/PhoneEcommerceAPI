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

            var ordersDto = _mapper.Map<List<OrderDto>>(orders.ToList());

            return CreateActionResult(CustomResponseDto<List<OrderDto>>.Success(200, ordersDto));

        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetById(int orderId)
        {

            var order = await _orderService.GetByIdAsync(orderId);

            var orderDto = _mapper.Map<OrderDto>(order);

            return CreateActionResult(CustomResponseDto<OrderDto>.Success(200, orderDto));
        }

        /*
        [HttpPost]
        public async Task<IActionResult> Save(ModelDto dto)
        {
            var model = await _modelService.AddAsync(_mapper.Map<Model>(dto));

            var modelDto = _mapper.Map<ModelDto>(model);

            return CreateActionResult(CustomResponseDto<ModelDto>.Success(201, modelDto));
            // 201 : Oluşturuldu anlamında kullanılır. İşlem başarılı ise 201 döndürülebilir.
        }
        */


        [HttpPut("{orderId}")]
        public async Task<IActionResult> Update(int orderId, UpdateOrderDto updateVersionDto)
        {

            var order = _mapper.Map<Order>(updateVersionDto);
            order.Id = orderId;

            await _orderService.UpdateAsync(order);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> Remove(int orderId)
        {
            var order = await _orderService.GetByIdAsync(orderId);

            await _orderService.RemoveAsync(order);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
