using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public static class EHTime
{
    private const float FixedTimeStep = 1f / 60f;
    private static float _TimeScale = 1.0f;

    public static float DeltaTime { get; private set; }
    public static float TimeScale
    {
        get => _TimeScale;
        set
        {
            _TimeScale = value;
            UpdateAdjustedDeltaTime();
        }
    }


    static EHTime()
    {
        UpdateAdjustedDeltaTime();
    }
    

    private static void UpdateAdjustedDeltaTime()
    {
        DeltaTime = _TimeScale * FixedTimeStep;
    }
}
