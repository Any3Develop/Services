using System;

namespace Services.StatsService
{
    [Serializable]
    public struct StatModifierData
    {
        public string Id;
        public string TypeName;
        public float Value;
        public bool Stacks;
    }
}