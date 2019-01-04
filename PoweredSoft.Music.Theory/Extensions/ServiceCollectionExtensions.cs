using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PoweredSoft.Music.Theory.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.Music.Theory.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPoweredSoftMusicTheory(this IServiceCollection services)
        {
            services.TryAddTransient<INoteService, NoteService>();
            services.TryAddTransient<IIntervalService, IntervalService>();
            services.TryAddTransient<INoteIntervalService, NoteIntervalService>();
            services.TryAddTransient<IChordService, ChordService>();
            return services;
        }
    }
}
