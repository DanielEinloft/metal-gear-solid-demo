using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerMovementState
{
    STAND,
    CROUCH,
    PRONE
}

public class PlayerMovementStateHandler
{
    public IFSMState CurrentState { get; protected set; }
    private IFiniteStateMachine fsm;
    private Dictionary<PlayerMovementState, IFSMState> states;

    public PlayerMovementStateHandler()
    {
        fsm = new PlayerFSM("Player Movement FSM");
        this.InitializeFSM();
    }

    private void InitializeFSM()
    {
        states.Add(PlayerMovementState.STAND, new StandStateHandler("Standing", fsm));
        states.Add(PlayerMovementState.CROUCH, new CrouchStateHandler("Crouching", fsm));
        states.Add(PlayerMovementState.PRONE, new ProneStateHandler("Proning", fsm));

        fsm.StartFSM();
        this.CurrentState = fsm.CurrentState;
    }

    public void UpdateFSM()
    {
        fsm.UpdateFSM();
        this.CurrentState = fsm.CurrentState;
    }
}
