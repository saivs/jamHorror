using UnityEngine;

public class Can : Item, IInteractable
{
    [SerializeField] private CanConfig _config;

    public void Interact(IPlayer player)
    {
        if (player.Item is Brush brush)
        {
            brush.Paint(_config.Color);
            return;
        }
    }
}