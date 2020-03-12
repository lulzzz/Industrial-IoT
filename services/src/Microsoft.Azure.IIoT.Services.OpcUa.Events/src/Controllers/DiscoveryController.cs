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
    /// Configure discovery
    /// </summary>
    [ApiVersion("2")][Route("v{version:apiVersion}/discovery")]
    [ExceptionsFilter]
    [Produces(ContentMimeType.Json)]
    [Authorize(Policy = Policies.CanWrite)]
    [ApiController]
    public class DiscoveryController : ControllerBase {

        /// <summary>
        /// Create controller for discovery services
        /// </summary>
        /// <param name="events"></param>
        /// <param name="endpoint"></param>
        public DiscoveryController(IGroupRegistrationT<DiscoveryHub> events,
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
        /// Subscribe to discovery progress from discoverer
        /// </summary>
        /// <remarks>
        /// Register a client to receive discovery progress events
        /// through SignalR from a particular discoverer.
        /// </remarks>
        /// <param name="discovererId">The discoverer to subscribe to</param>
        /// <param name="userId">The user id that will receive discovery
        /// events.</param>
        /// <returns></returns>
        [HttpPut("{discovererId}/events")]
        public async Task SubscribeByDiscovererIdAsync(string discovererId,
            [FromBody] string userId) {
            await _events.SubscribeAsync(discovererId, userId);
        }

        /// <summary>
        /// Subscribe to discovery progress for a request
        /// </summary>
        /// <remarks>
        /// Register a client to receive discovery progress events
        /// through SignalR for a particular request.
        /// </remarks>
        /// <param name="requestId">The request to monitor</param>
        /// <param name="userId">The user id that will receive discovery
        /// events.</param>
        /// <returns></returns>
        [HttpPut("requests/{requestId}/events")]
        public async Task SubscribeByRequestIdAsync(string requestId,
            [FromBody] string userId) {
            await _events.SubscribeAsync(requestId, userId);
        }

        /// <summary>
        /// Unsubscribe from discovery progress for a request.
        /// </summary>
        /// <remarks>
        /// Unregister a client and stop it from receiving discovery
        /// events for a particular request.
        /// </remarks>
        /// <param name="requestId">The request to unsubscribe from
        /// </param>
        /// <param name="userId">The user id that will not receive
        /// any more discovery progress</param>
        /// <returns></returns>
        [HttpDelete("requests/{requestId}/events/{userId}")]
        public async Task UnsubscribeByRequestIdAsync(string requestId,
            string userId) {
            await _events.UnsubscribeAsync(requestId, userId);
        }

        /// <summary>
        /// Unsubscribe from discovery progress from discoverer.
        /// </summary>
        /// <remarks>
        /// Unregister a client and stop it from receiving discovery events.
        /// </remarks>
        /// <param name="discovererId">The discoverer to unsubscribe from
        /// </param>
        /// <param name="userId">The user id that will not receive
        /// any more discovery progress</param>
        /// <returns></returns>
        [HttpDelete("{discovererId}/events/{userId}")]
        public async Task UnsubscribeByDiscovererIdAsync(string discovererId,
            string userId) {
            await _events.UnsubscribeAsync(discovererId, userId);
        }

        private readonly IEndpoint<DiscoveryHub> _endpoint;
        private readonly IGroupRegistrationT<DiscoveryHub> _events;
    }
}
