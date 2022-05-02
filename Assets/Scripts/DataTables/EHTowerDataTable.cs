using EmptyHouseGames.ProjectTowerDefense.DataTables;
using EmptyHouseGames.ProjectTowerDefense.Towers;
using UnityEngine;

namespace EmptyHouseGames.ProjectTowerDefense.DataTables
{
    [System.Serializable]
    public class EHTowerDataTableRow : EHDataTableRow
    {
        public EHPlaceableUnit TowerUnit;
        public Texture2D TowerIcon;
        [Tooltip("The cost to place this tower unit")]
        public int PurchasePrice;
        [Tooltip("The amount of credits that will be returned to the player for selling tower")]
        public int ReturnPrice;
    }
    
    [CreateAssetMenu(fileName = "TowerDataTable", menuName = "ScriptableObjects/TowerTables", order = 1)]
    public class EHTowerDataTable : EHDataTable<EHTowerDataTableRow>
    {
        
    }
}

