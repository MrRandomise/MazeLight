using MazeLight.Characters.StateMachine;
using MazeLight.Core.Configs;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace MazeLight.Characters
{

     
    public sealed class Enemy : MonoBehaviour
    {
        [NonSerialized] public float Speed = 3;
        [NonSerialized] public float RotateSpeed = 6;
        [NonSerialized] public Player Target;
        [SerializeField] private SphereCollider _colider;
        private StateControl _stateControl;
        public EnemyConfig Config;
        public MeshRenderer maskMaterial;
        public GameObject Model;
        public NavMeshAgent NavAgent;
        public MoveEnemy MoveEnemy;
        public MeshRenderer Ground;
        public State State = new State();

        public void Start()
        {
            Speed = Config.Speed;
            RotateSpeed = Config.SpeedRotate;
            maskMaterial.material = Config.Material;
            _colider.radius = Config.DetectionDistance;
            _stateControl = new StateControl(this);
            MoveEnemy = new MoveEnemy(this);
            Model.transform.localScale = new Vector3(Config.RadiusOrb, Config.RadiusOrb, Config.RadiusOrb);
            var newPosY = Model.transform.position.y * 2;
            transform.position = new Vector3(transform.position.x, newPosY, transform.position.z);

        }

        private void Update()
        {
            State.CurrentState.Update();
        }

        private void OnTriggerEnter(Collider other)
        {
            _stateControl.OnTrigger(other);
        }

        private void OnTriggerExit(Collider other)
        {
            _stateControl.OnTriggerExit(other);
        }
    }
}

