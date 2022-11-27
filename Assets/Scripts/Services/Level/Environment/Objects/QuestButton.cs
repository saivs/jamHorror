using UnityEngine;

public class QuestButton : MonoBehaviour, IInteractable
{
    [SerializeField] private MeshRenderer _meshRenderer;

    private bool _painted;

    public void Interact(IPlayer player)
    {
        if (!_painted)
        {
            if (player.Item is Brush brush)
            {
                if (brush.Painted)
                {
                    Paint(brush.CurrentColor);
                    player.ConsumeItem();
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
            LevelController.Instance.Win();
        }
        else
        {
            player.Kill();
        }
    }
}
