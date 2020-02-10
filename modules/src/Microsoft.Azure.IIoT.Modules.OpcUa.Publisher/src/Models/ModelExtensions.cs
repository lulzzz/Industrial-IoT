﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.Azure.IIoT.Modules.OpcUa.Publisher.Models {
    using Microsoft.Azure.IIoT.OpcUa.Api.Core.Models;
    using Microsoft.Azure.IIoT.OpcUa.Api.Publisher.Models;
    using Microsoft.Azure.IIoT.OpcUa.Api.Registry.Models;
    using Microsoft.Azure.IIoT.OpcUa.Core.Models;
    using Microsoft.Azure.IIoT.OpcUa.Publisher.Models;
    using Microsoft.Azure.IIoT.Agent.Framework.Models;
    using Microsoft.Azure.IIoT.Auth.Models;
    using System.Linq;

    /// <summary>
    /// Api model extensions
    /// </summary>
    public static class ModelExtensions {

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static ConfigurationVersionApiModel ToApiModel(this ConfigurationVersionModel model) {
            if (model is null) {
                return null;
            }
            return new ConfigurationVersionApiModel {
                MajorVersion = model.MajorVersion,
                MinorVersion = model.MinorVersion
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static ConfigurationVersionModel ToServiceModel(this ConfigurationVersionApiModel model) {
            if (model is null) {
                return null;
            }
            return new ConfigurationVersionModel {
                MajorVersion = model.MajorVersion,
                MinorVersion = model.MinorVersion
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static ConnectionApiModel ToApiModel(this ConnectionModel model) {
            if (model is null) {
                return null;
            }
            return new ConnectionApiModel {
                Endpoint = model.Endpoint.ToApiModel(),
                User = model.User.ToApiModel(),
                Diagnostics = model.Diagnostics.ToApiModel()
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static ConnectionModel ToServiceModel(this ConnectionApiModel model) {
            if (model is null) {
                return null;
            }
            return new ConnectionModel {
                Endpoint = model.Endpoint.ToServiceModel(),
                User = model.User.ToServiceModel(),
                Diagnostics = model.Diagnostics.ToServiceModel()
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static ContentFilterApiModel ToApiModel(this ContentFilterModel model) {
            if (model is null) {
                return null;
            }
            return new ContentFilterApiModel {
                Elements = model.Elements?
                    .Select(e => e.ToApiModel())
                    .ToList()
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static ContentFilterModel ToServiceModel(this ContentFilterApiModel model) {
            if (model is null) {
                return null;
            }
            return new ContentFilterModel {
                Elements = model.Elements?
                    .Select(e => e.ToServiceModel())
                    .ToList()
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static ContentFilterElementApiModel ToApiModel(this ContentFilterElementModel model) {
            if (model is null) {
                return null;
            }
            return new ContentFilterElementApiModel {
                FilterOperands = model.FilterOperands?
                    .Select(f => f.ToApiModel())
                    .ToList(),
                FilterOperator = (IIoT.OpcUa.Api.Core.Models.FilterOperatorType)model.FilterOperator
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static ContentFilterElementModel ToServiceModel(this ContentFilterElementApiModel model) {
            if (model is null) {
                return null;
            }
            return new ContentFilterElementModel {
                FilterOperands = model.FilterOperands?
                    .Select(f => f.ToServiceModel())
                    .ToList(),
                FilterOperator = (IIoT.OpcUa.Core.Models.FilterOperatorType)model.FilterOperator
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static CredentialApiModel ToApiModel(this CredentialModel model) {
            if (model is null) {
                return null;
            }
            return new CredentialApiModel {
                Value = model.Value,
                Type = (IIoT.OpcUa.Api.Core.Models.CredentialType?)model.Type
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static CredentialModel ToServiceModel(this CredentialApiModel model) {
            if (model is null) {
                return null;
            }
            return new CredentialModel {
                Value = model.Value,
                Type = (IIoT.OpcUa.Core.Models.CredentialType?)model.Type
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static DataSetMetaDataApiModel ToApiModel(this DataSetMetaDataModel model) {
            if (model is null) {
                return null;
            }
            return new DataSetMetaDataApiModel {
                Name = model.Name,
                ConfigurationVersion = model.ConfigurationVersion.ToApiModel(),
                DataSetClassId = model.DataSetClassId,
                Description = model.Description.ToApiModel(),
                Fields = model.Fields?
                    .Select(f => f.ToApiModel())
                    .ToList(),
                EnumDataTypes = model.EnumDataTypes?
                    .Select(f => f.ToApiModel())
                    .ToList(),
                StructureDataTypes = model.StructureDataTypes?
                    .Select(f => f.ToApiModel())
                    .ToList(),
                SimpleDataTypes = model.SimpleDataTypes?
                    .Select(f => f.ToApiModel())
                    .ToList(),
                Namespaces = model.Namespaces?.ToList()
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static DataSetMetaDataModel ToServiceModel(this DataSetMetaDataApiModel model) {
            if (model is null) {
                return null;
            }
            return new DataSetMetaDataModel {
                Name = model.Name,
                ConfigurationVersion = model.ConfigurationVersion.ToServiceModel(),
                DataSetClassId = model.DataSetClassId,
                Description = model.Description.ToServiceModel(),
                Fields = model.Fields?
                    .Select(f => f.ToServiceModel())
                    .ToList(),
                EnumDataTypes = model.EnumDataTypes?
                    .Select(f => f.ToServiceModel())
                    .ToList(),
                StructureDataTypes = model.StructureDataTypes?
                    .Select(f => f.ToServiceModel())
                    .ToList(),
                SimpleDataTypes = model.SimpleDataTypes?
                    .Select(f => f.ToServiceModel())
                    .ToList(),
                Namespaces = model.Namespaces?.ToList()
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static DataSetWriterApiModel ToApiModel(this DataSetWriterModel model) {
            if (model is null) {
                return null;
            }
            return new DataSetWriterApiModel {
                DataSetWriterId = model.DataSetWriterId,
                DataSet = model.DataSet.ToApiModel(),
                DataSetFieldContentMask = (IIoT.OpcUa.Api.Publisher.Models.DataSetFieldContentMask?)model.DataSetFieldContentMask,
                DataSetMetaDataSendInterval = model.DataSetMetaDataSendInterval,
                KeyFrameCount = model.KeyFrameCount,
                KeyFrameInterval = model.KeyFrameInterval,
                MessageSettings = model.MessageSettings.ToApiModel()
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static DataSetWriterModel ToServiceModel(this DataSetWriterApiModel model) {
            if (model is null) {
                return null;
            }
            return new DataSetWriterModel {
                DataSetWriterId = model.DataSetWriterId,
                DataSet = model.DataSet.ToServiceModel(),
                DataSetFieldContentMask = (IIoT.OpcUa.Publisher.Models.DataSetFieldContentMask?)model.DataSetFieldContentMask,
                DataSetMetaDataSendInterval = model.DataSetMetaDataSendInterval,
                KeyFrameCount = model.KeyFrameCount,
                KeyFrameInterval = model.KeyFrameInterval,
                MessageSettings = model.MessageSettings.ToServiceModel()
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static DataSetWriterMessageSettingsApiModel ToApiModel(this DataSetWriterMessageSettingsModel model) {
            if (model is null) {
                return null;
            }
            return new DataSetWriterMessageSettingsApiModel {
                ConfiguredSize = model.ConfiguredSize,
                DataSetMessageContentMask = (IIoT.OpcUa.Api.Publisher.Models.DataSetContentMask?)model.DataSetMessageContentMask,
                DataSetOffset = model.DataSetOffset,
                NetworkMessageNumber = model.NetworkMessageNumber
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static DataSetWriterMessageSettingsModel ToServiceModel(this DataSetWriterMessageSettingsApiModel model) {
            if (model is null) {
                return null;
            }
            return new DataSetWriterMessageSettingsModel {
                ConfiguredSize = model.ConfiguredSize,
                DataSetMessageContentMask = (IIoT.OpcUa.Publisher.Models.DataSetContentMask?)model.DataSetMessageContentMask,
                DataSetOffset = model.DataSetOffset,
                NetworkMessageNumber = model.NetworkMessageNumber
            };
        }

        /// <summary>
        /// Create from service model
        /// </summary>
        /// <param name="model"></param>
        public static DiagnosticsApiModel ToApiModel(this DiagnosticsModel model) {
            if (model is null) {
                return null;
            }
            return new DiagnosticsApiModel {
                AuditId = model.AuditId,
                Level = (IIoT.OpcUa.Api.Core.Models.DiagnosticsLevel?)model.Level,
                TimeStamp = model.TimeStamp
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static DiagnosticsModel ToServiceModel(this DiagnosticsApiModel model) {
            if (model is null) {
                return null;
            }
            return new DiagnosticsModel {
                AuditId = model.AuditId,
                Level = (IIoT.OpcUa.Core.Models.DiagnosticsLevel?)model.Level,
                TimeStamp = model.TimeStamp
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static EndpointApiModel ToApiModel(this EndpointModel model) {
            if (model is null) {
                return null;
            }
            return new EndpointApiModel {
                Url = model.Url,
                AlternativeUrls = model.AlternativeUrls,
                Certificate = model.Certificate,
                SecurityMode = (IIoT.OpcUa.Api.Core.Models.SecurityMode?)model.SecurityMode,
                SecurityPolicy = model.SecurityPolicy
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static EndpointModel ToServiceModel(this EndpointApiModel model) {
            if (model is null) {
                return null;
            }
            return new EndpointModel {
                Url = model.Url,
                AlternativeUrls = model.AlternativeUrls,
                Certificate = model.Certificate,
                SecurityMode = (IIoT.OpcUa.Core.Models.SecurityMode?)model.SecurityMode,
                SecurityPolicy = model.SecurityPolicy
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static EngineConfigurationApiModel ToApiModel(this EngineConfigurationModel model) {
            if (model is null) {
                return null;
            }
            return new EngineConfigurationApiModel {
                BatchSize = model.BatchSize,
                DiagnosticsInterval = model.DiagnosticsInterval
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static EngineConfigurationModel ToServiceModel(this EngineConfigurationApiModel model) {
            if (model is null) {
                return null;
            }
            return new EngineConfigurationModel {
                BatchSize = model.BatchSize,
                DiagnosticsInterval = model.DiagnosticsInterval
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static EnumDefinitionApiModel ToApiModel(this EnumDefinitionModel model) {
            if (model is null) {
                return null;
            }
            return new EnumDefinitionApiModel {
                Fields = model.Fields?
                    .Select(f => f.ToApiModel())
                    .ToList()
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static EnumDefinitionModel ToServiceModel(this EnumDefinitionApiModel model) {
            if (model is null) {
                return null;
            }
            return new EnumDefinitionModel {
                Fields = model.Fields?
                    .Select(f => f.ToServiceModel())
                    .ToList()
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static EnumDescriptionApiModel ToApiModel(this EnumDescriptionModel model) {
            if (model is null) {
                return null;
            }
            return new EnumDescriptionApiModel {
                Name = model.Name,
                BuiltInType = model.BuiltInType,
                DataTypeId = model.DataTypeId,
                EnumDefinition = model.EnumDefinition.ToApiModel()
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static EnumDescriptionModel ToServiceModel(this EnumDescriptionApiModel model) {
            if (model is null) {
                return null;
            }
            return new EnumDescriptionModel {
                Name = model.Name,
                BuiltInType = model.BuiltInType,
                DataTypeId = model.DataTypeId,
                EnumDefinition = model.EnumDefinition.ToServiceModel()
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static EnumFieldApiModel ToApiModel(this EnumFieldModel model) {
            if (model is null) {
                return null;
            }
            return new EnumFieldApiModel {
                Name = model.Name,
                Description = model.Description.ToApiModel(),
                DisplayName = model.DisplayName.ToApiModel(),
                Value = model.Value
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static EnumFieldModel ToServiceModel(this EnumFieldApiModel model) {
            if (model is null) {
                return null;
            }
            return new EnumFieldModel {
                Name = model.Name,
                Description = model.Description.ToServiceModel(),
                DisplayName = model.DisplayName.ToServiceModel(),
                Value = model.Value
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static FieldMetaDataApiModel ToApiModel(this FieldMetaDataModel model) {
            if (model is null) {
                return null;
            }
            return new FieldMetaDataApiModel {
                Description = model.Description.ToApiModel(),
                ArrayDimensions = model.ArrayDimensions?.ToList(),
                BuiltInType = model.BuiltInType,
                DataSetFieldId = model.DataSetFieldId,
                DataTypeId = model.DataTypeId,
                FieldFlags = model.FieldFlags,
                MaxStringLength = model.MaxStringLength,
                Name = model.Name,
                Properties = model.Properties?
                    .ToDictionary(k => k.Key, v => v.Value),
                ValueRank = model.ValueRank
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static FieldMetaDataModel ToServiceModel(this FieldMetaDataApiModel model) {
            if (model is null) {
                return null;
            }
            return new FieldMetaDataModel {
                Description = model.Description.ToServiceModel(),
                ArrayDimensions = model.ArrayDimensions?.ToList(),
                BuiltInType = model.BuiltInType,
                DataSetFieldId = model.DataSetFieldId,
                DataTypeId = model.DataTypeId,
                FieldFlags = model.FieldFlags,
                MaxStringLength = model.MaxStringLength,
                Name = model.Name,
                Properties = model.Properties?
                    .ToDictionary(k => k.Key, v => v.Value),
                ValueRank = model.ValueRank
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static FilterOperandApiModel ToApiModel(this FilterOperandModel model) {
            if (model is null) {
                return null;
            }
            return new FilterOperandApiModel {
                Index = model.Index,
                Alias = model.Alias,
                Value = model.Value,
                NodeId = model.NodeId,
                AttributeId = (IIoT.OpcUa.Api.Core.Models.NodeAttribute?)model.AttributeId,
                BrowsePath = model.BrowsePath,
                IndexRange = model.IndexRange
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static FilterOperandModel ToServiceModel(this FilterOperandApiModel model) {
            if (model is null) {
                return null;
            }
            return new FilterOperandModel {
                Index = model.Index,
                Alias = model.Alias,
                Value = model.Value,
                NodeId = model.NodeId,
                AttributeId = (IIoT.OpcUa.Core.Models.NodeAttribute?)model.AttributeId,
                BrowsePath = model.BrowsePath,
                IndexRange = model.IndexRange
            };
        }

        /// <summary>
        /// Create twin model
        /// </summary>
        /// <param name="model"></param>
        public static IdentityTokenApiModel ToApiModel(this IdentityTokenModel model) {
            if (model is null) {
                return null;
            }
            return new IdentityTokenApiModel {
                Identity = model.Identity,
                Key = model.Key,
                Expires = model.Expires
            };
        }

        /// <summary>
        /// Convert to service model
        /// </summary>
        /// <returns></returns>
        public static IdentityTokenModel ToServiceModel(this IdentityTokenApiModel model) {
            if (model is null) {
                return null;
            }
            return new IdentityTokenModel {
                Identity = model.Identity,
                Key = model.Key,
                Expires = model.Expires
            };
        }


        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static LocalizedTextApiModel ToApiModel(this LocalizedTextModel model) {
            if (model is null) {
                return null;
            }
            return new LocalizedTextApiModel {
                Locale = model.Locale,
                Text = model.Text
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static LocalizedTextModel ToServiceModel(this LocalizedTextApiModel model) {
            if (model is null) {
                return null;
            }
            return new LocalizedTextModel {
                Locale = model.Locale,
                Text = model.Text
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static PublishedDataItemsApiModel ToApiModel(this PublishedDataItemsModel model) {
            if (model is null) {
                return null;
            }
            return new PublishedDataItemsApiModel {
                PublishedData = model.PublishedData?
                    .Select(d => d.ToApiModel())
                    .ToList()
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static PublishedDataItemsModel ToServiceModel(this PublishedDataItemsApiModel model) {
            if (model is null) {
                return null;
            }
            return new PublishedDataItemsModel {
                PublishedData = model.PublishedData?
                    .Select(d => d.ToServiceModel())
                    .ToList()
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static PublishedDataSetApiModel ToApiModel(this PublishedDataSetModel model) {
            if (model is null) {
                return null;
            }
            return new PublishedDataSetApiModel {
                Name = model.Name,
                DataSetSource = model.DataSetSource.ToApiModel(),
                DataSetMetaData = model.DataSetMetaData.ToApiModel(),
                ExtensionFields = model.ExtensionFields?
                    .ToDictionary(k => k.Key, v => v.Value)
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static PublishedDataSetModel ToServiceModel(this PublishedDataSetApiModel model) {
            if (model is null) {
                return null;
            }
            return new PublishedDataSetModel {
                Name = model.Name,
                DataSetSource = model.DataSetSource.ToServiceModel(),
                DataSetMetaData = model.DataSetMetaData.ToServiceModel(),
                ExtensionFields = model.ExtensionFields?
                    .ToDictionary(k => k.Key, v => v.Value)
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static PublishedDataSetEventsApiModel ToApiModel(this PublishedDataSetEventsModel model) {
            if (model is null) {
                return null;
            }
            return new PublishedDataSetEventsApiModel {
                Id = model.Id,
                DiscardNew = model.DiscardNew,
                EventNotifier = model.EventNotifier,
                BrowsePath = model.BrowsePath,
                Filter = model.Filter.ToApiModel(),
                QueueSize = model.QueueSize,
                MonitoringMode = (IIoT.OpcUa.Api.Publisher.Models.MonitoringMode?)model.MonitoringMode,
                TriggerId = model.TriggerId,
                SelectedFields = model.SelectedFields?
                    .Select(f => f.ToApiModel())
                    .ToList()
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static PublishedDataSetEventsModel ToServiceModel(this PublishedDataSetEventsApiModel model) {
            if (model is null) {
                return null;
            }
            return new PublishedDataSetEventsModel {
                Id = model.Id,
                DiscardNew = model.DiscardNew,
                EventNotifier = model.EventNotifier,
                BrowsePath = model.BrowsePath,
                Filter = model.Filter.ToServiceModel(),
                QueueSize = model.QueueSize,
                MonitoringMode = (IIoT.OpcUa.Publisher.Models.MonitoringMode?)model.MonitoringMode,
                TriggerId = model.TriggerId,
                SelectedFields = model.SelectedFields?
                    .Select(f => f.ToServiceModel())
                    .ToList()
            };
        }


        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static PublishedDataSetSettingsApiModel ToApiModel(this PublishedDataSetSettingsModel model) {
            if (model is null) {
                return null;
            }
            return new PublishedDataSetSettingsApiModel {
                LifeTimeCount = model.LifeTimeCount,
                MaxKeepAliveCount = model.MaxKeepAliveCount,
                MaxNotificationsPerPublish = model.MaxNotificationsPerPublish,
                Priority = model.Priority,
                PublishingInterval = model.PublishingInterval
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static PublishedDataSetSettingsModel ToServiceModel(this PublishedDataSetSettingsApiModel model) {
            if (model is null) {
                return null;
            }
            return new PublishedDataSetSettingsModel {
                LifeTimeCount = model.LifeTimeCount,
                MaxKeepAliveCount = model.MaxKeepAliveCount,
                MaxNotificationsPerPublish = model.MaxNotificationsPerPublish,
                Priority = model.Priority,
                PublishingInterval = model.PublishingInterval
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static PublishedDataSetSourceApiModel ToApiModel(this PublishedDataSetSourceModel model) {
            if (model is null) {
                return null;
            }
            return new PublishedDataSetSourceApiModel {
                Connection = model.Connection.ToApiModel(),
                PublishedEvents = model.PublishedEvents.ToApiModel(),
                PublishedVariables = model.PublishedVariables.ToApiModel(),
                SubscriptionSettings = model.SubscriptionSettings.ToApiModel()
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static PublishedDataSetSourceModel ToServiceModel(this PublishedDataSetSourceApiModel model) {
            if (model is null) {
                return null;
            }
            return new PublishedDataSetSourceModel {
                Connection = model.Connection.ToServiceModel(),
                PublishedEvents = model.PublishedEvents.ToServiceModel(),
                PublishedVariables = model.PublishedVariables.ToServiceModel(),
                SubscriptionSettings = model.SubscriptionSettings.ToServiceModel()
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static PublishedDataSetVariableApiModel ToApiModel(this PublishedDataSetVariableModel model) {
            if (model is null) {
                return null;
            }
            return new PublishedDataSetVariableApiModel {
                Id = model.Id,
                PublishedVariableNodeId = model.PublishedVariableNodeId,
                BrowsePath = model.BrowsePath,
                Attribute = model.Attribute,
                DataChangeFilter = (IIoT.OpcUa.Api.Publisher.Models.DataChangeTriggerType?)model.DataChangeFilter,
                DeadbandType = (IIoT.OpcUa.Api.Publisher.Models.DeadbandType?)model.DeadbandType,
                DeadbandValue = model.DeadbandValue,
                DiscardNew = model.DiscardNew,
                IndexRange = model.IndexRange,
                MonitoringMode = (IIoT.OpcUa.Api.Publisher.Models.MonitoringMode?)model.MonitoringMode,
                MetaDataProperties = model.MetaDataProperties?.ToList(),
                QueueSize = model.QueueSize,
                SamplingInterval = model.SamplingInterval,
                TriggerId = model.TriggerId,
                SubstituteValue = model.SubstituteValue?.DeepClone()
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static PublishedDataSetVariableModel ToServiceModel(this PublishedDataSetVariableApiModel model) {
            if (model is null) {
                return null;
            }
            return new PublishedDataSetVariableModel {
                Id = model.Id,
                PublishedVariableNodeId = model.PublishedVariableNodeId,
                BrowsePath = model.BrowsePath,
                Attribute = model.Attribute,
                DataChangeFilter = (IIoT.OpcUa.Publisher.Models.DataChangeTriggerType?)model.DataChangeFilter,
                DeadbandType = (IIoT.OpcUa.Publisher.Models.DeadbandType?)model.DeadbandType,
                DeadbandValue = model.DeadbandValue,
                DiscardNew = model.DiscardNew,
                IndexRange = model.IndexRange,
                MonitoringMode = (IIoT.OpcUa.Publisher.Models.MonitoringMode?)model.MonitoringMode,
                MetaDataProperties = model.MetaDataProperties?
                    .ToList(),
                QueueSize = model.QueueSize,
                SamplingInterval = model.SamplingInterval,
                TriggerId = model.TriggerId,
                SubstituteValue = model.SubstituteValue?.DeepClone()
            };
        }

        /// <summary>
        /// Create config
        /// </summary>
        /// <param name="model"></param>
        public static PublisherConfigApiModel ToApiModel(this AgentConfigModel model) {
            if (model is null) {
                return null;
            }
            return new PublisherConfigApiModel {
                Capabilities = model.Capabilities?
                    .ToDictionary(k => k.Key, v => v.Value),
                HeartbeatInterval = model.HeartbeatInterval,
                JobCheckInterval = model.JobCheckInterval,
                JobOrchestratorUrl = model.JobOrchestratorUrl,
                MaxWorkers = model.MaxWorkers
            };
        }

        /// <summary>
        /// Convert to service model
        /// </summary>
        /// <returns></returns>
        public static AgentConfigModel ToServiceModel(this PublisherConfigApiModel model) {
            if (model is null) {
                return null;
            }
            return new AgentConfigModel {
                Capabilities = model.Capabilities?
                    .ToDictionary(k => k.Key, v => v.Value),
                HeartbeatInterval = model.HeartbeatInterval,
                JobCheckInterval = model.JobCheckInterval,
                JobOrchestratorUrl = model.JobOrchestratorUrl,
                MaxWorkers = model.MaxWorkers
            };
        }


        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static SimpleAttributeOperandApiModel ToApiModel(this SimpleAttributeOperandModel model) {
            if (model is null) {
                return null;
            }
            return new SimpleAttributeOperandApiModel {
                NodeId = model.NodeId,
                AttributeId = (IIoT.OpcUa.Api.Core.Models.NodeAttribute?)model.AttributeId,
                BrowsePath = model.BrowsePath,
                IndexRange = model.IndexRange
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static SimpleAttributeOperandModel ToServiceModel(this SimpleAttributeOperandApiModel model) {
            if (model is null) {
                return null;
            }
            return new SimpleAttributeOperandModel {
                NodeId = model.NodeId,
                AttributeId = (IIoT.OpcUa.Core.Models.NodeAttribute?)model.AttributeId,
                BrowsePath = model.BrowsePath,
                IndexRange = model.IndexRange
            };
        }


        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static SimpleTypeDescriptionApiModel ToApiModel(this SimpleTypeDescriptionModel model) {
            if (model is null) {
                return null;
            }
            return new SimpleTypeDescriptionApiModel {
                BaseDataTypeId = model.BaseDataTypeId,
                Name = model.Name,
                DataTypeId = model.DataTypeId,
                BuiltInType = model.BuiltInType
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static SimpleTypeDescriptionModel ToServiceModel(this SimpleTypeDescriptionApiModel model) {
            if (model is null) {
                return null;
            }
            return new SimpleTypeDescriptionModel {
                BaseDataTypeId = model.BaseDataTypeId,
                Name = model.Name,
                DataTypeId = model.DataTypeId,
                BuiltInType = model.BuiltInType
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static StructureDefinitionApiModel ToApiModel(this StructureDefinitionModel model) {
            if (model is null) {
                return null;
            }
            return new StructureDefinitionApiModel {
                BaseDataTypeId = model.BaseDataTypeId,
                Fields = model.Fields?
                    .Select(f => f.ToApiModel())
                    .ToList(),
                StructureType = (IIoT.OpcUa.Api.Core.Models.StructureType)model.StructureType
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static StructureDefinitionModel ToServiceModel(this StructureDefinitionApiModel model) {
            if (model is null) {
                return null;
            }
            return new StructureDefinitionModel {
                BaseDataTypeId = model.BaseDataTypeId,
                Fields = model.Fields?
                    .Select(f => f.ToServiceModel())
                    .ToList(),
                StructureType = (IIoT.OpcUa.Core.Models.StructureType)model.StructureType
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static StructureDescriptionApiModel ToApiModel(this StructureDescriptionModel model) {
            if (model is null) {
                return null;
            }
            return new StructureDescriptionApiModel {
                DataTypeId = model.DataTypeId,
                Name = model.Name,
                StructureDefinition = model.StructureDefinition.ToApiModel()
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static StructureDescriptionModel ToServiceModel(this StructureDescriptionApiModel model) {
            if (model is null) {
                return null;
            }
            return new StructureDescriptionModel {
                DataTypeId = model.DataTypeId,
                Name = model.Name,
                StructureDefinition = model.StructureDefinition.ToServiceModel()
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static StructureFieldApiModel ToApiModel(this StructureFieldModel model) {
            if (model is null) {
                return null;
            }
            return new StructureFieldApiModel {
                ArrayDimensions = model.ArrayDimensions?.ToList(),
                DataTypeId = model.DataTypeId,
                Description = model.Description.ToApiModel(),
                IsOptional = model.IsOptional,
                MaxStringLength = model.MaxStringLength,
                Name = model.Name,
                ValueRank = (IIoT.OpcUa.Api.Core.Models.NodeValueRank?)model.ValueRank
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static StructureFieldModel ToServiceModel(this StructureFieldApiModel model) {
            if (model is null) {
                return null;
            }
            return new StructureFieldModel {
                ArrayDimensions = model.ArrayDimensions?.ToList(),
                DataTypeId = model.DataTypeId,
                Description = model.Description.ToServiceModel(),
                IsOptional = model.IsOptional,
                MaxStringLength = model.MaxStringLength,
                Name = model.Name,
                ValueRank = (IIoT.OpcUa.Core.Models.NodeValueRank?)model.ValueRank
            };
        }
        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static WriterGroupApiModel ToApiModel(this WriterGroupModel model) {
            if (model is null) {
                return null;
            }
            return new WriterGroupApiModel {
                WriterGroupId = model.WriterGroupId,
                HeaderLayoutUri = model.HeaderLayoutUri,
                KeepAliveTime = model.KeepAliveTime,
                LocaleIds = model.LocaleIds?.ToList(),
                MaxNetworkMessageSize = model.MaxNetworkMessageSize,
                MessageSettings = model.MessageSettings.ToApiModel(),
                MessageType = (IIoT.OpcUa.Api.Publisher.Models.MessageEncoding?)model.MessageType,
                Name = model.Name,
                Priority = model.Priority,
                SecurityGroupId = model.SecurityGroupId,
                SecurityKeyServices = model.SecurityKeyServices?
                    .Select(s => s.ToApiModel())
                    .ToList(),
                DataSetWriters = model.DataSetWriters?
                    .Select(s => s.ToApiModel())
                    .ToList(),
                PublishingInterval = model.PublishingInterval,
                SecurityMode = (IIoT.OpcUa.Api.Core.Models.SecurityMode?)model.SecurityMode
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static WriterGroupModel ToServiceModel(this WriterGroupApiModel model) {
            if (model is null) {
                return null;
            }
            return new WriterGroupModel {
                WriterGroupId = model.WriterGroupId,
                HeaderLayoutUri = model.HeaderLayoutUri,
                KeepAliveTime = model.KeepAliveTime,
                LocaleIds = model.LocaleIds?.ToList(),
                MaxNetworkMessageSize = model.MaxNetworkMessageSize,
                MessageSettings = model.MessageSettings.ToServiceModel(),
                MessageType = (IIoT.OpcUa.Publisher.Models.MessageEncoding?)model.MessageType,
                Name = model.Name,
                Priority = model.Priority,
                SecurityGroupId = model.SecurityGroupId,
                SecurityKeyServices = model.SecurityKeyServices?
                    .Select(s => s.ToServiceModel())
                    .ToList(),
                DataSetWriters = model.DataSetWriters?
                    .Select(s => s.ToServiceModel())
                    .ToList(),
                PublishingInterval = model.PublishingInterval,
                SecurityMode = (IIoT.OpcUa.Core.Models.SecurityMode?)model.SecurityMode
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static WriterGroupJobApiModel ToApiModel(this WriterGroupJobModel model) {
            if (model?.WriterGroup is null) {
                return null;
            }
            return new WriterGroupJobApiModel {
                WriterGroup = model.WriterGroup.ToApiModel(),
                ConnectionString = model.ConnectionString,
                Engine = model.Engine.ToApiModel(),
                MessagingMode = (IIoT.OpcUa.Api.Publisher.Models.MessagingMode?)model.MessagingMode
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static WriterGroupJobModel ToServiceModel(this WriterGroupJobApiModel model) {
            if (model is null) {
                return null;
            }
            return new WriterGroupJobModel {
                WriterGroup = model.WriterGroup.ToServiceModel(),
                ConnectionString = model.ConnectionString,
                Engine = model.Engine.ToServiceModel(),
                MessagingMode = (IIoT.OpcUa.Publisher.Models.MessagingMode?)model.MessagingMode
            };
        }

        /// <summary>
        /// Create api model from service model
        /// </summary>
        /// <param name="model"></param>
        public static WriterGroupMessageSettingsApiModel ToApiModel(this WriterGroupMessageSettingsModel model) {
            if (model is null) {
                return null;
            }
            return new WriterGroupMessageSettingsApiModel {
                NetworkMessageContentMask = (IIoT.OpcUa.Api.Publisher.Models.NetworkMessageContentMask?)model.NetworkMessageContentMask,
                DataSetOrdering = (IIoT.OpcUa.Api.Publisher.Models.DataSetOrderingType?)model.DataSetOrdering,
                GroupVersion = model.GroupVersion,
                PublishingOffset = model.PublishingOffset,
                SamplingOffset = model.SamplingOffset
            };
        }

        /// <summary>
        /// Create service model from api model
        /// </summary>
        public static WriterGroupMessageSettingsModel ToServiceModel(this WriterGroupMessageSettingsApiModel model) {
            if (model is null) {
                return null;
            }
            return new WriterGroupMessageSettingsModel {
                NetworkMessageContentMask = (IIoT.OpcUa.Publisher.Models.NetworkMessageContentMask?)model.NetworkMessageContentMask,
                DataSetOrdering = (IIoT.OpcUa.Publisher.Models.DataSetOrderingType?)model.DataSetOrdering,
                GroupVersion = model.GroupVersion,
                PublishingOffset = model.PublishingOffset,
                SamplingOffset = model.SamplingOffset
            };
        }
    }
}