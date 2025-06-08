using DG.Tweening;
using MazeLight.Characters;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace MazeLight.Items
{
    public abstract class ItemControl
    {
        [SerializeField] protected string _name;
        [SerializeField] protected Player _player;
        public static Action ExectuteBonus;
        private bool _activated = false;

        public virtual void EcecuteItem(Item item)
        {
            float time = 0;
            FlyDotWeen(item);
            if (item.ItemView.isActiveAndEnabled)
            {
                time = float.Parse(item.ItemView.Timer.text);
            }
            //else
            //{
            //    item.ItemView.gameObject.SetActive(true);
            //}

            time += item.Timer;
            item.ItemView.Timer.text = time.ToString();

            ExectuteBonus?.Invoke();
            if (!_activated)
            {
                Timer(item);
            }
        }

        public virtual async void Timer(Item item)
        {
            _activated = true;
            while (float.Parse(item.ItemView.Timer.text) > 0)
            {
                await Task.Delay(1000);
                var time = float.Parse(item.ItemView.Timer.text);
                time -= 1;
                item.ItemView.Timer.text = time.ToString();
            }
            item.ItemView.gameObject.SetActive(false);
            _activated = false;
            UnExecuteItem();
        }

        private void FlyDotWeen(Item item)
        {
            item.ItemView.gameObject.SetActive(true);

            // 1) Параллельно двигаем и масштабируем
            item.transform
                .DOScale(0f, 0.5f)
                .SetEase(Ease.InBack);

            // Двигаем в точку за 0.7 секунды
            //item.transform
            //    .DOMove(screenPoint, 0.7f)
            //    .SetEase(Ease.InQuad)
            //    .OnComplete(() =>
            //    {
            //        item.Parent.parent = item.NonActive.transform;
            //        item.ItemView.gameObject.SetActive(true);
            //    });

            //item.transform
            //    .DOScale(0f, 0.7f)
            //    .SetEase(Ease.InBack)
            //    .OnComplete(() =>
            //    {
            //        item.Parent.parent = item.NonActive.transform;

            //    });

        }
        protected virtual void UnExecuteItem() { }

    }
}

