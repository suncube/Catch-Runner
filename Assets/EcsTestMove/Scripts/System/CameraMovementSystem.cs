using Unity.Entities;
using UnityEngine;

namespace Prototype.TimeRunner
{
    public class CameraMovementSystem : ComponentSystem
    { 
        EntityQuery m_Player;
        EntityQuery m_Camera;

        protected override void OnCreate()
        {
            m_Player = GetEntityQuery(typeof(Player));
            m_Camera = GetEntityQuery(typeof(PlayerCamera));
        }

        protected override void OnUpdate()
        {
             var players = m_Player.ToComponentArray<Player>();
             var cameras = m_Camera.ToComponentArray<PlayerCamera>();

             if(cameras.Length == 0 || players.Length == 0) return;

            var desiredPosition = players[0].Position + cameras[0].offset;
		    var smoothedPosition = Vector3.Lerp(cameras[0].transform.position, desiredPosition, cameras[0].smoothSpeed);
		    cameras[0].transform.position = new Vector3 (smoothedPosition.x, cameras[0].transform.position.y,smoothedPosition.z);
        }
    }
}