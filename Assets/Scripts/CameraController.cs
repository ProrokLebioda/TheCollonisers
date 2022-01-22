using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static TheCollonisersActions;

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform;

    public float movementSpeed = 2.0f;
    public float movementTime= 2.0f;
    public Vector3 zoomAmount;



    private Vector2 _movementValue;
    private Vector3 _cameraZoom;
    
    private TheCollonisersActions _playerActions;
    private InputAction _movement;
    private InputAction _zoom;

    private void Awake()
    {
        _cameraZoom = cameraTransform.localPosition;
        _playerActions = new TheCollonisersActions();
    }

    private void OnEnable()
    {
        _movement = _playerActions.Player.Move;
        _movement.Enable();

        _zoom = _playerActions.Player.Zoom;
        _zoom.Enable();

        _playerActions.Player.Zoom.performed += HandleZoom;
        _playerActions.Player.Zoom.Enable();
    }

    private void HandleZoom(InputAction.CallbackContext obj)
    {
        // why not normalized? wtf, doesn't work
        var zoom = obj.ReadValue<float>();

        zoom = zoom < 0 ? -1 : zoom == 0 ? 0 : 1;
        _cameraZoom += zoomAmount*zoom;
        Debug.Log("Zoom = " + _cameraZoom);

        // This is weird
        //cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, _cameraZoom, Time.deltaTime /** movementTime*/);
        cameraTransform.localPosition = _cameraZoom;
    }

    private void OnDisable()
    {
        _movement.Disable();
        _zoom.Disable();
        _playerActions.Player.Zoom.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();

    }  

    void HandleMovement()
    {
        _movementValue = _movement.ReadValue<Vector2>();
        Vector3 movement = new Vector3(_movementValue.x, 0, _movementValue.y);
        Vector3 newPosition = transform.position + (movement * movementSpeed);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
    }
}
