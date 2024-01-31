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
    public class CustomerController : CustomBaseController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{customerId}/orders")]
        public async Task<IActionResult> GetSingleCustomerByIdWithOrders(string customerId)
        {
            return CreateActionResult(await _customerService.GetSingleCustomerByIdWithOrdersAsync(customerId));
        }
    }
}
