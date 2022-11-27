using System;
using UnityEngine;

public class Player: MonoBehaviour
{
    public static Player Instance => _instance;
    private static Player _instance;

    [SerializeField] private DrunkConfig _drunkConfig;

    private int _beerCount;

    public Item Item => ItemHolder.Item;

    public event Action OnDied;
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
        OnDrunkBeer?.Invoke(_beerCount);

        if (_beerCount == _drunkConfig.MaxBeerCount)
        {
            SoundConfig.Instance.BeerDrinkLast.PlayAtPoint(transform);
            Kill();
        }
        else
        {
            SoundConfig.Instance.BeerDrink.PlayAtPoint(transform);
        }
    }

    public void Kill()
    {
        OnDied?.Invoke();
    }
}
