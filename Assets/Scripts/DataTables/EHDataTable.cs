using System.Collections.Generic;
using EmptyHouseGames.ProjectTowerDefense.Manager;
using UnityEngine;

namespace EmptyHouseGames.ProjectTowerDefense.DataTables
{
    [System.Serializable]
    public class EHDataTableRow
    {
        public string RowId;
    }
    
    public class EHDataTable<T> : ScriptableObject, IGameManager where T : EHDataTableRow
    {
        [SerializeField]
        private List<T> Rows = new List<T>();
        private readonly Dictionary<string, T> RowDictionary = new Dictionary<string, T>();

        public virtual void InitializeManager()
        {
            foreach (T Row in Rows)
            {
                RowDictionary.Add(Row.RowId, Row);
            }
        }

        public EHDataTableRow FindRowById(string RowId)
        {
            return RowDictionary.ContainsKey(RowId) ? RowDictionary[RowId] : null;
        }

        public List<T> GetAllRows()
        {
            return Rows;
        }
    }
}

