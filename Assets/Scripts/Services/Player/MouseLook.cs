using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private Transform _verticalLook;
    [SerializeField]
    private Transform _horizontalLook;
    [SerializeField]
    private float _lookSpeed = 2f;
    [SerializeField]
    private float _minPitch = -70f;
    [SerializeField]
    private float _maxPitch = 70f;

    private float _pitch = 0;
    private float _yaw = 0;


    private void Update()
    {
        if (!MouseLookLock.IsLocked)
        {
            _yaw += Input.GetAxisRaw("Mouse X") * _lookSpeed;
            _pitch -= Input.GetAxisRaw("Mouse Y") * _lookSpeed;

            ClampVertical();
            ClampHorizontal360();

            _horizontalLook.localRotation = Quaternion.Euler(0, _yaw, 0);
            _verticalLook.localRotation = Quaternion.Euler(_pitch, 0, 0);
        }

        //Cursor.lockState = MouseLookLock.IsLocked ? CursorLockMode.None : CursorLockMode.Locked;
        //Cursor.visible = MouseLookLock.IsLocked;
    }


    private void ClampVertical()
    {
        _pitch = Mathf.Clamp(_pitch, _minPitch, _maxPitch);
    }
    private void ClampHorizontal360()
    {
        if (_yaw >= 360f)
        {
            _yaw -= 360f;
        }
        if(_yaw <= -360)
        {
            _yaw += 360f;
        }
    }
}
