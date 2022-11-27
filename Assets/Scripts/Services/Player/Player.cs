using System;
using UnityEngine;

public class Player: MonoBehaviour
{
    public static Player Instance => _instance;
    private static Player _instance;

    private IPickable _item;

    public IPickable Item => _item;

    public event Action OnDied;

    public ItemHolder ItemHolder { get; private set; }

    private void Awake()
    {
        _instance = this;

        ItemHolder = GetComponent<ItemHolder>();
    }

    public void InteractWithItem(IInteractable item)
    {
        item.Interact();
    }

    public void ConsumeItem()
    {
        var item = _item;
        UnequipItem();
        Destroy(item.gameObject);
    }

    public void EquipItem(IPickable item)
    {
        if (_item != null)
        {
            UnequipItem();
        }

        _item = item;
    }

    private void UnequipItem()
    {
        _item = null;
    }

    public void Kill()
    {
        OnDied?.Invoke();
    }
}
