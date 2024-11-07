using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float gravityForce;
    public float groundMinDistance;
    public LayerMask groundMask;
    private Rigidbody2D _rigidBody;
    private Transform _transform;
    private PlayerMovement playerMovement;
    private PlayerMovementInput _playerMovementInput;
    private PlayerRaycaster _playerRaycaster;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerMovementInput = new PlayerMovementInput();
        _transform = GetComponent<Transform>();
        _playerRaycaster = new PlayerRaycaster(ref _transform, ref groundMinDistance, ref groundMask);
        playerMovement = new PlayerMovement(ref _rigidBody, ref _playerMovementInput, ref _playerRaycaster,
            ref speed, ref jumpForce, ref gravityForce);
    }

    private void OnEnable()
    {
        playerMovement.Enable();
    }

    private void OnDisable()
    {
        playerMovement.Disable();
    }

    private void Update()
    {
        playerMovement.Move();
    }
}