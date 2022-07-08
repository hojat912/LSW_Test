using EventSystem;
using Gameplay.Player.Data;
using Managment;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Environment
{

    [RequireComponent(typeof(IExecutable))]
    public class ClothesChanger : MonoBehaviour
    {
        [SerializeField]
        private PlayerClothData _newCloth;
        [SerializeField]
        private Image _clothImage;
        [SerializeField]
        private int _price;
        [SerializeField]
        private TextMeshProUGUI _priceLabel;
        [SerializeField]
        private bool _isSaleable;

        private IEvent _event;
        private bool _isBought;

        void Start()
        {
            _event = GameManager.ServiceLocator.GetService<IEvent>();
            IExecutable executable = GetComponent<IExecutable>();
            executable.SetAction(GetCloth);
            if (_isSaleable)
                _priceLabel.text = _price.ToString();
            _clothImage.sprite = _newCloth.ClothIcon;
        }


        private void GetCloth()
        {

            _event.BroadcastEvent<PlayerClothData>(EEventType.SelectCloth, _newCloth);
            if (_isSaleable && !_isBought)
            {
                _event.BroadcastEvent<int>(EEventType.RemoveCoint, _price);
                _isBought = true;
                _priceLabel.gameObject.SetActive(false);
            }
        }
    }
}