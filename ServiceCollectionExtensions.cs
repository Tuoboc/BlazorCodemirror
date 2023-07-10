using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCodemirror
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazorCodeMirror(this IServiceCollection services)
        {
            services.TryAddScoped<BlazorCodemirrorJsInterop>();
            return services;
        }
    }
}
