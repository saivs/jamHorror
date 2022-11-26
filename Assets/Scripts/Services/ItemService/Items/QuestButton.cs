using System;
using UnityEngine;

public class QuestButton : Item, IInteractable
{
    [SerializeField] private MeshRenderer _meshRenderer;

    private bool _painted;

    public event Action OnActivated;

    public void Interact(IPlayer player)
    {
        if (!_painted)
        {
            if (player.Item is Brush brush)
            {
                if (brush.Painted)
                {
                    Paint(brush.CurrentColor);
                    return;
                }
            }
        }
        Press(player);
    }

    private void Paint(Color color)
    {
        _painted = true;
        _meshRenderer.material.color = color;
    }

    private void Press(IPlayer player)
    {
        if (_painted)
        {
            OnActivated?.Invoke();
        }
        else
        {
            player.Kill();
        }
    }
}
