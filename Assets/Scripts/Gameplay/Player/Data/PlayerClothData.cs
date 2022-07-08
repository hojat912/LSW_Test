using UnityEngine;

namespace Gameplay.Player.Data
{


    [CreateAssetMenu(fileName = "PlayerAnimationData", menuName = "PlayerAnimationData")]
    public class PlayerClothData : ScriptableObject
    {
        [SerializeField]
        private string _id;
        [SerializeField]
        private Sprite _clothIcon;

        [SerializeField]
        private Sprite[] _leftSprites;
        [SerializeField]
        private Sprite[] _rightSprites;
        [SerializeField]
        private Sprite[] _upSprites;
        [SerializeField]
        private Sprite[] _downSprites;

        [SerializeField]
        private float _frameTime;
        [SerializeField]
        private int _frameCount;

        private (Sprite, Sprite) _lastSprites;
        private EDirection _lastDirection;

        private int _spriteCounter = 0;
        private float _frameTimer = 0;
        private int _spriteIndex;

        public string Id => _id;

        public Sprite ClothIcon { get => _clothIcon; set => _clothIcon = value; }

        public (Sprite, Sprite) GetSprite(EDirection moveDirection)
        {
            if (_lastDirection != moveDirection)
            {
                _spriteCounter = 0;
                _frameTimer = 0;
            }
            else
            {
                _frameTimer += Time.deltaTime;
                if (_frameTimer > _frameTime)
                {
                    _spriteCounter++;
                    _spriteCounter %= 5;
                    _spriteIndex = _spriteCounter < 3 ? _spriteCounter : 5 - _spriteCounter;
                    _frameTimer = 0;
                }
            }


            switch (moveDirection)
            {
                case EDirection.Left:
                    _lastSprites = (_leftSprites[_spriteIndex], _leftSprites[_spriteIndex]);
                    break;
                case EDirection.Right:
                    _lastSprites = (_rightSprites[_spriteIndex], _rightSprites[_spriteIndex]);
                    break;
                case EDirection.Up:
                    _lastSprites = (_upSprites[_spriteIndex], _downSprites[_spriteIndex]);
                    break;
                case EDirection.Down:
                    _lastSprites = (_downSprites[_spriteIndex], _upSprites[_spriteIndex]);
                    break;
                case EDirection.Idle:
                    break;
            }

            _lastDirection = moveDirection;

            return _lastSprites;
        }
    }
}
