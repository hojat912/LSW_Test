using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Environment
{
    public class InventoryGroupItem : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _keyLabel;
        [SerializeField]
        private Image _clothImage;
        private int _index;
        private Action<int> _onSelect;
        private KeyCode _key;

        public void SetData(int index, Sprite clothSprite, KeyCode key, Action<int> onSelect)
        {
            _index = index;
            _onSelect = onSelect;
            _key = key;
            _keyLabel.text = $"Press {index + 1}";
            _clothImage.sprite = clothSprite;
        }

        private void Update()
        {
            if (Input.GetKeyDown(_key))
            {
                _onSelect?.Invoke(_index);
            }
        }
    }
}