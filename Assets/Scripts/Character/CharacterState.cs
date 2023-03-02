using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState
{
    public CharacterController PlayerCharacterController { get; protected set; }
    public PlayerMovementState MovementState { get; protected set; }
    public Transform PlayerTransform { get; protected set; }

    public CharacterState(CharacterController characterController, Transform playerTransform, PlayerMovementState movementState)
    {
        PlayerCharacterController = characterController;
        MovementState = movementState;
        PlayerTransform = playerTransform;
    }

    public void UpdateMovementState(PlayerMovementState movementState)
    {
        MovementState = movementState;
    }
}
