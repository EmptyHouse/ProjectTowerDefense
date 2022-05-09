using System;
using System.Collections;
using System.Collections.Generic;
using EmptyHouseGames.ProjectTowerDefense.DataTables;
using UnityEngine;

namespace EmptyHouseGames.ProjectTowerDefense.Manager
{
    
    public class EHGameHUD : MonoBehaviour, IWorldManager
    {
        [SerializeField]
        private EHUISceneDataTable SceneTable;
        [SerializeField]
        private string InitialSceneId;

        private List<EHUIScene> SceneStack = new List<EHUIScene>();

        protected virtual void Awake()
        {
            PushScene(InitialSceneId);
        }

        public virtual void InitializeWorldManager(FWorldSettings WorldSettings)
        {
        }

        public void PushScene(string SceneId)
        {
            if (string.IsNullOrEmpty(SceneId))
            {
            }
        }

        public void PopScene()
        {
            
        }

        public void ShowGenericPopup(string Title, string Message)
        {
            
        }
    }
}

