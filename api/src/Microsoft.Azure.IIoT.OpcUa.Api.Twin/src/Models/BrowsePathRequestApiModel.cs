// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.OpcUa.Api.Twin.Models {
    using Microsoft.Azure.IIoT.OpcUa.Api.Core.Models;
    using System.Runtime.Serialization;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Browse nodes by path
    /// </summary>
    [DataContract]
    public class BrowsePathRequestApiModel {

        /// <summary>
        /// Node to browse from.
        /// (defaults to root folder).
        /// </summary>
        [DataMember(Name = "nodeId",
            EmitDefaultValue = false)]
        public string NodeId { get; set; }

        /// <summary>
        /// The paths to browse from node.
        /// (mandatory)
        /// </summary>
        [DataMember(Name = "browsePaths")]
        [Required]
        public List<string[]> BrowsePaths { get; set; }

        /// <summary>
        /// Whether to read variable values on target nodes.
        /// (default is false)
        /// </summary>
        [DataMember(Name = "readVariableValues",
            EmitDefaultValue = false)]
        public bool? ReadVariableValues { get; set; }

        /// <summary>
        /// Optional request header
        /// </summary>
        [DataMember(Name = "header",
            EmitDefaultValue = false)]
        public RequestHeaderApiModel Header { get; set; }
    }
}
