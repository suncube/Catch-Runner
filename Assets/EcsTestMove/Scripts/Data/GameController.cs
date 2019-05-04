using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype.TimeRunner
{
    [RequireComponent(typeof(GameObjectEntity))]
    public class GameController: MonoBehaviour
    {
        public Player Player;
        public Enemy EnemyPrefab;
        public FinishPoint Finish;
        public InputData InputData;
        public Text Result;

        private int catchCount = 0;

        public bool IsGameFinished{get;private set;}
        
        public void CatchPlayer()
        {
            Result.gameObject.SetActive(true);
            Result.text = $"+ {catchCount} points";
            InputData.Block = true;
            IsGameFinished = true;
        }

        public void CatchFinish()
        {
            catchCount ++;
            var newenemy = Instantiate(EnemyPrefab,Vector3.zero, Quaternion.identity);
            // random init speed
            newenemy.speed += Random.Range(-2f,2f);
            newenemy.SetRandomPosition();
            
            // new finish position 
            Finish.SetRandomPosition();
        }
    }

}