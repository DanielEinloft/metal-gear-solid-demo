/// <summary>
/// A contract for a generic Finite State Machine.
/// </summary>
public interface IFiniteStateMachine
{
    /// <summary>
    /// FSM name
    /// </summary>
    string Name { get; }

    /// <summary>
    /// The current active state
    /// </summary>
    IFSMState CurrentState { get; }

    /// <summary>
    /// Initialize the FSM states
    /// </summary>
    void InitializeStates();

    /// <summary>
    /// Executed once when starting the FSM. Sets up all the initial data
    /// </summary>
    void StartFSM();

    /// <summary>
    /// Execute the current state
    /// </summary>
    void UpdateFSM();

    /// <summary>
    /// Called by the state to exit the current state and start the next
    /// </summary>
    /// <param name="nextStateIndex">Indicates the index of the next state so the FSM knows what the correct state to transition</param>
    void ChangeState(int nextStateIndex);
}
