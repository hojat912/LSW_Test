using System;
using TMPro;
using UnityEngine;
namespace Gameplay.Environment
{
    public class Executable : MonoBehaviour, IExecutable
    {
        [SerializeField]
        private KeyCode _openCloseKey = KeyCode.F;

        [SerializeField]
        private GameObject _item;
        [SerializeField]
        private TextMeshProUGUI _keyLabel;

        private bool _canChange;
        private Action _execute;

        public bool CanExecute => _canChange;

        private void Awake()
        {
            _item.SetActive(false);
            if (_keyLabel)
                _keyLabel.text = $"Press {_openCloseKey}";
        }

        private void Update()
        {
            if (_canChange && Input.GetKeyDown(_openCloseKey))
            {
                Execute();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                _item.SetActive(true);
                _canChange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                _item.SetActive(false);
                _canChange = false;
            }
        }

        public void Execute()
        {
            _execute?.Invoke();
        }

        public void SetAction(Action execute)
        {
            _execute = execute;

        }

        public void SetAction(KeyCode keyCode, Action execute)
        {
            _openCloseKey = keyCode;
            _execute = execute;
            _keyLabel.text = $"Press {_openCloseKey}";
        }
    }
}