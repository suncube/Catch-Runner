using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Prototype.TimeRunner
{
    public class GameLogicSystem : ComponentSystem
    { 
        EntityQuery m_Player;
        EntityQuery m_Enemy;
        EntityQuery m_Game;
        EntityQuery m_Finish;

        private bool isFinishCatch;

        protected override void OnCreate()
        {
            m_Player = GetEntityQuery(typeof(Player));
            m_Enemy = GetEntityQuery(typeof(Enemy));
            m_Game = GetEntityQuery(typeof(GameController));
            m_Finish = GetEntityQuery(typeof(FinishPoint));
        }

        protected override void OnUpdate()
        {
            //
            var game = m_Game.ToComponentArray<GameController>();
            if( game[0].IsGameFinished) return;

            var players = m_Player.ToComponentArray<Player>();
            var enemy = m_Enemy.ToComponentArray<Enemy>();
            var finish = m_Finish.ToComponentArray<FinishPoint>();

            for (int i = 0; i < enemy.Length; i++)
            {
                if(players[0].TracingCollision(enemy[i]))
                {
                    // lose game
                    Debug.Log("Enemy Catch "+ enemy[i].gameObject.name);
                    game[0].CatchPlayer();

                }
            }

            if(players[0].TracingCollision(finish[0]))
            {
                if(!isFinishCatch)
                {
                    isFinishCatch = false;
                    game[0].CatchFinish();
                }
            }
            else
            {
                isFinishCatch = false;
            }
            
        }

       
    }
}