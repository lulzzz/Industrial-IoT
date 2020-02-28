// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.Auth.IdentityServer4.Models {
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Role document
    /// </summary>
    public class RoleDocumentModel {

        /// <summary>
        /// Role id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Etag
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string ConcurrencyStamp { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty]
        public string Name { get; set; }

        /// <summary>
        /// Normalized name
        /// </summary>
        [JsonProperty]
        public string NormalizedName { get; set; }

        /// <summary>
        /// Claims
        /// </summary>
        [JsonProperty]
        public List<ClaimModel> Claims { get; set; }
    }
}
