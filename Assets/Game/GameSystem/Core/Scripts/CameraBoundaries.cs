using UnityEngine;
using MazeLight.Characters;
using Zenject;

namespace MazeLight.Core
{
    public sealed class CameraBoundaries : ITickable
    {
        private Camera camera;
        private Player _player;

        private CameraBoundaries(Player player)
        {
            _player = player;
            camera = Camera.main;
        }

       public void Tick()
       {
            if (_player.maskMaterial != null && _player != null)
            {
                _player.maskMaterial.SetVector("_LightPos", _player.Light.transform.position);
                _player.maskMaterial.SetFloat("_Radius", _player.Light.range);
                Debug.Log($"Light Position: {_player.Light.transform.position}, Radius: {_player.Light.range}");
            }
        }
    }
}

