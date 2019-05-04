using Unity.Entities;
using UnityEngine;

namespace Prototype.TimeRunner
{
    [RequireComponent(typeof(GameObjectEntity))]
    public class Enemy: EntityObject
    {
        public float speed = 5.0f;
        public float rotationSpeed = 100.0f;
    }

}