using System.Collections.Generic;
using EmptyHouseGames.ProjectTowerDefense.DataTables;
using UnityEngine;

namespace EmptyHouseGames.ProjectTowerDefense.Actor
{
    /// <summary>
    /// 
    /// </summary>
    public class EHPlayerInventory : EHActorComponent
    {
        //
        private int TotalCurrency;

        public int GetCurrency() => TotalCurrency;
        
        public void AddCurrency(int CurrencyToAdd)
        {
            if (CurrencyToAdd < 0)
            {
                Debug.Log("Adding Negative Currency");
                return;
            }
            TotalCurrency += CurrencyToAdd;
        }

        public bool SubtractCurrency(int CurrencyToSubtract)
        {
            if (CurrencyToSubtract < 0)
            {
                Debug.Log("Subtracting negative currency");
                return false;
            }
            if (TotalCurrency < CurrencyToSubtract) return false;
            TotalCurrency -= CurrencyToSubtract;
            return true;
        }
    }
}

