using UnityEngine;

[CreateAssetMenu(menuName = "Configs/" + nameof(CanConfig))]
public class CanConfig : ScriptableObject
{
    [SerializeField] private Color _color;

    public Color Color => _color;
}