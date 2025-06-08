using System;
using UnityEngine;
namespace MazeLight.Characters.StateMachine
{
    public class AttackEnemy: IStateMachine
    {

        private Enemy _enemy;

        public AttackEnemy(Enemy enemy)
        {
            _enemy = enemy;
        }

        public void Enter()
        {

        }

        public void Exit()
        {

        }

        public void Update()
        {

        }

    }
}