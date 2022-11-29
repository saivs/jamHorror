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

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 horizontalDirection = new Vector3(moveInput.x, 0, moveInput.y).normalized * _moveSpeed;
        Vector3 verticalDiraction = new Vector3(0, -_stickToGroundForce, 0);

        Vector3 moveVector = _horizontalLook.rotation * (horizontalDirection + verticalDiraction);

        _characterController.Move(moveVector * Time.deltaTime);

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
                SoundConfig.Instance.PlayerWalk.PlayAtPoint(transform);
            }
        }
        else
        {
            _walkSoundTimer = 0f;
        }
    }
}
