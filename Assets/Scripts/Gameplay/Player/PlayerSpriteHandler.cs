using EventSystem;
using Gameplay.Player.Data;
using Managment;
using System.Collections.Generic;
using UnityEngine;
namespace Gameplay.Player
{
    public class PlayerSpriteHandler : MonoBehaviour, IPlayerSpriteHandler
    {
        private IPlayerInput _playerInput;
        private IEvent _event;

        [SerializeField]
        private PlayerClothData _defaultCloth;

        [SerializeField]
        private PlayerClothData _withoutCloth;

        [SerializeField]
        private SpriteRenderer _playerSpriteRenderer;
        [SerializeField]
        private SpriteRenderer _mirrorSpriteRenderer;

        private List<PlayerClothData> _inventory;
        private PlayerClothData _currentCloth;

        public List<PlayerClothData> Inventory => _inventory;

        private void Start()
        {
            _inventory = new List<PlayerClothData>();
            _inventory.Add(_defaultCloth);
            _inventory.Add(_withoutCloth);
            _currentCloth = _defaultCloth;

            _playerInput = GetComponent<IPlayerInput>();
            _event = GameManager.ServiceLocator.GetService<IEvent>();
            _event.ListenToEvent<PlayerClothData>(EEventType.SelectCloth, SelectCloth);
            SetSprites(EDirection.Down);
            _playerInput.OnInputChanged(SetSprites);
        }

        public void SetSortingOrder(int targetSortingOrder)
        {
            _mirrorSpriteRenderer.sortingOrder = targetSortingOrder - 1;
            _playerSpriteRenderer.sortingOrder = targetSortingOrder;
        }

        private void SetSprites(EDirection direction)
        {
            (Sprite playerSprite, Sprite mirrorSprite) = _currentCloth.GetSprite(direction);
            _playerSpriteRenderer.sprite = playerSprite;
            _mirrorSpriteRenderer.sprite = mirrorSprite;
        }

        public void SelectCloth(PlayerClothData newCloth)
        {
            _currentCloth = newCloth;
            if (!_inventory.Contains(newCloth))
                _inventory.Add(newCloth);
            SetSprites(EDirection.Down);
        }

    }
}