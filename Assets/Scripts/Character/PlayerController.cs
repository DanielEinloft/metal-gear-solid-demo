using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public enum PlayerMovementState
{
    STAND,
    CROUCH,
    PRONE
}

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;

    PlayerMovementState movementState;
    CharacterState characterState;
    private IFiniteStateMachine movementFSM;

    void Start()
    {
        movementState = PlayerMovementState.STAND;
        characterController = GetComponent<CharacterController>();
        characterState = new CharacterState(characterController, transform, movementState);

        movementFSM = new PlayerFSM("Player Movement FSM", characterState);
        movementFSM.StartFSM();
    }


    void Update()
    {
        movementFSM.UpdateFSM();
    }
}
