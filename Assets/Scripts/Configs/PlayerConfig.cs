using UnityEngine;

[CreateAssetMenu(menuName = "Configs/" + nameof(PlayerConfig))]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private int _maxBeerCount;

    public int MaxBeerCount => _maxBeerCount;
}
