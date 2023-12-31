using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float moveSpeed;
    [SerializeField] private InputsManager _inputManager;

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
        float verticalVelocity= 0f;

        // Create a variaable and set it to zeor
        Vector3 inputDirection = Vector3.zero;

        // note: Vector2's != operator uses approximation so is not floating point error prone, and is cheaper than magnitude
        // if there is a move input rotate player when the player is moving
        if (_inputManager.movementDirection != Vector2.zero)
        {
            // move
            // transform.right is (1,0,0) and transform.forward is (0,0,1)
            inputDirection = transform.right * _inputManager.movementDirection.x + transform.forward * _inputManager.movementDirection.y;
        }

        // move the player
        _controller.Move(inputDirection.normalized * (moveSpeed * Time.deltaTime) + new Vector3(0.0f, verticalVelocity, 0.0f) * Time.deltaTime);
    }
}
