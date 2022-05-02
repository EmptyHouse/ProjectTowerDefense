using System.Collections;
using System.Collections.Generic;
using EmptyHouseGames.ProjectTowerDefense.Manager;
using EmptyHouseGames.ProjectTowerDefense.Towers;
using UnityEngine;

namespace EmptyHouseGames.ProjectTowerDefense.DataTables
{
    [CreateAssetMenu(fileName = "DataTableManager", menuName = "ScriptableObjects/DataTableManager", order = 1)]
    public class EHDataTableManager : ScriptableObject, IGameManager
    {
        [SerializeField]
        private EHTowerDataTable TowerTable;

        #region datatable getters
        public EHTowerDataTable GetTowerTable() => TowerTable;

        public EHTowerDataTableRow GetTowerDataRow(string TowerId)
        {
            if (TowerTable == null) return null;
            return (EHTowerDataTableRow)TowerTable.FindRowById(TowerId);
        }
        #endregion datatable getters
        
        #region datatable functions
        
        #endregion datatable functions
        // We will initialize all the data tables in this function
        public void InitializeManager()
        {
            TowerTable.InitializeManager();
        }
    }
}

