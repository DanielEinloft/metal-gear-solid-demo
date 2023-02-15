using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    CharacterController characterController;
    float movementSpeed = 10f;
    PlayerMovementState movementState;

    void Start()
    {
        movementState = PlayerMovementState.STAND;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 directionInput = InputHandler.GetArrowInput();
        characterController.Move(new Vector3(directionInput.x, 0, directionInput.y) * Time.deltaTime * movementSpeed);
    }

    void HandleMovementState()
    {

    }
}
