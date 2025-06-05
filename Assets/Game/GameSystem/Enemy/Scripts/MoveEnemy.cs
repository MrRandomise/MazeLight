using MazeLight.Core;
using UnityEngine;
using UnityEngine.AI;

namespace MazeLight.Characters
{
    public sealed class MoveEnemy: IMove
    {
        private Enemy _enemy;

        public MoveEnemy(Enemy enemy)
        {
            _enemy = enemy;
        }

        public void OnMove(Vector3 dir)
        {
            _enemy.NavAgent.destination = dir;
        }
    }
}

