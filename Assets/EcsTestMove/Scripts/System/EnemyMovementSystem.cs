using Unity.Entities;
using UnityEngine;

namespace Prototype.TimeRunner
{
    public class EnemyMovementSystem : ComponentSystem
    { 
        EntityQuery m_Player;
        EntityQuery m_Enemy;
        EntityQuery m_Input;

        protected override void OnCreate()
        {
            m_Player = GetEntityQuery(typeof(Player));
            m_Enemy = GetEntityQuery(typeof(Enemy));
            m_Input = GetEntityQuery(typeof(InputData));
        }

        protected override void OnUpdate()
        {
             var input = m_Input.ToComponentArray<InputData>();
            if(input.Length == 0 || !input[0].isActive) return;
            
            var players = m_Player.ToComponentArray<Player>();
            var dt = Time.deltaTime;
            var enemy = m_Enemy.ToComponentArray<Enemy>();

            for (int i = 0; i < enemy.Length; i++)
            {
                Processing(enemy[i], players[0].Position, dt);
            }
        }

        private void Processing(Enemy enemy, Vector3 player, float deltaTime)
        {
            float step =  enemy.speed * deltaTime;
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player, step);

            var lookPos = player - enemy.transform.position;
            var rotation = Quaternion.LookRotation(lookPos);
            enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, rotation, deltaTime * enemy.rotationSpeed);
           
        }
    }
}