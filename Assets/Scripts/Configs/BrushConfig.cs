using UnityEngine;

[CreateAssetMenu(menuName = "Configs/" + nameof(BrushConfig))]
public class BrushConfig: ScriptableObject
{
    [SerializeField] private int _clearTimer;

    public int ClearTimer => _clearTimer;
}
