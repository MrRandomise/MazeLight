using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace MazeLight.Characters.StateMachine
{
    public sealed class PatrolEnemy : IStateMachine
    {
        private Enemy _enemy;
        private bool _active;

        public PatrolEnemy(Enemy enemy)
        {
            _enemy = enemy;
        }

        public Action<State> OnState { get; set; }

        public async void Enter()
        {
            if (_enemy != null)
            {
                Debug.Log($"Патрулируем! {_enemy.name}");
                _active = true;
                while (_active)
                {
                    var timer = (int)_enemy.Config.WaitTimePatrol * 1000;
                    await Task.Delay(timer);
                    var newPoint = GetRandomPoint();
                    _enemy.MoveEnemy.OnMove(newPoint);
                    await WaitUntil(() => HasReachedDestination(_enemy.NavAgent));
                }
            }
            
        }

        bool HasReachedDestination(NavMeshAgent agent)
        {
            if (agent == null || !agent.isOnNavMesh || !agent.isActiveAndEnabled)
                return true;

            if (agent.pathPending)
                return false;

            bool closeEnough = agent.remainingDistance <= agent.stoppingDistance;
            bool noMorePath = !agent.hasPath || agent.velocity.sqrMagnitude == 0f;
            bool complete = agent.pathStatus == NavMeshPathStatus.PathComplete;

            return closeEnough && noMorePath && complete;
        }

        public void Update()
        {
            
        }

        private Vector3 GetRandomPoint()
        {
            var point = _enemy.Ground.bounds.size / 2;
            var randPointX = UnityEngine.Random.Range(-point.x, point.x);
            var randPointZ = UnityEngine.Random.Range(-point.z, point.z);
            var newPoint =  new Vector3(randPointX, 0, randPointZ);


            return newPoint;
        }

        public static async Task WaitUntil(Func<bool> predicate)
        {
            while (!predicate())
            {
                await Task.Yield();
            }   
        }

        public void Exit()
        {
            _active = false;
            _enemy.NavAgent.isStopped = true;
        }
    }

}
