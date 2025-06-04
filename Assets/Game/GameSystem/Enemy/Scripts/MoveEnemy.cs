using MazeLight.Core;
using UnityEngine;

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
            _enemy.meshAgent.SetDestination(dir);
        }
    }
}

