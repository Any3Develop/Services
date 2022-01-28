﻿using System.Collections.Generic;

namespace Services.StatsService
{
    public interface IStatModifiable
    {
        float StatModifierValue { get; }

        void AddModifier(IStatModifier modifier);
        void RemoveModifier(IStatModifier modifier);
        IEnumerable<IStatModifier> GetModifiers();
        void ClearModifiers();
        void UpdateModifiers();
    }
}