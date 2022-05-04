using EmptyHouseGames.ProjectTowerDefense.Controller;

namespace EmptyHouseGames.ProjectTowerDefense.Actor
{
    public class EHPawn : EHActor
    {
        public EHPlayerState OwningPlayerState { get; private set; }

        public virtual void SetOwningPlayerState(EHPlayerState PlayerState)
        {
            OwningPlayerState = PlayerState;
        }
    }
}
