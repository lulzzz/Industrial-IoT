// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.Services.OpcUa.Events.Controllers {
    using Microsoft.Azure.IIoT.Services.OpcUa.Events.Auth;
    using Microsoft.Azure.IIoT.Services.OpcUa.Events.Filters;
    using Microsoft.Azure.IIoT.Messaging;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using System.Linq;

    /// <summary>
    /// Value and Event monitoring services
    /// </summary>
    [ApiVersion("2")][Route("v{version:apiVersion}/publishers")]
    [ExceptionsFilter]
    [Produces(ContentMimeType.Json)]
    [Authorize(Policy = Policies.CanWrite)]
    [ApiController]
    public class PublishersController : ControllerBase {

        /// <summary>
        /// Create controller with service
        /// </summary>
        /// <param name="events"></param>
        /// <param name="endpoint"></param>
        public PublishersController(IGroupRegistrationT<PublishersHub> events,
            IEndpoint<DiscoveryHub> endpoint) {
            _endpoint = endpoint;
            _events = events;
        }

        /// <summary>
        /// Negotiation method that signalr clients call to get
        /// access token.
        /// </summary>
        /// <returns></returns>
        [HttpPost("events/negotiate")]
        [ProducesResponseType(typeof(JsonResult), 200)]
        [ProducesResponseType(typeof(BadRequestObjectResult), 400)]
        public IActionResult Index() {
            return new JsonResult(new {
                url = _endpoint.EndpointUrl,
                accessToken = _endpoint.GenerateIdentityToken(
                    HttpContext?.User?.Identity?.Name,
                    HttpContext?.User?.Claims?.ToList()).Key
            });
        }

        /// <summary>
        /// Subscribe to receive samples
        /// </summary>
        /// <remarks>
        /// Register a client to receive publisher samples through SignalR.
        /// </remarks>
        /// <param name="endpointId">The endpoint to subscribe to</param>
        /// <param name="userId">The user id that will receive publisher
        /// samples.</param>
        /// <returns></returns>
        [HttpPut("{endpointId}/samples")]
        public async Task SubscribeAsync(string endpointId,
            [FromBody] string userId) {
            await _events.SubscribeAsync(endpointId, userId);
        }

        /// <summary>
        /// Unsubscribe from receiving samples.
        /// </summary>
        /// <remarks>
        /// Unregister a client and stop it from receiving samples.
        /// </remarks>
        /// <param name="endpointId">The endpoint to unsubscribe from
        /// </param>
        /// <param name="userId">The user id that will not receive
        /// any more published samples</param>
        /// <returns></returns>
        [HttpDelete("{endpointId}/samples/{userId}")]
        public async Task UnsubscribeAsync(string endpointId, string userId) {
            await _events.UnsubscribeAsync(endpointId, userId);
        }

        private readonly IEndpoint<DiscoveryHub> _endpoint;
        private readonly IGroupRegistrationT<PublishersHub> _events;
    }
}
