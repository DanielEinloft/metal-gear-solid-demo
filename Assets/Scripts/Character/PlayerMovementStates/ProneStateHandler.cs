using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProneStateHandler : BaseFSMState
{
    CharacterState characterState;

    public ProneStateHandler(string stateName, PlayerFSM parentFSM) : base(stateName, parentFSM)
    {
        characterState = parentFSM.characterState;
    }
    public override void EnterState()
    {
        characterState.UpdateMovementState(PlayerMovementState.PRONE);
        base.EnterState();
    }
}
