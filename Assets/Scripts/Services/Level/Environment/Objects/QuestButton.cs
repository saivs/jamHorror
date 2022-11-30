using UnityEngine;

public class QuestButton : MonoBehaviour, IInteractable
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Material _colorMaterial;

    private bool _painted;

    public void Interact()
    {
        if (!_painted)
        {
            if (Player.Instance.Item is Brush brush)
            {
                if (brush.Painted)
                {
                    Paint();
                    Destroy(brush.gameObject);
                    return;
                }
            }
        }

        Press();
    }

    private void Paint()
    {
        _painted = true;
        _meshRenderer.material = _colorMaterial;
    }

    private void Press()
    {
        if (_painted)
        {
            SoundConfig.Instance.ButtonPressGood.PlayOneShotAtPoint(transform);
            LevelController.Instance.Win();
        }
        else
        {
            SoundConfig.Instance.ButtonPressBad.PlayOneShotAtPoint(transform);
            Player.Instance.Kill(DeathMessageConfig.Instance.TouchRedButton);
        }
    }
}
