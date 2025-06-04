using UnityEngine;

namespace MazeLight.Core.Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
    public sealed class EnemyConfig : ScriptableObject
    {
        public string Name = "Enemy";
        public float Speed = 2;
        public float SpeedRotate = 2;
        public float Size = 2;
        public float RadiusAttack = 4;
        public Material Material;
    }
}

