// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.Api.Identity.Clients {
    using Microsoft.Azure.IIoT.Api.Identity.Models;
    using Microsoft.Azure.IIoT.Http;
    using Microsoft.Azure.IIoT.Serializers;
    using System;
    using System.Threading.Tasks;
    using System.Threading;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation of onboarding service api.
    /// </summary>
    public sealed class OnboardingServiceClient : IIdentityServiceApi {

        /// <summary>
        /// Create service client
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="config"></param>
        /// <param name="serializer"></param>
        public OnboardingServiceClient(IHttpClient httpClient, IIdentityConfig config,
            ISerializer serializer) : this(httpClient, config.IdentityServiceUrl,
                config.IdentityServiceResourceId, serializer) {
        }

        /// <summary>
        /// Create service client
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="serviceUri"></param>
        /// <param name="resourceId"></param>
        /// <param name="serializer"></param>
        public OnboardingServiceClient(IHttpClient httpClient, string serviceUri,
            string resourceId, ISerializer serializer) {
            if (string.IsNullOrEmpty(serviceUri)) {
                throw new ArgumentNullException(nameof(serviceUri),
                    "Please configure the Url of the onboarding micro service.");
            }
            _serviceUri = serviceUri;
            _resourceId = resourceId;
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <inheritdoc/>
        public async Task<string> GetServiceStatusAsync(CancellationToken ct) {
            var request = _httpClient.NewRequest($"{_serviceUri}/healthz",
                _resourceId);
            var response = await _httpClient.GetAsync(request, ct).ConfigureAwait(false);
            response.Validate();
            return _serializer.DeserializeResponse<string>(response);
        }

        /// <inheritdoc/>
        public Task CreateUserAsync(UserApiModel user) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<UserApiModel> GetUserByNameAsync(string name) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<UserApiModel> GetUserByEmailAsync(string email) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<UserApiModel> GetUserByIdAsync(string userId) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task DeleteUserAsync(string userId) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task AddClaimAsync(string userId, ClaimApiModel model) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task RemoveClaimAsync(string userId, ClaimApiModel model) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task AddRoleToUserAsync(string userId, string role) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<IEnumerable<UserApiModel>> GetUsersInRoleAsync(string role) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task RemoveRoleFromUserAsync(string userId, string role) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task CreateRoleAsync(RoleApiModel role) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<RoleApiModel> GetRoleAsync(string roleId) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task DeleteRoleAsync(string roleId) {
            throw new NotImplementedException();
        }

        private readonly IHttpClient _httpClient;
        private readonly string _serviceUri;
        private readonly string _resourceId;
        private readonly ISerializer _serializer;
    }
}
