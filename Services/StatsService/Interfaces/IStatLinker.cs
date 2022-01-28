using System;

namespace Services.StatsService
{
    public interface IStatLinker : IDisposable, IStatValueChanged
    {
        Stat Stat { get; }
        string LinkerId { get; }
        float Value { get; }
    }
}