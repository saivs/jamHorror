using System;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField]
    private Transform _optionalHoldPivot;

    private Rigidbody _rigidbody;
    private Collider[] _colliders;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _colliders = GetComponentsInChildren<Collider>();
    }

    public virtual void Interact()
    {
        Player.Instance.ItemHolder.PickupItem(this);
    }

    public virtual void OnPickup()
    {
        _rigidbody.isKinematic = true;
        foreach(Collider col in _colliders)
        {
            col.enabled = false;
        }
    }

    public virtual void OnDrop(Vector3 dropForce)
    {
        _rigidbody.isKinematic = false;
        foreach (Collider col in _colliders)
        {
            col.enabled = true;
        }

        _rigidbody.AddForce(dropForce, ForceMode.Impulse);
    }
}
