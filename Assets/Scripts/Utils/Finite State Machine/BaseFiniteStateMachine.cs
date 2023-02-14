using System.Collections.Generic;

/// <summary>
/// Basic implementation of a Finite State Machine
/// </summary>
public abstract class BaseFiniteStateMachine: IFiniteStateMachine
{
    public string Name { get; protected set; }
    public IFSMState CurrentState { get; protected set; }

    /// <summary>
    /// Indicates if the FSM is active or not
    /// </summary>
    protected bool active;
    /// <summary>
    /// Dictionary with a list of all states for the FSM
    /// </summary>
    protected Dictionary<int, BaseFSMState> states;

    public BaseFiniteStateMachine(string FSMName)
    {
        Name = FSMName;
        active = false;
    }

    ~BaseFiniteStateMachine()
    {
        states.Clear();
    }

    public virtual void InitializeStates() {
        CurrentState = null;
        states = new Dictionary<int, BaseFSMState>();
    }

    public virtual void UpdateFSM()
    {
        if (active && CurrentState != null)
        {
            CurrentState.UpdateState();
        }
    }

    public void StartFSM()
    {
        if (!active && CurrentState == null && states.Count > 0)
        {
            CurrentState = states[0];
            CurrentState.EnterState();
            active = true;
        } 
    }

    public virtual void StopFSM()
    {
        CurrentState = null;
        active = false;
    }

    public virtual void ChangeState(int nextStateIndex)
    {
        if (nextStateIndex != -1)
        {
            BaseFSMState nextState = states[nextStateIndex];
            CurrentState.ExitState();

            CurrentState = nextState;
            nextState.EnterState();
        }
        else StopFSM();
    }
}
