using UnityEngine;

public class Can : Item, IInteractable
{
    [SerializeField] private CanConfig _config;
    [SerializeField] private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer.material.color = _config.Color;
    }

    public void Interact(IPlayer player)
    {
        if (player.Item is Brush brush)
        {
            brush.Paint(_config.Color);
            return;
        }
    }
}