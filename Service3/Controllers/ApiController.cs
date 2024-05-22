using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Service3.Controllers
{
    public class ApiController : ControllerBase
    {
        private ISender? _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    }
}
