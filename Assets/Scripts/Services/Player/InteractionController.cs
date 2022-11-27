using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField]
    private Transform _spherecastSource;
    [SerializeField]
    private float _sphereRadius = 0.5f;
    [SerializeField]
    private float _interactionDistance = 3f;
    [SerializeField]
    private LayerMask _interactionLayer;
    [SerializeField]
    private float _interactionCooldown = 0.5f;

    private Transform _currentHitObject;
    private double _nextTimeToInteract = 0;

    private void FixedUpdate()
    {
        if (Physics.SphereCast(_spherecastSource.position, _sphereRadius, _spherecastSource.forward, out RaycastHit hit, _interactionDistance, _interactionLayer))
        {
            _currentHitObject = hit.transform;
        }
        else
        {
            _currentHitObject = null;
        }
    }

    private void Update()
    {
        if (_currentHitObject == null)
            return;

        if (Input.GetKeyDown(KeyCode.F) && Time.timeAsDouble >= _nextTimeToInteract)
        {
            if (TryGetComponentInParent<IInteractable>(_currentHitObject, out IInteractable interactable))
            {
                interactable.Interact();
            }

            _nextTimeToInteract = Time.timeAsDouble + _interactionCooldown;
        }
    }

    private bool TryGetComponentInParent<T>(Transform target, out T component)
    {
        component = target.GetComponentInParent<T>();

        return component != null;
    }
}
