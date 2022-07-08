using System;
using UnityEngine;
namespace Gameplay.Player
{
    public class PlayerInputHandler : MonoBehaviour, IPlayerInput
    {
        private EDirection _currentDirection;
        private Action<EDirection> _onMove;

        public EDirection CurrentDirection => _currentDirection;


        void Update()
        {
            GetInputValue();
        }

        public void OnInputChanged(Action<EDirection> onMove)
        {
            _onMove += onMove;
        }

        private void GetInputValue()
        {
            if (Input.GetKey(KeyCode.D))
            {
                _currentDirection = EDirection.Right;
                _onMove?.Invoke(_currentDirection);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                _currentDirection = EDirection.Left;
                _onMove?.Invoke(_currentDirection);
            }

            else if (Input.GetKey(KeyCode.W))
            {
                _currentDirection = EDirection.Up;
                _onMove?.Invoke(_currentDirection);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                _currentDirection = EDirection.Down;
                _onMove?.Invoke(_currentDirection);
            }
        }
    }
}
