using EventSystem;
using Gameplay.Player;
using Gameplay.Player.Data;
using Managment;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Environment
{
    public class InventoryExecutableGroup : MonoBehaviour
    {
        [SerializeField]
        private InventoryGroupItem _inventoryGroupPrefab;

        [SerializeField]
        private GameObject _canvas;

        [SerializeField]
        private Transform _root;

        private bool _canChange;


        private List<InventoryGroupItem> _lastItems;
        private IEvent _event;
        private List<PlayerClothData> _couurentClothes;

        private void Start()
        {
            _lastItems = new List<InventoryGroupItem>();
            _event = GameManager.ServiceLocator.GetService<IEvent>();
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                CleareLastItems();

                List<PlayerClothData> clothes = collision.GetComponent<IPlayerSpriteHandler>().Inventory;
                _couurentClothes = clothes;
                int count = clothes.Count;
                for (int i = 0; i < count; i++)
                {
                    InventoryGroupItem item = Instantiate(_inventoryGroupPrefab, _root);
                    int index = i;
                    item.SetData(index, clothes[index].ClothIcon, KeyCode.Alpha1 + index, OnSelect);
                    _lastItems.Add(item);
                }
                _canvas.SetActive(true);
                _canChange = true;
            }
        }

        private void OnSelect(int index)
        {
            if (_canChange)
            {
                if (_couurentClothes.Count > index)
                    _event.BroadcastEvent<PlayerClothData>(EEventType.SelectCloth, _couurentClothes[index]);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                CleareLastItems();
                _canvas.SetActive(false);
                _canChange = false;

            }
        }

        private void CleareLastItems()
        {
            int count = _lastItems.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                Destroy(_lastItems[i].gameObject);
            }
            _lastItems.Clear();
        }
    }
}