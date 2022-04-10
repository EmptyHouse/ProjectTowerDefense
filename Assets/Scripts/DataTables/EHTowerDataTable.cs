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
    }
    
    public class EHTowerDataTable : EHDataTable<EHTowerDataTableRow>
    {
        
    }
}

