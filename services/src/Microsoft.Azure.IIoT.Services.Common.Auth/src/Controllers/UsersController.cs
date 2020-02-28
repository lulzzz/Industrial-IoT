// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.Services.Common.Identity {
    using Microsoft.Azure.IIoT.Services.Common.Identity.Filters;
    using Microsoft.Azure.IIoT.Services.Common.Identity.Auth;
    using Microsoft.Azure.IIoT.Auth.IdentityServer4.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using Microsoft.Azure.IIoT.Exceptions;
    using System.Runtime.Serialization;

    /// <summary>
    /// User manager controller
    /// </summary>
    [ApiVersion("2")]
    [Route("v{version:apiVersion}/monitor")]
    [ExceptionsFilter]
    [Produces(ContentMimeType.Json)]
    [Authorize(Policy = Policies.CanManage)]
    [ApiController]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    [SecurityHeaders]
    public class UsersController : Controller {

        /// <summary>
        /// User controller
        /// </summary>
        /// <param name="service"></param>
        public UsersController(UserManager<UserModel> service) {
            _manager = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task CreateUserAsync([FromBody] UserModel user) {
            if (user == null) {
                throw new ArgumentNullException(nameof(user));
            }
            var result = await _manager.CreateAsync(user);
            result.Validate();
        }

        /// <summary>
        /// Get user by name
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<UserModel> GetUserByNameAsync([FromQuery] string name) {
            if (string.IsNullOrWhiteSpace(name)) {
                throw new ArgumentNullException(nameof(name));
            }
            var user = await _manager.FindByNameAsync(name);
            return user;
        }

        /// <summary>
        /// Get user by email
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<UserModel> GetUserByEmailAsync([FromQuery] string enail) {
            if (string.IsNullOrWhiteSpace(enail)) {
                throw new ArgumentNullException(nameof(enail));
            }
            var user = await _manager.FindByEmailAsync(enail);
            return user;
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<UserModel> GetUserByIdAsync(string userId) {
            if (string.IsNullOrWhiteSpace(userId)) {
                throw new ArgumentNullException(nameof(userId));
            }
            var user = await _manager.FindByIdAsync(userId);
            return user;
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete, Route("{userId}")]
        public async Task DeleteUserAsync(string userId) {
            if (string.IsNullOrWhiteSpace(userId)) {
                throw new ArgumentNullException(nameof(userId));
            }

            var user = await _manager.FindByIdAsync(userId);
            var result = await _manager.DeleteAsync(user);
            result.Validate();
        }

        /// <summary>
        /// Add new claim
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("{userId}/claims")]
        public async Task AddClaimAsync(string userId, [FromBody] ClaimModel model) {
            if (!_manager.SupportsUserClaim) {
                throw new NotSupportedException("Claim management not supported");
            }
            if (string.IsNullOrWhiteSpace(userId)) {
                throw new ArgumentNullException(nameof(userId));
            }
            if (model == null) {
                throw new ArgumentNullException(nameof(model));
            }
            var user = await _manager.FindByIdAsync(userId);
            var result = await _manager.AddClaimAsync(user, new Claim(model.Type, model.Value));
            result.Validate();
        }


        /// <summary>
        /// Remove claim
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpDelete("{userId}/claims/{type}/{value}")]
        public async Task RemoveClaimAsync(string userId, string type, string value) {
            if (!_manager.SupportsUserClaim) {
                throw new NotSupportedException("Claim management not supported");
            }
            if (string.IsNullOrWhiteSpace(userId)) {
                throw new ArgumentNullException(nameof(userId));
            }
            if (string.IsNullOrWhiteSpace(type)) {
                throw new ArgumentNullException(nameof(type));
            }
            if (string.IsNullOrWhiteSpace(value)) {
                throw new ArgumentNullException(nameof(value));
            }

            var user = await _manager.FindByIdAsync(userId);
            var result = await _manager.RemoveClaimAsync(user, new Claim(type, value));
            result.Validate();
        }

        /// <summary>
        /// Add role to user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost("{userId}/roles/{role}")]
        public async Task AddRoleAsync(string userId, string role) {
            if (!_manager.SupportsUserRole) {
                throw new NotSupportedException("Role management not supported");
            }
            if (string.IsNullOrWhiteSpace(userId)) {
                throw new ArgumentNullException(nameof(userId));
            }

            var user = await _manager.FindByIdAsync(userId);
            var result = await _manager.AddToRoleAsync(user, role);
            result.Validate();
        }

        /// <summary>
        /// Get users in role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpGet("/roles/{role}")]
        public async Task<IList<UserModel>> GetUsersInRoleAsync(string role) {
            var result = await _manager.GetUsersInRoleAsync(role);
            return result;
        }

        /// <summary>
        /// Remove role from user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpDelete("{userId}/roles/{role}")]
        public async Task RemoveRoleAsync(string userId, string role) {
            if (!_manager.SupportsUserRole) {
                throw new NotSupportedException("Role management not supported");
            }
            if (string.IsNullOrWhiteSpace(userId)) {
                throw new ArgumentNullException(nameof(userId));
            }
            var user = await _manager.FindByIdAsync(userId);
            var result = await _manager.RemoveFromRoleAsync(user, role);
            result.Validate();
        }

        private readonly UserManager<UserModel> _manager;
    }
}
