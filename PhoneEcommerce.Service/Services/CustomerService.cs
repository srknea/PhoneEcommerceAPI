using AutoMapper;
using PhoneEcommerce.Core.DTOs;
using PhoneEcommerce.Core.Model;
using PhoneEcommerce.Core.Repositories;
using PhoneEcommerce.Core.Services;
using PhoneEcommerce.Core.UnitOfWork;
using PhoneEcommerce.Repository.Repositories;
using PhoneEcommerce.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Service.Services
{
    public class CustomerService : GenericService<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(IGenericRepository<Customer> repository, IUnitOfWork unitOfWork, IMapper mapper, ICustomerRepository customerRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<CustomResponseDto<CustomerWithOrdersDto>> GetSingleCustomerByIdWithOrdersAsync(string customerId)
        {
            var hasCustomer = await _customerRepository.GetByIdAsync(customerId);

            if (hasCustomer == null)
            {
                throw new NotFoundException($"Customer with Id '{customerId}' not found");
            }

            var order = await _customerRepository.GetSingleCustomerByIdWithOrdersAsync(customerId);

            var orderDto = _mapper.Map<CustomerWithOrdersDto>(order);

            return CustomResponseDto<CustomerWithOrdersDto>.Success(200, orderDto);
        }
    }
}