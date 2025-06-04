using System;
using UnityEngine;
namespace MazeLight.Characters.State
{
    public class AttackEnemy: IEnemyState
    {

        private Enemy _enemy;

        public AttackEnemy(Enemy enemy)
        {
            _enemy = enemy;
            ExecuteState();
        }
        public Action<State> OnState { get; set; }

        public void ExecuteState()
        {
            OnState?.Invoke(State.Attack);
        }

        public void UpdateState()
        {
            Debug.Log("test");
        }

        public IEnemyState GetState()
        {
            return this;
        }
    }
}