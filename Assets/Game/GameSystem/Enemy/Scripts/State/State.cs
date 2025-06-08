using UnityEngine;

namespace MazeLight.Characters.StateMachine
{
    public sealed class State
    {
        public IStateMachine CurrentState;

        public void Initialize(IStateMachine StartState)
        {
            CurrentState = StartState;
            CurrentState.Enter();
        }

        public void ChangeState(IStateMachine newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}