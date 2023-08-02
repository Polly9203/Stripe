using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stripe.BLL.Subscriptions.Commands.Cancel;
using Stripe.BLL.Subscriptions.Commands.Create;

namespace Stripe.PL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionController : BaseController
    {
        public SubscriptionController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> CreateSubscription([FromBody] CreateSubscriptionCommand command)
        {
            try
            {
                var result = await Mediator.Send(command);

                return Ok($"Subscription id: {result}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> CancelSubscription([FromBody] CancelSubscriptionCommand command)
        {
            try
            {
                var result = await Mediator.Send(command);

                return Ok($"Subscription {result}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };
        }
    }
}
