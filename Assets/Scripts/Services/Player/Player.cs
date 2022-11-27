using System;
using UnityEngine;

public class Player: MonoBehaviour
{
    public static Player Instance => _instance;
    private static Player _instance;

    [SerializeField] private PlayerConfig _config;

    private IPickable _item;
    private int _beerCount;

    public IPickable Item => _item;

    public event Action OnDied;
    public event Action<int> OnDrunkBeer;

    private void Awake()
    {
        _instance = this;
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
        _item.Pick();
    }

    private void UnequipItem()
    {
        _item = null;
    }

    public void DrinkBeer()
    {
        _beerCount++;
        OnDrunkBeer?.Invoke(_beerCount);

        if (_beerCount == _config.MaxBeerCount)
        {
            Kill();
        }
    }

    public void Kill()
    {
        OnDied?.Invoke();
    }
}
