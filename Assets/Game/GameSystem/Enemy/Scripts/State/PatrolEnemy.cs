using System;
using UnityEngine;

namespace MazeLight.Characters.State
{
    public sealed class PatrolEnemy : IEnemyState
    {
        private Enemy _enemy;

        public PatrolEnemy(Enemy enemy)
        {
            _enemy = enemy;
            ExecuteState();
        }

        public Action<State> OnState { get; set; }

        public void ExecuteState()
        {
            OnState?.Invoke(State.Patrol);
            var newPoint = GetRandomPoint();
            _enemy.MoveEnemy.OnMove(newPoint);
        }

        public void UpdateState()
        {
            
        }

        private Vector3 GetRandomPoint()
        {
            var point = _enemy.Ground.bounds.size;
            Debug.Log(point);
            var randPointX = UnityEngine.Random.Range(0, point.x);
            var randPointZ = UnityEngine.Random.Range(0, point.z);
            var newPoint =  new Vector3(randPointX, 0, randPointZ);


            return newPoint;
        }

        public IEnemyState GetState()
        {
            return this;
        }
    }

}
