using System;

public interface IPlayer
{
    IPickable Item { get; }

    event Action OnDied;

    void InteractWithItem(IInteractable item);
    void EquipItem(IPickable item);
    void ConsumeItem();

    void Kill();
}