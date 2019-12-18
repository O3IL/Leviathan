﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Leviathan.Mvc.Hosting
{
    public static class Extensions
    {
        public static IHostBuilder UseHostedService<T>(this IHostBuilder hostBuilder)
            where T : class, IHostedService, IDisposable
        {
            return hostBuilder.ConfigureServices(services =>
                services.AddHostedService<T>());
        }

        public static ApplicationHost BuildApplicationHost(this IHostBuilder hostBuilder)
        {
            return new ApplicationHost(hostBuilder.Build());
        }
    }
}