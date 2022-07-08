using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Player
{
    public class SortingOrderChanger : MonoBehaviour
    {
        [SerializeField]
        private int _targetSortingOrder;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IPlayerSpriteHandler player = collision.GetComponent<IPlayerSpriteHandler>();
            if (player != null)
            {
                player.SetSortingOrder(_targetSortingOrder);
            }
        }
    }
}