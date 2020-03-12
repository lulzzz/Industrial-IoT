// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Extensions.DependencyInjection {
    using Microsoft.Extensions.Options;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.Azure.IIoT.Messaging.SignalR;
    using Microsoft.Azure.SignalR;

    /// <summary>
    /// SignalR setup extensions
    /// </summary>
    public static class SignalRBuilderEx {

        /// <summary>
        /// Add azure signalr if possible
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static ISignalRServerBuilder AddAzureSignalRService(this ISignalRServerBuilder builder,
            ISignalRServiceConfig config = null) {
            if (config != null && string.IsNullOrEmpty(config.SignalRConnString)) {
                // not using signalr service
                return builder;
            }

            builder = builder.AddAzureSignalR();
            builder.Services.AddTransient<IConfigureOptions<ServiceOptions>>(services =>
                new ConfigureNamedOptions<ServiceOptions>(Options.DefaultName, options => {
                    if (config == null) {
                        config = services.GetService<ISignalRServiceConfig>();
                    }
                    if (config != null) {
                        options.ConnectionString = config.SignalRConnString;
                        options.ConnectionCount = 100; // TODO
                        options.ServerStickyMode = ServerStickyMode.Preferred;
                    }
                }));
            return builder;
        }
    }
}
