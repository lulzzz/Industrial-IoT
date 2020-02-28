// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.Auth.IdentityServer4.Models {
    using Microsoft.AspNetCore.Identity;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// User document
    /// </summary>
    public class UserDocumentModel {

        /// <summary>
        /// Unique ID of the user
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Etag
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string ConcurrencyStamp { get; set; }

        /// <summary>
        /// Gets or sets the user name for this user.
        /// </summary>
        [JsonProperty]
        public string UserName { get; set; }

        /// <summary>
        /// Login providers
        /// </summary>
        [JsonProperty]
        public List<LoginModel> Logins { get; set; }

        /// <summary>
        /// Roles this user has
        /// </summary>
        [JsonProperty]
        public List<string> Roles { get; set; }

        /// <summary>
        /// Claims
        /// </summary>
        [JsonProperty]
        public List<ClaimModel> Claims { get; set; }

        /// <summary>
        /// Recovery codes
        /// </summary>
        [JsonProperty]
        public List<string> RecoveryCodes { get; set; }

        /// <summary>
        /// Gets or sets the normalized user name for this user.
        /// </summary>
        [JsonProperty]
        public string NormalizedUserName { get; set; }

        /// <summary>
        /// Gets or sets the email address for this user.
        /// </summary>
        [JsonProperty]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the normalized email address
        /// for this user.
        /// </summary>
        [JsonProperty]
        public string NormalizedEmail { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if a user has
        /// confirmed their email address.
        /// </summary>
        [JsonProperty]
        public bool EmailConfirmed { get; set; }

        /// <summary>
        /// Gets or sets a salted and hashed representation
        /// of the password for this
        /// user.
        /// </summary>
        [JsonProperty]
        public string PasswordHash { get; set; }

        /// <summary>
        /// A random value that must change whenever a users
        /// credentials change (password changed, login removed)
        /// </summary>
        [JsonProperty]
        public string SecurityStamp { get; set; }

        /// <summary>
        /// Gets or sets a telephone number for the user.
        /// </summary>
        [JsonProperty]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if a user has
        /// confirmed their telephone address.
        /// </summary>
        [JsonProperty]
        public bool PhoneNumberConfirmed { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if two factor
        /// authentication is enabled for
        /// this user.
        /// </summary>
        [JsonProperty]
        public bool TwoFactorEnabled { get; set; }

        /// <summary>
        /// Gets or sets the date and time, in UTC, when
        /// any user lockout ends.
        /// </summary>
        [JsonProperty]
        public DateTimeOffset? LockoutEnd { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if the user
        /// could be locked out.
        /// </summary>
        [JsonProperty]
        public bool LockoutEnabled { get; set; }

        /// <summary>
        /// Gets or sets the number of failed login attempts
        /// for the current user.
        /// </summary>
        [JsonProperty]
        public int AccessFailedCount { get; set; }

        /// <summary>
        /// Authenticator key
        /// </summary>
        [JsonProperty]
        public string AuthenticatorKey { get; set; }
    }
}