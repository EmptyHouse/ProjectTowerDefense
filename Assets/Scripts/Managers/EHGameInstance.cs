using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Game Instance is an object that persists throughout the duration of the game's life. You can use this to reference
/// other game managers in the world
/// </summary>
public class EHGameInstance : MonoBehaviour
{
    private static EHGameInstance instance;
    public static EHGameInstance Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<EHGameInstance>();
            }

            return instance;
        }
    }
    
    #region monobehaviour methods
    
    #endregion monobehaviour methods
}
