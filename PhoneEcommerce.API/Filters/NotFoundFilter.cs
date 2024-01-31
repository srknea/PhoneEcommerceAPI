using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PhoneEcommerce.Core.DTOs;
using PhoneEcommerce.Core.Model;
using PhoneEcommerce.Core.Services;
using PhoneEcommerce.Service.Services;

namespace PhoneEcommerce.API.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IGenericService<T> _genericService;

        public NotFoundFilter(IGenericService<T> genericService)
        {
            _genericService = genericService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();

            if (idValue == null) {
                await next.Invoke();
            }

            var id = (Guid)idValue;
            var anyEntity = await _genericService.AnyAsync(x => x.Id == id);

            if (anyEntity) {
                await next.Invoke();
                return; 
            }

            context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404,$"{typeof(T).Name } ({id}) not found" ));
        }
    }
}
