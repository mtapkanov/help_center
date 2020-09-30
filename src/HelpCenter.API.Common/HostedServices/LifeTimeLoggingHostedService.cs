﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HelpCenter.API.Common.HostedServices
{
    public class LifeTimeLoggingHostedService : IHostedService
    {
        private readonly IHostApplicationLifetime _applicationLifetime;
        private readonly ILogger<LifeTimeLoggingHostedService> _logger;

        public LifeTimeLoggingHostedService(IHostApplicationLifetime applicationLifetime, ILogger<LifeTimeLoggingHostedService> logger)
        {
            _applicationLifetime = applicationLifetime ?? throw new ArgumentNullException(nameof(applicationLifetime));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _applicationLifetime.ApplicationStarted.Register(OnStarted);
            _applicationLifetime.ApplicationStopping.Register(OnStopping);
            _applicationLifetime.ApplicationStopped.Register(OnStopped);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        private void OnStarted() => this._logger.LogInformation("Application started.");

        private void OnStopping() => this._logger.LogInformation("Application stopping.");

        private void OnStopped() => this._logger.LogInformation("Application stopped.");
    }
}
