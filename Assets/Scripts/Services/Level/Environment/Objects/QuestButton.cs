using UnityEngine;

public class QuestButton : MonoBehaviour, IInteractable
{
    [SerializeField] private MeshRenderer _meshRenderer;

    private bool _painted;

    public void Interact()
    {
        if (!_painted)
        {
            if (Player.Instance.Item is Brush brush)
            {
                if (brush.Painted)
                {
                    Paint(brush.CurrentColor);
                    Player.Instance.ConsumeItem();
                    return;
                }
            }
        }
        Press();
    }

    private void Paint(Color color)
    {
        _painted = true;
        _meshRenderer.material.color = color;
    }

    private void Press()
    {
        if (_painted)
        {
            LevelController.Instance.Win();
        }
        else
        {
            Player.Instance.Kill();
        }
    }
}
