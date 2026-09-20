using UnityEngine;

public abstract class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected PlayerMovement player;

    public PlayerState(PlayerStateMachine stateMachine, PlayerMovement player)
    {
        this.stateMachine = stateMachine;
        this.player = player;
    }

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void Update()
    {
    }
}
