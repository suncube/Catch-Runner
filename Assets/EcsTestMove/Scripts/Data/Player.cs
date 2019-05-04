using Unity.Entities;
using UnityEngine;

namespace Prototype.TimeRunner
{
    [RequireComponent(typeof(GameObjectEntity))]
    public class Player: EntityObject
    {
        public float speed = 10.0f;
        public float rotationSpeed = 100.0f;

    }

}