using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingOrderChanger : MonoBehaviour
{
    [SerializeField]
    private int _targetSortingOrder;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerSpriteHandler player= collision.GetComponent<PlayerSpriteHandler>();
        if (player)
        {
            player.SetSortingOrder(_targetSortingOrder);
        }
    }
}
