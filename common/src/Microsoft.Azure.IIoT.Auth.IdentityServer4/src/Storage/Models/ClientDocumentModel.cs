﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.Auth.IdentityServer4.Models {
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using global::IdentityServer4;
    using global::IdentityServer4.Models;

    /// <summary>
    /// Models an OpenID Connect or OAuth2 client
    /// </summary>
    public class ClientDocumentModel {

        /// <summary>
        /// Unique ID of the client
        /// </summary>
        [JsonProperty("id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Specifies if client is enabled
        /// </summary>
        [JsonProperty]
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the protocol type.
        /// </summary>
        [JsonProperty]
        public string ProtocolType { get; set; } =
            IdentityServerConstants.ProtocolTypes.OpenIdConnect;

        /// <summary>
        /// Client secrets - only relevant for flows that
        /// require a secret
        /// </summary>
        [JsonProperty]
        public List<SecretModel> ClientSecrets { get; set; }

        /// <summary>
        /// If set to false, no client secret is needed to
        /// request tokens at the token endpoint
        /// </summary>
        [JsonProperty]
        public bool RequireClientSecret { get; set; } = true;

        /// <summary>
        /// Client display name
        /// </summary>
        [JsonProperty]
        public string ClientName { get; set; }

        /// <summary>
        /// Describes the client
        /// </summary>
        [JsonProperty]
        public string Description { get; set; }

        /// <summary>
        /// URI to further information about client
        /// </summary>
        [JsonProperty]
        public string ClientUri { get; set; }

        /// <summary>
        /// URI to client logo
        /// </summary>
        [JsonProperty]
        public string LogoUri { get; set; }

        /// <summary>
        /// Specifies whether a consent screen is required.
        /// </summary>
        [JsonProperty]
        public bool RequireConsent { get; set; } = true;

        /// <summary>
        /// Specifies whether user can choose to store
        /// consent decisions.
        /// </summary>
        [JsonProperty]
        public bool AllowRememberConsent { get; set; } = true;

        /// <summary>
        /// When requesting both an id token and access token,
        /// should the user claims always be added to the
        /// id token instead of requiring the client
        /// to use the userinfo endpoint.
        /// </summary>
        [JsonProperty]
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; }

        /// <summary>
        /// Specifies the allowed grant types (legal
        /// combinations of AuthorizationCode, Implicit,
        /// Hybrid, ResourceOwner, ClientCredentials).
        /// </summary>
        [JsonProperty]
        public List<string> AllowedGrantTypes { get; set; }

        /// <summary>
        /// Specifies whether a proof key is required for
        /// authorization code based token requests
        /// defaults to false.
        /// </summary>
        [JsonProperty]
        public bool RequirePkce { get; set; }

        /// <summary>
        /// Specifies whether a proof key can be sent using
        /// plain method
        /// </summary>
        [JsonProperty]
        public bool AllowPlainTextPkce { get; set; }

        /// <summary>
        /// Controls whether access tokens are transmitted
        /// via the browser for this client.
        /// This can prevent accidental leakage of access
        /// tokens when multiple response types are allowed.
        /// </summary>
        [JsonProperty]
        public bool AllowAccessTokensViaBrowser { get; set; }

        /// <summary>
        /// Specifies allowed URIs to return tokens or
        /// authorization codes to
        /// </summary>
        [JsonProperty]
        public List<string> RedirectUris { get; set; }

        /// <summary>
        /// Specifies allowed URIs to redirect to after logout
        /// </summary>
        [JsonProperty]
        public List<string> PostLogoutRedirectUris { get; set; }

        /// <summary>
        /// Specifies logout URI at client for HTTP
        /// front-channel based logout.
        /// </summary>
        [JsonProperty]
        public string FrontChannelLogoutUri { get; set; }

        /// <summary>
        /// Specifies is the user's session id should be
        /// sent to the FrontChannelLogoutUri.
        /// </summary>
        [JsonProperty]
        public bool FrontChannelLogoutSessionRequired { get; set; } = true;

        /// <summary>
        /// Specifies logout URI at client for HTTP
        /// back-channel based logout.
        /// </summary>
        [JsonProperty]
        public string BackChannelLogoutUri { get; set; }

        /// <summary>
        /// Specifies is the user's session id should be
        /// sent to the BackChannelLogoutUri.
        /// </summary>
        [JsonProperty]
        public bool BackChannelLogoutSessionRequired { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether to allow
        /// offline access.
        /// </summary>
        [JsonProperty]
        public bool AllowOfflineAccess { get; set; }

        /// <summary>
        /// Specifies the api scopes that the client
        /// is allowed to request. If empty, the client
        /// can't access any scope
        /// </summary>
        [JsonProperty]
        public List<string> AllowedScopes { get; set; }

        /// <summary>
        /// Lifetime of identity token in seconds
        /// </summary>
        [JsonProperty]
        public int IdentityTokenLifetime { get; set; } = 300;

        /// <summary>
        /// Lifetime of access token in seconds
        /// </summary>
        [JsonProperty]
        public int AccessTokenLifetime { get; set; } = 3600;

        /// <summary>
        /// Lifetime of authorization code in seconds
        /// </summary>
        [JsonProperty]
        public int AuthorizationCodeLifetime { get; set; } = 300;

        /// <summary>
        /// Lifetime of a user consent in seconds.
        /// </summary>
        [JsonProperty]
        public int? ConsentLifetime { get; set; }

        /// <summary>
        /// Maximum lifetime of a refresh token in seconds.
        /// </summary>
        [JsonProperty]
        public int AbsoluteRefreshTokenLifetime { get; set; } =
            2592000;

        /// <summary>
        /// Sliding lifetime of a refresh token in seconds.
        /// </summary>
        [JsonProperty]
        public int SlidingRefreshTokenLifetime { get; set; } =
            1296000;

        /// <summary>
        /// ReUse or one time refresh token
        /// </summary>
        [JsonProperty]
        public int RefreshTokenUsage { get; set; } =
            (int)TokenUsage.OneTimeOnly;

        /// <summary>
        /// Gets or sets a value indicating whether the access
        /// token (and its claims) should be updated on a
        /// refresh token request.
        /// </summary>
        [JsonProperty]
        public bool UpdateAccessTokenClaimsOnRefresh { get; set; }

        /// <summary>
        /// Absolute: the refresh token will expire on a fixed
        /// point in time (specified by the AbsoluteRefreshTokenLifetime)
        /// Sliding: when refreshing the token, the lifetime
        /// of the refresh token will be renewed (by the amount
        /// specified in SlidingRefreshTokenLifetime). The lifetime
        /// will not exceed AbsoluteRefreshTokenLifetime.
        /// Default value is Absolute (1).
        /// </summary>
        [JsonProperty]
        public int RefreshTokenExpiration { get; set; } =
            (int)TokenExpiration.Absolute;

        /// <summary>
        /// Specifies whether the access token is a reference token
        /// or a self contained JWT token
        /// </summary>
        [JsonProperty]
        public int AccessTokenType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the
        /// local login is allowed for this client.
        /// </summary>
        [JsonProperty]
        public bool EnableLocalLogin { get; set; } = true;

        /// <summary>
        /// Specifies which external IdPs can be used with this
        /// client (if list is empty all providers are allowed).
        /// </summary>
        [JsonProperty]
        public List<string> IdentityProviderRestrictions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether JWT access
        /// tokens should include an identifier.
        /// </summary>
        [JsonProperty]
        public bool IncludeJwtId { get; set; }

        /// <summary>
        /// Allows settings claims for the client (will be
        /// included in the access token).
        /// </summary>
        [JsonProperty]
        public List<ClaimModel> Claims { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether client claims
        /// should be always included in the access tokens -
        /// or only for client credentials flow.
        /// </summary>
        [JsonProperty]
        public bool AlwaysSendClientClaims { get; set; }

        /// <summary>
        /// Gets or sets a value to prefix it on client claim types.
        /// </summary>
        [JsonProperty]
        public string ClientClaimsPrefix { get; set; } = "client_";

        /// <summary>
        /// Gets or sets a salt value used in pair-wise subjectId
        /// generation for users of this client.
        /// </summary>
        [JsonProperty]
        public string PairWiseSubjectSalt { get; set; }

        /// <summary>
        /// Gets or sets the allowed CORS origins for clients.
        /// </summary>
        [JsonProperty]
        public List<string> AllowedCorsOrigins { get; set; }

        /// <summary>
        /// Gets or sets the custom properties for the client.
        /// </summary>
        [JsonProperty]
        public Dictionary<string, string> Properties { get; set; }
    }
}