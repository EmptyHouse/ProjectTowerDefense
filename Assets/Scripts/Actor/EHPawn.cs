using EmptyHouseGames.ProjectTowerDefense.Controller;

namespace EmptyHouseGames.ProjectTowerDefense.Actor
{
    public class EHPawn : EHActor
    {
        public EHBaseController OwningController { get; private set; }

        public virtual void OnPawnPossessed(EHBaseController Controller)
        {
            OwningController = Controller;
        }
    }
}
