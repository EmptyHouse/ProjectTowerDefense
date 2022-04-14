using UnityEngine;

/// <summary>
/// All UI elements should be a child of EHUIElement. This is what our UI HUD will search for when initializing
/// </summary>
public class EHUIElement : MonoBehaviour
{
    public virtual void InitializeUIElement()
    {
        
    }
}
