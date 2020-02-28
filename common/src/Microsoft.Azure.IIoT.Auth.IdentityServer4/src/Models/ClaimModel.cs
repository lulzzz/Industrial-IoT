// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.Auth.IdentityServer4.Models {
    using Newtonsoft.Json;

    /// <summary>
    /// Instance of Claim.
    /// </summary>
    public class ClaimModel {

        /// <summary>
        /// Claim Type.
        /// </summary>
        [JsonProperty]
        public string Type { get; set; }

        /// <summary>
        /// Claim Value.
        /// </summary>
        [JsonProperty]
        public string Value { get; set; }
    }
}