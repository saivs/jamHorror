using System;
using UnityEngine;

public class Player: MonoBehaviour, IPlayer
{
    private IPickable _item;

    public IPickable Item => _item;

    public event Action OnDied;

    public void InteractWithItem(IInteractable item)
    {
        item.Interact(this);
    }

    public void PickItem(IPickable item)
    {
        if (_item != null)
        {
            ThrowItem();
        }

        _item = item;
    }

    private void ThrowItem()
    {
        _item = null;
    }

    public void Kill()
    {
        OnDied?.Invoke();
    }
}
