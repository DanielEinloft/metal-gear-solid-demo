/// <summary>
/// A contract for a generic Finite State Machine State. Each State from a FSM should have an Enter, Update and Exit methods
/// </summary>
public interface IFSMState
{
    /// <summary>
    /// Name of the State.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Reference to the parent FSM
    /// </summary>
    IFiniteStateMachine parentFSM { get; }

    /// <summary>
    /// Executed once before the current state start executing
    /// </summary>
    void EnterState();

    /// <summary>
    /// When state is active, the Update will be executed in every cycle of the FSM. This Method holds the behaviour of the state
    /// </summary>
    void UpdateState();

    /// <summary>
    /// Used to finalize the execution of the state before the FSM switches the current state
    /// </summary>
    void ExitState();

    void CheckExitCondition();
}
