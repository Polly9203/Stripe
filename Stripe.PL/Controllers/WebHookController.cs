﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe.BLL;
using Stripe.BLL.WebHooks;

namespace Stripe.PL.Controllers
{
    [ApiController]
    [Route("Webhooks")]
    public class WebHookController : ControllerBase
    {
        private readonly IWebHookService _webHookService;
        private readonly StripeSettings stripeSettings;
        public WebHookController(IWebHookService webHookService, IOptions<StripeSettings> stripeSettings)
        {
            _webHookService = webHookService;
            this.stripeSettings = stripeSettings.Value;
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> HandleStripeWebhook()
        {
            using var reader = new StreamReader(Request.Body);
            var json = await reader.ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers[stripeSettings.Headers], stripeSettings.WebHookKey);

                if (stripeEvent.Type == Events.CustomerSubscriptionCreated)

                {
                    await _webHookService.SubscriptionCreated(stripeEvent);
                }

                return Ok();
            }
            catch (StripeException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
