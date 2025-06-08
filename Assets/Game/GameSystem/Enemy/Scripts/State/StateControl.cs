using MazeLight.Items;
using System;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

namespace MazeLight.Characters.StateMachine
{
    public sealed  class StateControl : IDisposable
    {
        private Enemy _enemy;
        private PatrolEnemy _enemyPatrol;
        private HarassEnemy _harassEnemy;
        private AttackEnemy _attackEnemy;
        private RunningAway _runningAway;
        private bool _isTrigger = false;

        public StateControl(Enemy enemy)
        {
            _enemy = enemy;
            _enemyPatrol = new PatrolEnemy(enemy);
            _harassEnemy = new HarassEnemy(enemy);
            _attackEnemy = new AttackEnemy(enemy);
            _runningAway = new RunningAway(enemy);
            _enemy.State.Initialize(_enemyPatrol);
            ItemControl.ExectuteBonus += PlayetGetBonus;
        }

        public void OnTrigger(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _isTrigger = true;
                _enemy.Target = other.GetComponent<Player>();
                if(_enemy.Config.RadiusOrb > _enemy.Target.RadiusOrb)
                {
                    _enemy.State.Initialize(_harassEnemy);
                }
                else if (_enemy.Config.RadiusOrb <= _enemy.Target.RadiusOrb)
                {
                    _enemy.State.Initialize(_runningAway);
                }
            }
        }

        private void PlayetGetBonus()
        {
            if (_enemy.State.CurrentState == _harassEnemy &&  _enemy.Config.RadiusOrb <= _enemy.Target.RadiusOrb)
            {
                _enemy.State.Initialize(_runningAway);
            }
        }

        public async void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _isTrigger = false;
                var timer = (int)_enemy.Config.ActiveTimer * 1000;
                await Task.Delay(timer);
                if (!_isTrigger)
                {
                    _enemy.State.Initialize(_enemyPatrol);
                }
            }
        }

        public void Dispose()
        {
            ItemControl.ExectuteBonus -= PlayetGetBonus;
        }
    }
}