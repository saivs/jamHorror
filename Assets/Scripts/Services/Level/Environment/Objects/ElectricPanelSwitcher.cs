using System;
using UnityEngine;

public class ElectricPanelSwitcher : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform _buttonRotatePivot;
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

        float angle = -_button.transform.localRotation.eulerAngles.z * 2;
        _button.RotateAround(_buttonRotatePivot.position, Vector3.forward, angle);

        AudioSource.PlayClipAtPoint(SoundConfig.Instance.ElectricPanelPressButton, transform.position);

        OnPressed?.Invoke();
    }
}
