using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Stripe.PL.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IMediator Mediator { get; set; }

        public BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
