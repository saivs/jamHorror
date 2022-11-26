using System;
using UnityEngine;

public class QuestButton : Item, IInteractable
{
    [SerializeField] private MeshRenderer _meshRenderer;

    public event Action OnActivated;

    public void Interact(IPlayer player)
    {
        if (player.Item is Brush brush)
        {
            if (brush.Painted)
            {
                Paint(brush.CurrentColor);
                PressToActivate();
                return;
            }
        }
        PressToKill(player);
    }

    private void Paint(Color color)
    {
        _meshRenderer.material.color = color;
    }

    private void PressToActivate()
    {
        OnActivated?.Invoke();
    }

    private void PressToKill(IPlayer player)
    {
        player.Kill();
    }
}
