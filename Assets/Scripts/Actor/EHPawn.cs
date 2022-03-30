using EmptyHouseGames.ProjectTowerDefense.Controller;

namespace EmptyHouseGames.ProjectTowerDefense.Actor
{
    public class EHPawn : EHActor
    {
        public EHBaseController OwningController;

        public void PossessCharacter(EHBaseController OwningController)
        {
            this.OwningController = OwningController;
        }
    }
}
