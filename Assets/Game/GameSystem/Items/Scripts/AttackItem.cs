using MazeLight.Characters;
using System;
using UnityEngine;

namespace MazeLight.Items
{
    [Serializable]
    public class AttackItem : ItemControl
    {
        [SerializeField] private float _radius = 5;

        public override void EcecuteItem(Item item)
        {
            base.EcecuteItem(item);
            _player.RadiusOrb += _radius;
        }

        protected override void UnExecuteItem()
        {
            _player.RadiusOrb -= _radius;
        }
    }
}