using EventSystem;
using Managment;
using UnityEngine;
namespace Gameplay.Player
{
    public enum EDirection
    {
        Left,
        Right,
        Up,
        Down,
        Idle
    }

    public class PlayerMovement : MonoBehaviour
    {

        [SerializeField]
        private float _horizontalSpeed;

        [SerializeField]
        private float _verticalSpeed;

        private IPlayerInput _playerInput;

        private Transform _transform;

        private void Start()
        {
            _transform = transform;
            _playerInput = GetComponent<IPlayerInput>();
            _playerInput.OnInputChanged(OnPlayerMove);
        }

        void OnPlayerMove(EDirection direction)
        {
            Vector3 currentPos = _transform.position;
            Vector3 moveDirection = GetInputValue(direction);
            _transform.position = currentPos + moveDirection * Time.deltaTime;
        }


        private Vector3 GetInputValue(EDirection direction)
        {
            Vector3 moveDirection = Vector3.zero;
            switch (direction)
            {
                case EDirection.Left:
                    moveDirection.x -= _horizontalSpeed;
                    break;
                case EDirection.Right:
                    moveDirection.x += _horizontalSpeed;
                    break;
                case EDirection.Up:
                    moveDirection.y += _verticalSpeed;
                    break;
                case EDirection.Down:
                    moveDirection.y -= _verticalSpeed;
                    break;
                case EDirection.Idle:
                    break;
            }

            return moveDirection;
        }

    }
}