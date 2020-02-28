// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.Auth.IdentityServer4.Models {
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// A model for a persisted grant
    /// </summary>
    public class GrantDocumentModel {

        /// <summary>
        /// Unique ID of the client
        /// </summary>
        [JsonProperty("id")]
        public string Key { get; set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        [JsonProperty]
        public string Type { get; set; }

        /// <summary>
        /// Gets the subject identifier.
        /// </summary>
        [JsonProperty]
        public string SubjectId { get; set; }

        /// <summary>
        /// Gets the client identifier.
        /// </summary>
        [JsonProperty]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the creation time.
        /// </summary>
        [JsonProperty]
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the expiration.
        /// </summary>
        [JsonProperty]
        public DateTime? Expiration { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        [JsonProperty]
        public string Data { get; set; }

        /// <summary>
        /// Sets time to live for this grant
        /// </summary>
        [JsonProperty("ttl")]
        public long? TimeToLive =>
            Expiration == null ? (long?)null :
            Math.Max(1,
                (long)(DateTime.UtcNow - Expiration.Value)
                .TotalSeconds);
    }
}