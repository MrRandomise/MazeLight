using UnityEngine;
namespace MazeLight.Characters
{
    public sealed class Player : MonoBehaviour
    {
        public float Speed = 3;
        public float RotateSpeed = 6;
        public float RadiusOrb = 1;
        public Light Light;
        public Material maskMaterial;
        public GameObject Model;
    }
}

