using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EHTime
{
    public const float FixedTimeStep = 1f / 60f;
    public static float TimeScale = 1;
    public static float DeltaTime => FixedTimeStep * TimeScale;
}
