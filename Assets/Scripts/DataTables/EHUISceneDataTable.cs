using System.Collections;
using System.Collections.Generic;
using EmptyHouseGames.ProjectTowerDefense.DataTables;
using UnityEngine;

namespace EmptyHouseGames.ProjectTowerDefense.DataTables
{
    [System.Serializable]
    public class EHSceneTables : EHDataTableRow
    {
        public EHUIScene UIScene;
        public int Priority;
        public bool IsPopup;
    }
    
    [CreateAssetMenu(fileName = "UIDataTable", menuName = "ScriptableObjects/UI/SceneTables")]
    public class EHUISceneDataTable : EHDataTable<EHSceneTables>
    {
    
    }
}

