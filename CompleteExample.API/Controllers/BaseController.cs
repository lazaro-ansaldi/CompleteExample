using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CompleteExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IMediator MediatorBroker { get; }

        public BaseController(IMediator mediator)
        {
            MediatorBroker = mediator;
        }
    }
}
