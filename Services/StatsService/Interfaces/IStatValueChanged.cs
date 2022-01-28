using System;

namespace Services.StatsService
{
    public interface IStatValueChanged
    {
        event EventHandler OnValueChanged;
    }
}