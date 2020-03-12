﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.Services.OpcUa.Events {
    using Microsoft.Azure.IIoT.Messaging.SignalR;
    using Microsoft.AspNetCore.SignalR;

    /// <summary>
    /// Supervisors hub
    /// </summary>
    [Route("v2/supervisors/events")]
    public class SupervisorsHub : Hub {

    }
}