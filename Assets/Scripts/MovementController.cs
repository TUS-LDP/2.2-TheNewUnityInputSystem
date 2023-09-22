using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    public CharacterController _controller;

    [SerializeField]
    public float moveSpeed;

    [SerializeField]
    private InputsManager _inputManager;

    // Start is called before the first frame update
    void Start()
    {
        if (_controller == null)
        {
            _controller = GetComponent<CharacterController>();
        }
        
        if (_inputManager == null)
        {
            _inputManager = GetComponent<InputsManager>();
        }


    }

    // Update is called once per frame
    void Update()
    {
        // normalise input direction
        Vector3 inputDirection = new Vector3(_inputManager.movementDirection.x, 0.0f, _inputManager.movementDirection.y).normalized;

        // note: Vector2's != operator uses approximation so is not floating point error prone, and is cheaper than magnitude
        // if there is a move input rotate player when the player is moving
        if (_inputManager.movementDirection != Vector2.zero)
        {
            // move
            inputDirection = transform.right * _inputManager.movementDirection.x + transform.forward * _inputManager.movementDirection.y;
        }

        // move the player
        _controller.Move(inputDirection.normalized * (_speed * Time.deltaTime) + new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);

        _controller.Move()
    }
}
