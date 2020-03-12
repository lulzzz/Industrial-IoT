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
    using System.Linq;

    /// <summary>
    /// Supervisor events controller
    /// </summary>
    [ApiVersion("2")]
    [Route("v{version:apiVersion}/supervisors")]
    [ExceptionsFilter]
    [Produces(ContentMimeType.Json)]
    [Authorize(Policy = Policies.CanWrite)]
    [ApiController]
    public class SupervisorsController : ControllerBase {

        /// <summary>
        /// Create controller
        /// </summary>
        /// <param name="endpoint"></param>
        public SupervisorsController(IEndpoint<SupervisorsHub> endpoint) {
            _endpoint = endpoint;
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

        private readonly IEndpoint<SupervisorsHub> _endpoint;
    }
}