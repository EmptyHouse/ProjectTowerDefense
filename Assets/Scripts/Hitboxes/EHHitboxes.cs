using UnityEngine;

namespace EmptyHouseGames.ProjectTowerDefense.Hitboxes
{
    public enum EHitboxType
    {
        Hitbox,
        Hurtbox,
    }
    // Due to our game being primarily ground based, we will start off by using 2d circle hitboxes
    public class EHHitboxes : EHActorComponent
    {
        public float HitboxRadius = 1f;
        public EHitboxType Hitboxtype = EHitboxType.Hitbox;
        public Vector2 HitboxPosition = Vector2.zero;
        private Collider AssociatedCollider;

        protected override void Awake()
        {
            base.Awake();
            AssociatedCollider.GetComponent<Collider>();
            IsTicking = true;
        }

        public override void Tick()
        {
            base.Tick();
            
        }
    }
}
