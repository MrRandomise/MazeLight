using MazeLight.Core;
using UnityEngine;
using Zenject;

namespace MazeLight.Characters
{
    public sealed class MovePlayer : IMove, IRotate, ITickable
    {
        private Vector3 _moveVector;
        private Camera _camera;
        private Player _player;
        private bool _onMove = false;

        private MovePlayer(Player player)
        {
            _camera = Camera.main;
            _player = player;
        }

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _onMove = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                _onMove = false;
            }
            if (_onMove)
            {
                OnMove();
            }
        }

        public void OnMove()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = _camera.WorldToScreenPoint(_player.transform.position).z;

            Vector3 worldPosition = _camera.ScreenToWorldPoint(mousePosition);
            worldPosition.y = _player.transform.position.y;

            Vector3 direction = (worldPosition - _player.transform.position).normalized;

            _player.transform.position += direction * _player.Speed * Time.deltaTime;

            //OnRotate(direction);
        }

        public void OnRotate(Vector3 dir)
        {
            if (dir != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(dir);
                _player.transform.rotation = Quaternion.RotateTowards(_player.transform.rotation, toRotation, _player.RotateSpeed * Time.deltaTime);
            }
        }
    }
}

