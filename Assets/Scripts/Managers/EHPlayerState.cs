using System;
using System.Collections;
using System.Collections.Generic;
using EmptyHouseGames.Utility;
using UnityEngine;
using UnityEngine.Events;

public class EHPlayerState : MonoBehaviour
{
    #region events
    public UnityAction<int, int> OnCreditsModified; // Returns the previous credit value and the new credit value
    public UnityAction<string> OnTowerSelected; // Returns the id of the currently selected tower
    #endregion events
    
    private const int MAX_CREDITS = 100000000;
    public int TotalCredits { get; private set; }
    public List<string> AvailableTowers;
    public int CurrentlySelectedIndex { get; private set; } = 0;

    public int NextPlaceableUnit(out string NextTowerId)
    {
        NextTowerId = null;
        if (AvailableTowers.Count == 0)
        {
            return -1;
        }
        CurrentlySelectedIndex = EHMath.Mod(++CurrentlySelectedIndex, AvailableTowers.Count);
        NextTowerId = AvailableTowers[CurrentlySelectedIndex];
        return CurrentlySelectedIndex;
    }

    public int PreviousPlaceableUnit(out string PreviousTowerId)
    {
        PreviousTowerId = null;
        if (AvailableTowers.Count == 0)
        {
            return -1;
        }
        CurrentlySelectedIndex = EHMath.Mod(--CurrentlySelectedIndex, AvailableTowers.Count);
        PreviousTowerId = AvailableTowers[CurrentlySelectedIndex];
        return 0;
    }

    public string GetCurrentPlaceableUnitId()
    {
        if (AvailableTowers.Count == 0) return null;
        return AvailableTowers[CurrentlySelectedIndex];
    }

    public void AddCreditsToPlayer(int CreditsToAdd)
    {
        TotalCredits += CreditsToAdd;
        if (TotalCredits > MAX_CREDITS)
        {
            TotalCredits = MAX_CREDITS;
            Debug.LogWarning("CreditsAtMax");
        }
    }

    public bool SubtractCreditsFromPlayer(int CreditsToSubtract)
    {
        if (TotalCredits < CreditsToSubtract)
        {
            Debug.LogWarning("NotEnoughCredits");// Probably want to remove this log in the future
            return false;
        }
        TotalCredits -= CreditsToSubtract;
        return true;
    }
}
