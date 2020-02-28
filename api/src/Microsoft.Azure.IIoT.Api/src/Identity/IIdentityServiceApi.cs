// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.Api.Identity {
    using Microsoft.Azure.IIoT.Api.Identity.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// User manager api calls
    /// </summary>
    public interface IIdentityServiceApi {

        /// <summary>
        /// Returns status of the service
        /// </summary>
        /// <returns></returns>
        Task<string> GetServiceStatusAsync(CancellationToken ct = default);

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task CreateUserAsync(UserApiModel user);

        /// <summary>
        /// Get user by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<UserApiModel> GetUserByNameAsync(string name);

        /// <summary>
        /// Get user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<UserApiModel> GetUserByEmailAsync(string email);

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UserApiModel> GetUserByIdAsync(string userId);

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task DeleteUserAsync(string userId);

        /// <summary>
        /// Add new claim
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task AddClaimAsync(string userId, ClaimApiModel model);

        /// <summary>
        /// Remove claim
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task RemoveClaimAsync(string userId, ClaimApiModel model);

        /// <summary>
        /// Add role to user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        Task AddRoleToUserAsync(string userId, string role);

        /// <summary>
        /// Get users in role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        Task<IEnumerable<UserApiModel>> GetUsersInRoleAsync(string role);

        /// <summary>
        /// Remove role from user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        Task RemoveRoleFromUserAsync(string userId, string role);

        /// <summary>
        /// Create role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        Task CreateRoleAsync(RoleApiModel role);

        /// <summary>
        /// Get role
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<RoleApiModel> GetRoleAsync(string roleId);

        /// <summary>
        /// Delete role
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task DeleteRoleAsync(string roleId);
    }
}
