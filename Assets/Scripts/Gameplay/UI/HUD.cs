using EventSystem;
using Managment;
using TMPro;
using UnityEngine;


namespace Gameplay.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _coinValue;
        [SerializeField]
        private int _coinCount;
        private IEvent _event;

        private void Start()
        {
            _event = GameManager.ServiceLocator.GetService<IEvent>();
            _event.ListenToEvent<int>(EEventType.RemoveCoint, RemoveCoin);
        }

        public void RemoveCoin(int value)
        {
            _coinCount -= value;
            _coinValue.text = _coinCount.ToString();
        }
    }
}