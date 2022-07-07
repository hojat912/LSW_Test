using System;
using UnityEngine;

public class PlayerSpriteHandler : MonoBehaviour
{


    [SerializeField]
    private SpriteRenderer _playerSpriteRenderer;

    [SerializeField]
    private PlayerAnimationData _animatonData;

    [SerializeField]
    private float _horizontalSpeed;

    [SerializeField]
    private float _verticalSpeed;

    [SerializeField]
    private SpriteRenderer _mirrorSpriteRenderer;

    private Transform _transform;

    public void SetSortingOrder(int targetSortingOrder)
    {
        _mirrorSpriteRenderer.sortingOrder = targetSortingOrder - 1;
        _playerSpriteRenderer.sortingOrder = targetSortingOrder;

    }

    private void Awake()
    {
        _transform = transform;
        SetSprites(EDirection.Down);
    }



    void Update()
    {
        Vector3 currentPos = _transform.position;
        Vector3 moveDirection = GetInputValue();
        _transform.position = currentPos + moveDirection * Time.deltaTime;
        EDirection direction= CalculateMoveDirection(moveDirection);
        SetSprites(direction);
    }

    private void SetSprites(EDirection direction)
    {
        (Sprite playerSprite, Sprite mirrorSprite) = _animatonData.GetSprite(direction);
        _playerSpriteRenderer.sprite = playerSprite;
        _mirrorSpriteRenderer.sprite = mirrorSprite;
    }

    public void SetSpriteData(PlayerAnimationData newCloth)
    {
        _animatonData = newCloth;
        SetSprites(EDirection.Down);
    }

    private Vector3 GetInputValue()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y += _verticalSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y -= _verticalSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x += _horizontalSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x -= _horizontalSpeed;
        }

        return moveDirection;
    }

    private EDirection CalculateMoveDirection(Vector3 moveDirection)
    {
        if (moveDirection.x > 0)
        {
            return EDirection.Right;
        }
        else if (moveDirection.x < 0)
        {
            return EDirection.Left;
        }
        else if (moveDirection.y > 0)
        {
            return EDirection.Up;
        }
        else if (moveDirection.y < 0)
        {
            return EDirection.Down;
        }
        else
        {
            return EDirection.Idle;
        }
    }
}
