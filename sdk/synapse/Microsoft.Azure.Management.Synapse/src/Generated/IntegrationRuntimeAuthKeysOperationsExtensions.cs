// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Synapse
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for IntegrationRuntimeAuthKeysOperations.
    /// </summary>
    public static partial class IntegrationRuntimeAuthKeysOperationsExtensions
    {
            /// <summary>
            /// Regenerate integration runtime authentication key
            /// </summary>
            /// <remarks>
            /// Regenerate the authentication key for an integration runtime
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='workspaceName'>
            /// The name of the workspace
            /// </param>
            /// <param name='integrationRuntimeName'>
            /// Integration runtime name
            /// </param>
            /// <param name='regenerateKeyParameters'>
            /// The parameters for regenerating integration runtime authentication key.
            /// </param>
            public static IntegrationRuntimeAuthKeys Regenerate(this IIntegrationRuntimeAuthKeysOperations operations, string resourceGroupName, string workspaceName, string integrationRuntimeName, IntegrationRuntimeRegenerateKeyParameters regenerateKeyParameters)
            {
                return operations.RegenerateAsync(resourceGroupName, workspaceName, integrationRuntimeName, regenerateKeyParameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Regenerate integration runtime authentication key
            /// </summary>
            /// <remarks>
            /// Regenerate the authentication key for an integration runtime
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='workspaceName'>
            /// The name of the workspace
            /// </param>
            /// <param name='integrationRuntimeName'>
            /// Integration runtime name
            /// </param>
            /// <param name='regenerateKeyParameters'>
            /// The parameters for regenerating integration runtime authentication key.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IntegrationRuntimeAuthKeys> RegenerateAsync(this IIntegrationRuntimeAuthKeysOperations operations, string resourceGroupName, string workspaceName, string integrationRuntimeName, IntegrationRuntimeRegenerateKeyParameters regenerateKeyParameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.RegenerateWithHttpMessagesAsync(resourceGroupName, workspaceName, integrationRuntimeName, regenerateKeyParameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// List integration runtime authentication keys
            /// </summary>
            /// <remarks>
            /// List authentication keys in an integration runtime
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='workspaceName'>
            /// The name of the workspace
            /// </param>
            /// <param name='integrationRuntimeName'>
            /// Integration runtime name
            /// </param>
            public static IntegrationRuntimeAuthKeys List(this IIntegrationRuntimeAuthKeysOperations operations, string resourceGroupName, string workspaceName, string integrationRuntimeName)
            {
                return operations.ListAsync(resourceGroupName, workspaceName, integrationRuntimeName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// List integration runtime authentication keys
            /// </summary>
            /// <remarks>
            /// List authentication keys in an integration runtime
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The name of the resource group. The name is case insensitive.
            /// </param>
            /// <param name='workspaceName'>
            /// The name of the workspace
            /// </param>
            /// <param name='integrationRuntimeName'>
            /// Integration runtime name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IntegrationRuntimeAuthKeys> ListAsync(this IIntegrationRuntimeAuthKeysOperations operations, string resourceGroupName, string workspaceName, string integrationRuntimeName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListWithHttpMessagesAsync(resourceGroupName, workspaceName, integrationRuntimeName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}