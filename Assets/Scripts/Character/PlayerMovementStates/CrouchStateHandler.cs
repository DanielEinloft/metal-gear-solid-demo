using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchStateHandler : BaseFSMState
{
    CharacterState characterState;
    public CrouchStateHandler(string stateName, PlayerFSM parentFSM) : base(stateName, parentFSM)
    {
        characterState = parentFSM.characterState;
    }

    public override void EnterState()
    {
        characterState.UpdateMovementState(PlayerMovementState.CROUCH);
        base.EnterState();
    }

    public override void UpdateState()
    {
        Vector2 directionInput = InputHandler.GetArrowInput();
        characterState.PlayerCharacterController.Move(new Vector3(directionInput.x, 0, directionInput.y) * Time.deltaTime * 5);
        if (directionInput.sqrMagnitude > 0f)
        {
            characterState.PlayerTransform.rotation = Quaternion.LookRotation(new Vector3(directionInput.x, 0f, directionInput.y));
        }
        CheckExitCondition();
    }

    public override void CheckExitCondition()
    {
        if (InputHandler.ButtonPress(ControllerClickEvent.Crouch))
        {
            parentFSM.ChangeState((int)PlayerMovementState.STAND);
        }
    }
}
