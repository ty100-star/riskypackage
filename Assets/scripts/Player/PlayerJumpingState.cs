using UnityEngine;

public class PlayerJumpingState : PlayerState
{
    public PlayerJumpingState(PlayerStateMachine stateMachine, PlayerMovement player)
        : base(stateMachine, player)
    {
    }

    public override void Enter()
    {
        Debug.Log("Player State: JUMPING");
    }

    public override void Update()
    {
        CharacterController controller = player.GetComponent<CharacterController>();

        if (controller.isGrounded)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
            {
                stateMachine.ChangeState(new PlayerRunningState(stateMachine, player));
            }
            else
            {
                stateMachine.ChangeState(new PlayerIdleState(stateMachine, player));
            }
        }
    }
}