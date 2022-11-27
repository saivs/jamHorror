using UnityEngine;

[CreateAssetMenu(menuName = "Configs/" + nameof(DrunkConfig))]
public class DrunkConfig : ScriptableObject
{
    [SerializeField] private int _maxBeerCount;

    public int MaxBeerCount => _maxBeerCount;
}
