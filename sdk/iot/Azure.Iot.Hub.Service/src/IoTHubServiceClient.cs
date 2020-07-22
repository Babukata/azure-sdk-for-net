﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Iot.Hub.Service.Authentication;

namespace Azure.Iot.Hub.Service
{
    /// <summary>
    /// The IoT Hub Service Client.
    /// </summary>
    public class IoTHubServiceClient
    {
        private readonly HttpPipeline _httpPipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly Uri _endpoint;
        private readonly RegistryManagerRestClient _registryManagerRestClient;
        private readonly TwinRestClient _twinRestClient;
        private readonly DeviceMethodRestClient _deviceMethodRestClient;

        /// <summary>
        /// place holder for Devices
        /// </summary>
        public virtual DevicesClient Devices { get; private set; }

        /// <summary>
        /// place holder for Modules
        /// </summary>
        public virtual ModulesClient Modules { get; private set; }

        /// <summary>
        /// place holder for Statistics
        /// </summary>
        public virtual StatisticsClient Statistics { get; private set; }

        /// <summary>
        /// place holder for Messages
        /// </summary>
        public virtual CloudToDeviceMessagesClient Messages { get; private set; }

        /// <summary>
        /// place holder for Files
        /// </summary>
        public virtual FilesClient Files { get; private set; }

        /// <summary>
        /// place holder for Jobs
        /// </summary>
        public virtual JobsClient Jobs { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IoTHubServiceClient"/> class.
        /// </summary>
        protected IoTHubServiceClient()
        {
            // This constructor only exists for mocking purposes in unit tests. It should not be used otherwise.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IoTHubServiceClient"/> class.
        /// </summary>
        /// <param name="connectionString">
        /// The IoT Hub connection string, with either "iothubowner", "service", "registryRead" or "registryReadWrite" policy, as applicable.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-security#access-control-and-permissions"/>.
        /// </param>
        public IoTHubServiceClient(string connectionString)
            : this(connectionString, new IoTHubServiceClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IoTHubServiceClient"/> class.
        /// </summary>
        /// <param name="connectionString">
        /// The IoT Hub connection string, with either "iothubowner", "service", "registryRead" or "registryReadWrite" policy, as applicable.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-security#access-control-and-permissions"/>.
        /// </param>
        /// <param name="options">
        /// Options that allow configuration of requests sent to the IoT Hub service.
        /// </param>
        public IoTHubServiceClient(string connectionString, IoTHubServiceClientOptions options)
        {
            Argument.AssertNotNull(options, nameof(options));

            var iotHubConnectionString = new IotHubConnectionString(connectionString);
            var sasTokenProvider = new SasTokenProviderWithSharedAccessKey(
                iotHubConnectionString.HostName,
                iotHubConnectionString.SharedAccessPolicy,
                iotHubConnectionString.SharedAccessKey,
                options.SasTokenTimeToLive);

            _endpoint = BuildEndpointUriFromHostName(iotHubConnectionString.HostName);

            _clientDiagnostics = new ClientDiagnostics(options);

            options.AddPolicy(new SasTokenAuthenticationPolicy(sasTokenProvider), HttpPipelinePosition.PerCall);
            _httpPipeline = HttpPipelineBuilder.Build(options);

            _registryManagerRestClient = new RegistryManagerRestClient(_clientDiagnostics, _httpPipeline, _endpoint, options.GetVersionString());
            _twinRestClient = new TwinRestClient(_clientDiagnostics, _httpPipeline, null, options.GetVersionString());
            _deviceMethodRestClient = new DeviceMethodRestClient(_clientDiagnostics, _httpPipeline, _endpoint, options.GetVersionString());

            Devices = new DevicesClient(_registryManagerRestClient, _twinRestClient, _deviceMethodRestClient);
            Modules = new ModulesClient(_registryManagerRestClient, _twinRestClient, _deviceMethodRestClient);

            Statistics = new StatisticsClient();
            Messages = new CloudToDeviceMessagesClient();
            Files = new FilesClient();
            Jobs = new JobsClient();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IoTHubServiceClient"/> class.
        /// </summary>
        /// <param name="hostName">
        /// The IoT Hub service instance host to connect to.
        /// </param>
        /// <param name="sharedAccessPolicy">
        /// The IoT Hub access permission, which can be either "iothubowner", "service", "registryRead" or "registryReadWrite" policy, as applicable.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-security#access-control-and-permissions"/>.
        /// </param>
        /// <param name="sharedAccessKey">
        /// The IoT Hub shared access key associated with the shared access policy permissions."/>
        /// </param>
        public IoTHubServiceClient(string hostName, string sharedAccessPolicy, AzureKeyCredential sharedAccessKey)
            : this(hostName, sharedAccessPolicy, sharedAccessKey, new IoTHubServiceClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IoTHubServiceClient"/> class.
        /// </summary>
        /// <param name="hostName">
        /// The IoT Hub service instance host to connect to.
        /// </param>
        /// <param name="sharedAccessPolicy">
        /// The IoT Hub access permission, which can be either "iothubowner", "service", "registryRead" or "registryReadWrite" policy, as applicable.
        /// For more information, see <see href="https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-security#access-control-and-permissions"/>.
        /// </param>
        /// <param name="sharedAccessKey">
        /// The IoT Hub shared access key associated with the shared access policy permissions."/>
        /// </param>
        /// <param name="options">
        /// Options that allow configuration of requests sent to the IoT Hub service.
        /// </param>
        public IoTHubServiceClient(string hostName, string sharedAccessPolicy, AzureKeyCredential sharedAccessKey, IoTHubServiceClientOptions options)
        {
            Argument.AssertNotNull(options, nameof(options));

            var sasTokenProvider = new SasTokenProviderWithSharedAccessKey(
                hostName,
                sharedAccessPolicy,
                sharedAccessKey,
                options.SasTokenTimeToLive);

            _endpoint = BuildEndpointUriFromHostName(hostName);

            _clientDiagnostics = new ClientDiagnostics(options);

            options.AddPolicy(new SasTokenAuthenticationPolicy(sasTokenProvider), HttpPipelinePosition.PerCall);
            _httpPipeline = HttpPipelineBuilder.Build(options);

            _registryManagerRestClient = new RegistryManagerRestClient(_clientDiagnostics, _httpPipeline, _endpoint, options.GetVersionString());
            _twinRestClient = new TwinRestClient(_clientDiagnostics, _httpPipeline, null, options.GetVersionString());
            _deviceMethodRestClient = new DeviceMethodRestClient(_clientDiagnostics, _httpPipeline, _endpoint, options.GetVersionString());

            Devices = new DevicesClient(_registryManagerRestClient, _twinRestClient, _deviceMethodRestClient);
            Modules = new ModulesClient(_registryManagerRestClient, _twinRestClient, _deviceMethodRestClient);

            Statistics = new StatisticsClient();
            Messages = new CloudToDeviceMessagesClient();
            Files = new FilesClient();
            Jobs = new JobsClient();
        }

        private static Uri BuildEndpointUriFromHostName(string hostName)
        {
            return new UriBuilder { Scheme = "https", Host = hostName }.Uri;
        }
    }
}
