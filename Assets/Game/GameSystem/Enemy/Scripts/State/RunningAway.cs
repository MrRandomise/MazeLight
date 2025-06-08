using System;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;

namespace MazeLight.Characters.StateMachine
{
    public sealed class RunningAway: IStateMachine
    {
        private Enemy _enemy;
        private bool _active;

        public RunningAway(Enemy enemy)
        {
            _enemy = enemy;
        }

        public async void Enter()
        {
            Debug.Log($"Бежим! {_enemy.name}");
            _active = true;
            while (_active)
            {
                await Task.Delay(300);
                if(_enemy != null)
                {
                    Vector3 awayVector = _enemy.transform.position - _enemy.Target.transform.position;
                    Vector3 fleeTarget = _enemy.transform.position + awayVector.normalized * _enemy.Config.RuningAwayDistance;
                    _enemy.MoveEnemy.OnMove(fleeTarget);

                }
                await WaitUntil(() => HasReachedDestination(_enemy.NavAgent));
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

        public void Update()
        {

        }
    }
}
