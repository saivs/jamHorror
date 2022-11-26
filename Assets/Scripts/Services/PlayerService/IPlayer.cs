using System;

public interface IPlayer
{
    IPickable Item { get; }

    event Action OnDied;

    void InteractWithItem(IInteractable item);
    void PickItem(IPickable item);

    void Kill();
}