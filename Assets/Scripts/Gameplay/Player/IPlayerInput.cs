using System;

namespace Gameplay.Player
{
    public interface IPlayerInput
    {
        EDirection CurrentDirection { get; }
        void OnInputChanged(Action<EDirection> onMove);
    }
}