using Unity.Entities;
using UnityEngine;

namespace Prototype.TimeRunner
{
    public class InputSystem : ComponentSystem
    { 
        EntityQuery m_Input;
        protected override void OnCreate()
        {
            m_Input = GetEntityQuery(typeof(InputData));
        }

        protected override void OnUpdate()
        {
            var dt = Time.deltaTime;
            var input = m_Input.ToComponentArray<InputData>();

            if(input.Length == 0) return;

            var X = Input.GetAxis("Vertical");
            var Y = Input.GetAxis("Horizontal");
            
            if(X != 0 || Y!=0)
            {
                input[0].X = X;
                input[0].Y = Y;
                input[0].isActive = true;
            }
            else
            {
                input[0].isActive = false;
            }

        }}
}