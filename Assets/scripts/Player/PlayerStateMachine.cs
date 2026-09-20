using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState CurrentState { get; private set; }

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        if (playerMovement == null)
        {
            Debug.LogError("PlayerStateMachine requires a PlayerMovement component.");
            return;
        }

        CurrentState = new PlayerIdleState(this, playerMovement);
        CurrentState.Enter();
    }

    private void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }

    public void ChangeState(PlayerState newState)
    {
        if (newState == null)
            return;

        CurrentState?.Exit();

        CurrentState = newState;
        CurrentState.Enter();
    }
}