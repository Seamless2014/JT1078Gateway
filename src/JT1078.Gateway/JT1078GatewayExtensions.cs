﻿using JT1078.Gateway.Abstractions;
using JT1078.Gateway.Configurations;
using JT1078.Gateway.Impl;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("JT1078.Gateway.Test")]

namespace JT1078.Gateway
{
    public static class JT1078GatewayExtensions
    {

        public static IJT1078Builder AddJT1078Gateway(this IServiceCollection  serviceDescriptors, IConfiguration configuration)
        {
            IJT1078Builder builder = new JT1078BuilderDefault(serviceDescriptors);
            builder.Services.Configure<JT1078Configuration>(configuration.GetSection("JT1078Configuration"));
            return builder;
        }

        public static IJT1078Builder AddJT1078Gateway(this IServiceCollection serviceDescriptors, Action<JT1078Configuration> jt1078Options)
        {
            IJT1078Builder builder = new JT1078BuilderDefault(serviceDescriptors);
            builder.Services.Configure(jt1078Options);
            return builder;
        }
    }
}