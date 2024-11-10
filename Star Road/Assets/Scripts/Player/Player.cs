using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float gravityForce;
    public float groundMinDistance;
    public LayerMask groundMask;
    public Transform cameraTarget;
    private Rigidbody2D _rigidBody;
    private CameraController _cameraController;
    private OrientationController _orientationController;
    private PlayerMovement _playerMovement;
    private PlayerMovementInput _playerMovementInput;
    private PlayerRaycaster _playerRaycaster;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        cameraTarget = GetComponent<Transform>();
        _playerMovementInput = new PlayerMovementInput();
        _orientationController = new OrientationController(ref _playerMovementInput);
        _cameraController = new CameraController(ref cameraTarget,ref _playerMovementInput, ref _orientationController);
        _playerRaycaster = new PlayerRaycaster(ref cameraTarget, ref groundMinDistance, ref groundMask);
        _playerMovement = new PlayerMovement(ref _rigidBody, ref _playerMovementInput, ref _playerRaycaster,
            ref speed, ref jumpForce, ref gravityForce, ref _orientationController);
    }

    private void OnEnable()
    {
        _playerMovement.Enable();
        _orientationController.Enable();
        _cameraController.Enable();
    }

    private void OnDisable()
    {
        _playerMovement.Disable();
        _orientationController.Disable();
        _cameraController.Disable();
    }

    private void Update()
    {
        _playerMovement.Move();
    }
}