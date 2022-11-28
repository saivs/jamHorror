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
                    Destroy(brush.gameObject);
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
            SoundConfig.Instance.ButtonPressGood.PlayAtPoint(transform);
            LevelController.Instance.Win();
        }
        else
        {
            SoundConfig.Instance.ButtonPressBad.PlayAtPoint(transform);
            Player.Instance.Kill();
        }
    }
}
