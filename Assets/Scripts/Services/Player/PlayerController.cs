using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;

    [SerializeField]
    private float _moveSpeed = 1.5f;
    [SerializeField]
    private float _stickToGroundForce = 10f;
    [SerializeField]
    private Transform _horizontalLook;

    private float _walkSoundTimer;
    private Vector2 _moveInput;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Update()
    {
        if (MouseLookLock.IsLocked)
        {
            return;
        }

        _moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public void FixedUpdate()
    {
        if (MouseLookLock.IsLocked)
        {
            return;
        }

        Vector3 horizontalDirection = new Vector3(_moveInput.x, 0, _moveInput.y).normalized * _moveSpeed;
        Vector3 verticalDiraction = new Vector3(0, -_stickToGroundForce, 0);

        Vector3 moveVector = _horizontalLook.rotation * (horizontalDirection + verticalDiraction);

        _characterController.Move(moveVector * Time.fixedDeltaTime);

        TryPlayWalkSound(_characterController.velocity.magnitude > 0.1f);
    }

    private void TryPlayWalkSound(bool moved)
    {
        if (moved)
        {
            _walkSoundTimer += Time.deltaTime;
            if (_walkSoundTimer > SoundConfig.Instance.WalkSoundInterval)
            {
                _walkSoundTimer = 0f;
                SoundConfig.Instance.PlayerWalk.PlayOneShotAtPoint(transform);
            }
        }
        else
        {
            _walkSoundTimer = 0f;
        }
    }
}
