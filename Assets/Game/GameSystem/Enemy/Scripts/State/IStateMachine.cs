using UnityEngine;
namespace MazeLight.Characters.StateMachine
{
    public interface IStateMachine
    {
        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
    }
}