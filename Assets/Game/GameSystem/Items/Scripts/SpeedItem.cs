using MazeLight.Characters;
using System;
using UnityEngine;

namespace MazeLight.Items
{
    [Serializable]
    public sealed class SpeedItem : ItemControl
    {
        [SerializeField] private float _speed = 5;

        public override void EcecuteItem(Item item)
        {
            base.EcecuteItem(item);
            _player.Speed += _speed;
        }



        protected override void UnExecuteItem()
        {
            _player.Speed -= _speed;
        }
    }
}