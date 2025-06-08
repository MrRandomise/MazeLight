using MazeLight.UI;
using UnityEngine;
using MazeLight.Characters;
namespace MazeLight.Items
{
    public  sealed class Item : MonoBehaviour
    {
        public ItemView ItemView;
        public RectTransform itemIconTarget;
        [SerializeReference] private ItemControl Items;
        public GameObject Active;
        public GameObject NonActive;
        public float Timer;

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                var player = other.GetComponent<Player>();
                Items.EcecuteItem(this);
            }
        }
    }
}