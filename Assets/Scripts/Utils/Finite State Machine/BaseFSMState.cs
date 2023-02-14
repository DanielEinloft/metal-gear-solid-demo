/// <summary>
/// Basic implementation of a FSM State
/// </summary>
public abstract class BaseFSMState: IFSMState
{
    /// <summary>
    /// Indicates if the state is active
    /// </summary>
    protected bool active;
    public string Name { get; protected set; }

    /// <summary>
    /// Reference to the parent FSM
    /// </summary>
    public IFiniteStateMachine parentFSM { get; protected set; }

    public BaseFSMState(string stateName, IFiniteStateMachine parentFSM)
    {
        Name = stateName;
        this.parentFSM = parentFSM;
        active = false;
    }

    public virtual void EnterState() {
        active = true;
    }
    public virtual void UpdateState() { }
    public virtual void ExitState() {
        active = false;
    }

    public virtual void CheckExitCondition() { }
}
