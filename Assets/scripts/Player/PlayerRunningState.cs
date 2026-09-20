using UnityEngine;

public class PlayerRunningState : PlayerState
{
    public PlayerRunningState(PlayerStateMachine stateMachine, PlayerMovement player)
        : base(stateMachine, player)
    {
    }

    public override void Enter()
    {
        Debug.Log("Player State: RUNNING");
    }

    public override void Update()
    {
        CharacterController controller = player.GetComponent<CharacterController>();

        if (!controller.isGrounded)
        {
            stateMachine.ChangeState(new PlayerJumpingState(stateMachine, player));
            return;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) < 0.1f && Mathf.Abs(vertical) < 0.1f)
        {
            stateMachine.ChangeState(new PlayerIdleState(stateMachine, player));
        }
    }
}