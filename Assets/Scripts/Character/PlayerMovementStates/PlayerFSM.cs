using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : BaseFiniteStateMachine
{
    public CharacterState characterState { get; protected set; }

    public PlayerFSM(string FSMName, CharacterState characterState) : base(FSMName) 
    {
        this.characterState = characterState;
        InitializeStates();
    }

    public override void InitializeStates()
    {
        base.InitializeStates();
        states.Add((int)PlayerMovementState.STAND, new StandStateHandler("Standing", this));
        states.Add((int)PlayerMovementState.CROUCH, new CrouchStateHandler("Crouching", this));
        states.Add((int)PlayerMovementState.PRONE, new ProneStateHandler("Proning", this));
    }
}
