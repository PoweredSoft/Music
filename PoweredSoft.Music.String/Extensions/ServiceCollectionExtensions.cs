﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PoweredSoft.Music.String.Core;
using PoweredSoft.Music.String.Core.Guitar;
using PoweredSoft.Music.String.Core.Ukulele;

namespace PoweredSoft.Music.String.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPoweredSoftStringMusicTheory(this IServiceCollection services)
        {
            services.TryAddTransient<IFrettedLuteInstrumentService, FrettedLuteInstrumentService>();
            services.TryAddTransient<IGuitarService, GuitarService>();
            services.TryAddTransient<IUkuleleService, UkuleleService>();
            return services;
        }
    }
}
