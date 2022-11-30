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
    [SerializeField] private AudioSource _audioSource;

    private bool _painted;

    public bool Painted => _painted;

    private void Start()
    {
        SetPainted(false);
    }

    public void Paint()
    {
        SetPainted(true);
        _audioSource.PlayOneShot(SoundConfig.Instance.BrushPaint);

        StartCoroutine(ClearTimerCoroutine());
    }

    private void Clear()
    {
        SetPainted(false);
        _audioSource.PlayOneShot(SoundConfig.Instance.BrushClear);
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