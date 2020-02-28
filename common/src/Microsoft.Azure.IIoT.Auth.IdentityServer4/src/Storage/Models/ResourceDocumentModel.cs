﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.Auth.IdentityServer4.Models {
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Resource document
    /// </summary>
    public class ResourceDocumentModel {

        /// <summary>
        /// Unique ID of the resource
        /// </summary>
        [JsonProperty("id")]
        public string Name { get; set; }

        /// <summary>
        /// Identity resource or Api resource
        /// </summary>
        [JsonProperty]
        public string ResourceType { get; set; }

        /// <summary>
        /// Display name of the resource.
        /// </summary>
        [JsonProperty]
        public string DisplayName { get; set; }

        /// <summary>
        /// Indicates if this resource is enabled.
        /// Defaults to true.
        /// </summary>
        [JsonProperty]
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Description of the resource.
        /// </summary>
        [JsonProperty]
        public string Description { get; set; }

        /// <summary>
        /// List of associated user claims that should
        /// be included when this resource is requested.
        /// </summary>
        [JsonProperty]
        public List<string> UserClaims { get; set; }

        /// <summary>
        /// The API secret is used for the introspection endpoint.
        /// The API can authenticate with introspection using the
        /// API name and secret.
        /// </summary>
        [JsonProperty]
        public List<SecretModel> ApiSecrets { get; set; }

        /// <summary>
        /// An API must have at least one scope. Each scope can
        /// have different settings.
        /// </summary>
        [JsonProperty]
        public List<ScopeModel> Scopes { get; set; }

        /// <summary>
        /// Specifies whether the user can de-select the scope
        /// on the consent screen (if the consent screen wants
        /// to implement such a feature). Defaults to false.
        /// </summary>
        [JsonProperty]
        public bool Required { get; set; }

        /// <summary>
        /// Specifies whether the consent screen will emphasize
        /// this scope (if the consent screen wants to implement
        /// such a feature).
        /// Use this setting for sensitive or important scopes.
        /// Defaults to false.
        /// </summary>
        [JsonProperty]
        public bool Emphasize { get; set; }

        /// <summary>
        /// Specifies whether this scope is shown in the
        /// discovery document. Defaults to true.
        /// </summary>
        [JsonProperty]
        public bool ShowInDiscoveryDocument { get; set; } = true;
    }
}