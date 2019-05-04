using Unity.Entities;
using UnityEngine;

namespace Prototype.TimeRunner
{
    [RequireComponent(typeof(GameObjectEntity))]
    public class InputData: EntityObject
    {
        public float X;
        public float Y;

        public bool isActive
        { 
            get{ return Block ? false : _isActive;}
            set{ _isActive = value;}
        }
        public bool Block{ get; set;}

        private bool _isActive;
    }

}