using System.Collections;
using UnityEngine;

public class Brush : Item
{
    [SerializeField] private BrushConfig _config;
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Material _colorMaterialBrush;
    [SerializeField] private Material _colorMaterialHandle;
    [SerializeField] private Material _clearMaterialBrush;
    [SerializeField] private Material _clearMaterialHandle;

    private bool _painted;

    public bool Painted => _painted;

    private void Start()
    {
        SetPainted(false);
    }

    public void Paint()
    {
        SetPainted(true);
        SoundConfig.Instance.BrushPaint.PlayOneShotAtPoint(transform);

        StartCoroutine(ClearTimerCoroutine());
    }

    private void Clear()
    {
        SetPainted(false);
        SoundConfig.Instance.BrushClear.PlayOneShotAtPoint(transform);
    }

    private IEnumerator ClearTimerCoroutine()
    {
        yield return new WaitForSeconds(_config.ClearTimer);
        Clear();
    }

    private void SetPainted(bool painted)
    {
        _painted = painted;
        _renderer.materials = painted 
            ? new Material[] { _colorMaterialHandle, _colorMaterialBrush }
            : new Material[] { _clearMaterialHandle, _clearMaterialBrush };
    }
}