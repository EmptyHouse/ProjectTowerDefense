using UnityEngine;

namespace EmptyHouseGames.ProjectTowerDefense.Actor
{
    public class EHActor : MonoBehaviour
    {
        public Vector3 Position { get; private set; }
        public Vector3 Rotation { get; private set; }
        public Vector3 Scale { get; private set; }

        public void Awake()
        {
            Position = transform.position;
            Rotation = transform.eulerAngles;
            Scale = transform.localScale;
        }

        public void SetActorPosition(Vector3 Position)
        {
            this.Position = Position;
            transform.position = Position;
        }

        public void SetActorRotation(Vector3 EulerAngles)
        {
            this.Rotation = EulerAngles;
            transform.rotation = Quaternion.Euler(EulerAngles);
        }

        public void SetActorScale(Vector3 Scale)
        {
            this.Scale = Scale;
            transform.localScale = Scale;
        }
    }
}

