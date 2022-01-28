using System;
using DG.Tweening;
using UnityEngine.Serialization;

[Serializable]
public struct DOSettings
{
    public float durationIn;
    public float durationOut;
    public Ease easeIn;
    public Ease easeOut;
    public float delay;
}