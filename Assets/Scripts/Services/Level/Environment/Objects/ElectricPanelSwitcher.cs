using System;
using UnityEngine;

public class ElectricPanelSwitcher : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform _button;

    private bool _pressed;

    public event Action OnPressed; 

    public void Interact()
    {
        if (_pressed)
        {
            return;
        }

        Press();
    }

    private void Press()
    {
        _pressed = true;

        var rotation = _button.localEulerAngles;
        rotation.z = 140f;
        _button.localEulerAngles = rotation;

        SoundConfig.Instance.ElectricPanelPressButton.PlayOneShotAtPoint(transform);

        OnPressed?.Invoke();
    }
}
