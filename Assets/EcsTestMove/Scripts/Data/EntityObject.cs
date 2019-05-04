using Unity.Entities;
using UnityEngine;

namespace Prototype.TimeRunner
{
    [RequireComponent(typeof(GameObjectEntity))]
    public class EntityObject: MonoBehaviour
    {
        public Vector4 MoveZone = new Vector4(-25f,25f,-25f,25f);
        public Vector3 Position{ get{return transform.position;}}

        public void CheckPosition()
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x,MoveZone.x,MoveZone.y),
                transform.position.y,
                Mathf.Clamp(transform.position.z,MoveZone.z,MoveZone.w)
            );
        }
         // todo make for different obj
         public float Size{ get{return transform.localScale.x/2;}}

        public void SetRandomPosition()
        {
              var size = Size;
              transform.position = new Vector3(
                Random.Range(MoveZone.x+size,MoveZone.y-size),
                transform.position.y,
                Random.Range(MoveZone.z+size,MoveZone.w-size)
            );
        }
    }

    public static class EntityObjectHelper
    {
        public static bool TracingCollision(this EntityObject ownObject, EntityObject traceObject)
        {
            return Vector3.Distance(ownObject.Position, traceObject.Position) < (ownObject.Size +traceObject.Size);
        }
    }
}