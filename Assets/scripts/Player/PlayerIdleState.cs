using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(PlayerStateMachine stateMachine, PlayerMovement player)
        : base(stateMachine, player)
    {
    }

    public override void Enter()
    {
        Debug.Log("Player State: IDLE");
    }

    public override void Update()
    {
        if (!player.GetComponent<CharacterController>().isGrounded)
        {
            stateMachine.ChangeState(new PlayerJumpingState(stateMachine, player));
            return;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
        {
            stateMachine.ChangeState(new PlayerRunningState(stateMachine, player));
        }
    }
}