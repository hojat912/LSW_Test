using Gameplay.Player.Data;
using System.Collections.Generic;


namespace Gameplay.Player
{
    public interface IPlayerSpriteHandler
    {
        void SetSortingOrder(int targetSortingOrder);
        List<PlayerClothData> Inventory { get; }
    }
}