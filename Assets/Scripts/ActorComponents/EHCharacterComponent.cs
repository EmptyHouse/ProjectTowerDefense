
using EmptyHouseGames.ProjectTowerDefense.Actor;

namespace EmptyHouseGames.ProjectTowerDefense.ActorComponent
{
    public class EHCharacterComponent : EHActorComponent
    {
        public EHCharacter OwningCharacter { get; private set; }
    
        #region monobehaviour methods

        protected override void Awake()
        {
            base.Awake();
            OwningCharacter = (EHCharacter) OwningActor;
        }

        #endregion monobehaviour methods
    }
}

