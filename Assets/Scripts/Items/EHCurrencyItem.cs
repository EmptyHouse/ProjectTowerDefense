
using EmptyHouseGames.ProjectTowerDefense.Actor;

namespace EmptyHouseGames.ProjectTowerDefense.Items
{
    public class EHCurrencyItem : EHCollectableItem
    {
        public int CurrencyAmount;

        public override void OnItemCollected(EHActor ActorCollectingItem)
        {
            EHPlayerInventory PlayerInventory = ActorCollectingItem.GetComponent<EHPlayerInventory>();
            if (PlayerInventory == null)
            {
                return;
            }
            PlayerInventory.AddCurrency(CurrencyAmount);
        }
    }
}
