using Unity.Entities;
using UnityEngine;
using System.Collections;
using Unity.Collections;

namespace Prototype.TimeRunner
{
    public class PlayerMovementSystem : ComponentSystem
    { 
        EntityQuery m_Player;
        EntityQuery m_Input;
        protected override void OnCreate()
        {
            m_Player = GetEntityQuery(typeof(Player));
            m_Input = GetEntityQuery(typeof(InputData));
        }

        protected override void OnUpdate()
        {
            //
            var input = m_Input.ToComponentArray<InputData>();
            if(input.Length == 0 || !input[0].isActive) return;

//
            if(input[0].X!=0)
                input[0].X = input[0].X > 0 ? 1: -1;

            if(input[0].Y!=0)
                input[0].Y = input[0].Y > 0 ? 1: -1;
//

            var movement = new Vector2(input[0].X, input[0].Y);

            var dt = Time.deltaTime;
            var players = m_Player.ToComponentArray<Player>();

            for (int i = 0; i < players.Length; i++)
            {
                Processing(players[i], movement, dt);
            }
        }

        private void Processing(Player player, Vector2 inputs, float deltaTime)
        {
            float translation = inputs.x * player.speed * deltaTime;
            float rotation = inputs.y * player.rotationSpeed * deltaTime;

            player.transform.Translate(0, 0, translation);
            player.transform.Rotate(0, rotation, 0);  
            player.CheckPosition();
        }
    }
}