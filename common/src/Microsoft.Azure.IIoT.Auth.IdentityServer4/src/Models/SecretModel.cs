// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.Auth.IdentityServer4.Models {
    using System;
    using Newtonsoft.Json;
    using global::IdentityServer4;

    /// <summary>
    /// Models a client secret with identifier and expiration
    /// </summary>
    public class SecretModel {

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [JsonProperty]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [JsonProperty]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the expiration.
        /// </summary>
        [JsonProperty]
        public DateTime? Expiration { get; set; }

        /// <summary>
        /// Gets or sets the type of the client secret.
        /// </summary>
        [JsonProperty]
        public string Type { get; set; } =
            IdentityServerConstants.SecretTypes.SharedSecret;
    }
}