using System;
using UnityEngine;
namespace MazeLight.Characters.State
{
    public class HarassEnemy: IEnemyState
    {

        private Enemy _enemy;

        public HarassEnemy(Enemy enemy)
        {
            _enemy = enemy;
            ExecuteState();
        }

        public Action<State> OnState { get; set; }

        public void ExecuteState()
        {
            OnState?.Invoke(State.Harassment);
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