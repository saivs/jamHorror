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

        _pressed = true;
        SwitchDown();
        OnPressed?.Invoke();
    }

    private void SwitchDown()
    {
        float angle = -_button.transform.localRotation.eulerAngles.z * 2;
        _button.RotateAround(_buttonRotatePivot.position, Vector3.forward, angle);
    }
}
