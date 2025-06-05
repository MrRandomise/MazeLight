using System;
using UnityEngine;
using System.Threading.Tasks;

namespace MazeLight.Characters.State
{
    public sealed class PatrolEnemy : IEnemyState
    {
        private Enemy _enemy;
        private bool _active;
        public PatrolEnemy(Enemy enemy)
        {
            _enemy = enemy;
            ExecuteState();
        }

        public Action<State> OnState { get; set; }

        public void ExecuteState()
        {
            OnState?.Invoke(State.Patrol);
            _active = true;
            StartPatrol();
        }

        private async void StartPatrol()
        {
            while (_active)
            {
                await Task.Delay(3000);
                var newPoint = GetRandomPoint();
                _enemy.MoveEnemy.OnMove(newPoint);
                await Task.Run(() => _enemy.NavAgent.remainingDistance <= _enemy.NavAgent.stoppingDistance);
                Debug.Log("Пришли");
            }
        }

        public void UpdateState()
        {
            
        }

        private Vector3 GetRandomPoint()
        {
            var point = _enemy.Ground.bounds.size / 2;
            var randPointX = UnityEngine.Random.Range(point.x / 2, point.x);
            var randPointZ = UnityEngine.Random.Range(point.z / 2, point.z);
            var newPoint =  new Vector3(randPointX, 0, randPointZ);


            return newPoint;
        }

        public IEnemyState GetState()
        {
            return this;
        }
    }

}
