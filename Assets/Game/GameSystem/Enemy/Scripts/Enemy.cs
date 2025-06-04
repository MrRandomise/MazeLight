using MazeLight.Characters.State;
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
        [SerializeField] private EnemyConfig _config;
        public MeshRenderer maskMaterial;
        public GameObject Model;
        public NavMeshAgent meshAgent;
        public MoveEnemy MoveEnemy;
        public MeshRenderer Ground;
        public IEnemyState EnemyState;


        public void Awake()
        {
            MoveEnemy = new MoveEnemy(this);
        }

        public void Start()
        {
            Speed = _config.Speed;
            RotateSpeed = _config.SpeedRotate;
            maskMaterial.material = _config.Material;
            Model.transform.localScale = new Vector3(_config.Size, _config.Size, _config.Size);
            EnemyState = new PatrolEnemy(this);
        }

        private void Update()
        {
            EnemyState.UpdateState();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(0,255,0, 0.1f);
            Gizmos.DrawSphere(transform.position, _config.RadiusAttack);
        }
    }
}

