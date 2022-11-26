using System.Collections;
using UnityEngine;

public class Brush: Item, IPickable
{
    [SerializeField] private BrushConfig _config;
    [SerializeField] private MeshRenderer _colorRenderer;

    private Color _clearColor;

    private bool _painted;
    private Color _currentColor;

    public bool Painted => _painted;
    public Color CurrentColor => _currentColor;

    private void Awake()
    {
        _clearColor = _colorRenderer.material.color;
    }

    public void Paint(Color color)
    {
        SetPainted(true, color);
        StartCoroutine(ClearTimerCoroutine());
    }

    private void Clear()
    {
        SetPainted(false, _clearColor);
    }

    private IEnumerator ClearTimerCoroutine()
    {
        yield return new WaitForSeconds(_config.ClearTimer);
        Clear();
    }

    private void SetPainted(bool painted, Color color)
    {
        _painted = painted;
        _currentColor = color;
        _colorRenderer.material.color = color;
    }
}
