using TMPro;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public Key KeyItemToUnlock;
    [SerializeField]
    private Collider _doorCollider;

    [SerializeField]
    private float _openSpeed = 2f;
    [SerializeField]
    private float _closeSpeed = 3f;
    [SerializeField]
    private Transform _pivotTransform;
    [SerializeField]
    private AnimationCurve _openProgressRemap = AnimationCurve.Linear(0, 0, 1, 1);
    [SerializeField]
    private AnimationCurve _closeProgressRemap = AnimationCurve.Linear(0, 0, 1, 1);
    [SerializeField]
    private Transform _closedPivotTarget;
    [SerializeField]
    private Transform _opendPivotTarget;

    

    private bool _isLocked;
    private bool _isOpend;
    private float _progress;

    private void Awake()
    {
        _isLocked = KeyItemToUnlock != null;
    }

    public void Interact()
    {
        if(_progress != 0f && _progress != 1f)
        {
            return;
        }

        if (!_isLocked)
        {
            Open();
        }
        else
        {
            if (Player.Instance.Item == KeyItemToUnlock)
            {
                Unlock();
                Open();
                return;
            }

            CantOpen();
        }
    }

    private void Open()
    {
        _isOpend = !_isOpend;
    }

    private void Unlock()
    {
        _isLocked = false;

        Destroy(KeyItemToUnlock.gameObject);
        SoundConfig.Instance.DoorOpen.PlayAtPoint(transform);
    }

    private void CantOpen()
    {
        SoundConfig.Instance.DoorCantOpen.PlayAtPoint(transform);
    }

    private void Update()
    {
        float lerpProgress;

        if (_isOpend)
        {
            _progress = Mathf.MoveTowards(_progress, 1f, Time.deltaTime * _openSpeed);
            lerpProgress = _openProgressRemap.Evaluate(_progress);
        }
        else
        {
            _progress = Mathf.MoveTowards(_progress, 0f, Time.deltaTime * _closeSpeed);
            lerpProgress = _closeProgressRemap.Evaluate(_progress);
        }

        _pivotTransform.rotation = Quaternion.LerpUnclamped(_closedPivotTarget.rotation, _opendPivotTarget.rotation, lerpProgress);

        _doorCollider.enabled = _progress == 0 || _progress == 1;
    }
}
