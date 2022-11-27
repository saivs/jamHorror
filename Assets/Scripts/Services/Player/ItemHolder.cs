using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    [SerializeField]
    private Transform _itemHandlerPoint;
    [SerializeField]
    private float _pickupSpeed = 5f;
    [SerializeField]
    private float _dropForce = 20f;
    [SerializeField]
    private float _changeItemForce = 20f;

    private float _pickupProgress = 0;

    private Vector3 _itemStartPosition;
    private Quaternion _itemStartRotation;

    private Item _itemInArms;
    private float _currentDropForce;

    public Item Item => _itemInArms;

    public void PickupItem(Item item)
    {
        _currentDropForce = _changeItemForce;

        DropCurrentItem();

        _itemInArms = item;

        _itemStartPosition = item.transform.position;
        _itemStartRotation = item.transform.rotation;
        _pickupProgress = 0;

        item.OnPickup();

        SoundConfig.Instance.ItemPick.PlayAtPoint(transform);
    }

    public void DropCurrentItem()
    {
        if(_itemInArms != null)
        {
            _itemInArms.OnDrop(_itemHandlerPoint.forward *  Random.Range(_currentDropForce * 0.9f, _currentDropForce * 1.1f));
            _itemInArms = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            _currentDropForce = _dropForce;
            DropCurrentItem();

            SoundConfig.Instance.ItemDrop.PlayAtPoint(transform);
        }
    }

    private void LateUpdate()
    {
        if(_itemInArms != null)
        {
            _pickupProgress = Mathf.MoveTowards(_pickupProgress, 1f, Time.deltaTime * _pickupSpeed);

            _itemInArms.transform.position = Vector3.Lerp(_itemStartPosition, _itemHandlerPoint.position, _pickupProgress);
            _itemInArms.transform.rotation = Quaternion.Lerp(_itemStartRotation, _itemHandlerPoint.rotation, _pickupProgress);
        }
    }
}
