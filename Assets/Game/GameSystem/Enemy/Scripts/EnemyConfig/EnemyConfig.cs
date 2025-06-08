using UnityEngine;

namespace MazeLight.Core.Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
    public sealed class EnemyConfig : ScriptableObject
    {
        public string Name = "Enemy";
        public float Speed = 2;
        public float SpeedRotate = 2;
        public float RadiusOrb = 4;
        public float DetectionDistance = 4;
        public float WaitTimePatrol = 3;
        public float ActiveTimer = 5;
        public float RuningAwayDistance = 15;
        public Material Material;
    }
}

