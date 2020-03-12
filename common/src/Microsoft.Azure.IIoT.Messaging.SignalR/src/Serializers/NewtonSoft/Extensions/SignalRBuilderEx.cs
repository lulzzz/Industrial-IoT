// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.AspNetCore.Cors {
    using Microsoft.Azure.IIoT.Serializers;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Microsoft.AspNetCore.SignalR;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using Microsoft.Azure.SignalR;
    using Microsoft.Azure.IIoT.Messaging.SignalR;

    /// <summary>
    /// SignalR setup extensions
    /// </summary>
    public static class SignalRBuilderEx {

        /// <summary>
        /// Add json serializer
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static T AddJsonSerializer<T>(this T builder) where T : ISignalRBuilder {
            if (builder == null) {
                throw new ArgumentNullException(nameof(builder));
            }

            builder = builder.AddNewtonsoftJsonProtocol();

            // Configure json serializer settings transiently to pick up all converters
            builder.Services.AddTransient<IConfigureOptions<NewtonsoftJsonHubProtocolOptions>>(services =>
                new ConfigureNamedOptions<NewtonsoftJsonHubProtocolOptions>(Options.DefaultName, options => {
                    var provider = services.GetService<IJsonSerializerSettingsProvider>();
                    var settings = provider?.Settings;
                    if (settings == null) {
                        return;
                    }

                    options.PayloadSerializerSettings.Formatting = settings.Formatting;
                    options.PayloadSerializerSettings.NullValueHandling = settings.NullValueHandling;
                    options.PayloadSerializerSettings.DefaultValueHandling = settings.DefaultValueHandling;
                    options.PayloadSerializerSettings.ContractResolver = settings.ContractResolver;
                    options.PayloadSerializerSettings.DateFormatHandling = settings.DateFormatHandling;
                    options.PayloadSerializerSettings.MaxDepth = settings.MaxDepth;
                    options.PayloadSerializerSettings.Context = settings.Context;

                    var set = new HashSet<JsonConverter>(options.PayloadSerializerSettings.Converters);
                    if (!set.IsProperSupersetOf(settings.Converters)) {
                        options.PayloadSerializerSettings.Converters =
                            set.MergeWith(settings.Converters).ToList();
                    }
                }));
            return builder;
        }

        /// <summary>
        /// Add json serializer
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static T AddMessagePackSerializer<T>(this T builder) where T : ISignalRBuilder {
            if (builder == null) {
                throw new ArgumentNullException(nameof(builder));
            }

            builder = builder.AddMessagePackProtocol();

            // Configure json serializer settings transiently to pick up all converters
            builder.Services.AddTransient<IConfigureOptions<MessagePackHubProtocolOptions>>(services =>
                new ConfigureNamedOptions<MessagePackHubProtocolOptions>(Options.DefaultName, options => {
                    var provider = services.GetService<IMessagePackFormatterResolverProvider>();
                    var resolvers = provider?.GetResolvers();
                    if (resolvers == null) {
                        return;
                    }
                    options.FormatterResolvers = resolvers.ToList();
                }));
            return builder;
        }

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
