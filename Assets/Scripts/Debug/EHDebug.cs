using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EHDebug
{
    public static void DrawLine(Vector3 OriginPoint, Vector3 Forward, float Distance)
    {
        
    }
    
    public static void LogToScreenFrames(string Message, int Frames = 1)
    {
        #if UNITY_EDITOR
        #endif
    }

    public static void LogToScreenTime(string Message, float TimeMessageActive)
    {
        #if UNITY_EDITOR
        #endif 
    }

    private static string LogTypeToString()
    {
        
        return "None";
    }
}
