using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputsManager : MonoBehaviour
{
    public Vector2 movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMove(InputValue input)
    {
        this.movementDirection = input.Get<Vector2>();
        Debug.Log("Moving vector: " + movementDirection.ToString()); ;
    }
}
