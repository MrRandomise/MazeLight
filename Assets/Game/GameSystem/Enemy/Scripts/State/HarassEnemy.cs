using UnityEngine;
namespace MazeLight.Characters.StateMachine
{
    public class HarassEnemy: IStateMachine
    {

        private Enemy _enemy;

        public HarassEnemy(Enemy enemy)
        {
            _enemy = enemy;
        }

        public void Enter()
        {
            Debug.Log($"Преследуем!{_enemy.name}");
        }

        public void Exit()
        {

        }

        public void Update()
        {
            _enemy.MoveEnemy.OnMove(_enemy.Target.transform.position);
        }
    }
}