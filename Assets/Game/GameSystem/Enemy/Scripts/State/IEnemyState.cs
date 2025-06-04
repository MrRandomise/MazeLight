using System;

namespace MazeLight.Characters.State
{
    public enum State
    {
        Patrol,
        Harassment,
        Attack
    };

    public interface IEnemyState
    {
        public Action<State> OnState { get; set; }

        public void ExecuteState();

        public void UpdateState();

        public IEnemyState GetState();

    }

}

