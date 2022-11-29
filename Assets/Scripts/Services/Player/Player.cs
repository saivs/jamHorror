using System;
using UnityEngine;

public class Player: MonoBehaviour
{
    public static Player Instance => _instance;
    private static Player _instance;

    [SerializeField] private DrunkConfig _drunkConfig;

    private int _beerCount;

    public Item Item => ItemHolder.Item;

    public event Action<string> OnDied;
    public event Action<int> OnDrunkBeer;

    public ItemHolder ItemHolder { get; private set; }

    private void Awake()
    {
        _instance = this;

        ItemHolder = GetComponent<ItemHolder>();
    }

    public void DrinkBeer()
    {
        _beerCount++;
        SoundConfig.Instance.BeerDrink.PlayAtPoint(transform);

        OnDrunkBeer?.Invoke(_beerCount);

        if (_beerCount == _drunkConfig.MaxBeerCount)
        {
            Kill(DeathMessageConfig.Instance.Beer);
        }
    }

    public void Kill(string message)
    {
        OnDied?.Invoke(message);
    }
}
