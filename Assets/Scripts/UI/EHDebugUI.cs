using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class EHDebugUI : MonoBehaviour
{
    #region fps variables

    private const byte TotalLoopsUntilFPSUpdate = 20;
    [SerializeField]
    private Text UpdateFPSText;
    [SerializeField]
    public Text FixedUpdateFPSText;

    private float LastDeltaTime;
    private byte UpdateLoopsCount;
    private float LastFixedDeltaTime;
    private byte FixedUpdateLoopsCount;
    #endregion fps variables

    private void Start()
    {
        LastDeltaTime = Time.time;
        LastFixedDeltaTime = Time.time;
    }

    private void Update()
    {
        if (++UpdateLoopsCount >= TotalLoopsUntilFPSUpdate)
        {
            UpdateFPSCounterText(UpdateFPSText, Time.time - LastDeltaTime);
            LastDeltaTime = Time.time;
        }
    }

    private void FixedUpdate()
    {
        if (++FixedUpdateLoopsCount >= TotalLoopsUntilFPSUpdate)
        {
            UpdateFPSCounterText(FixedUpdateFPSText, Time.time - LastFixedDeltaTime);
            LastFixedDeltaTime = Time.time;
        }
    }

    private void UpdateFPSCounterText(Text FPSText, float DeltaTime)
    {
        
    }
}
