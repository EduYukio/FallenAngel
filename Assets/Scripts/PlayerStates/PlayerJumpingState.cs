using UnityEngine;

public class PlayerJumpingState : PlayerBaseState {
    bool leftGround;
    public override void EnterState(Player player) {
        Setup(player);
        JumpAction(player);
    }

    public override void Update(Player player) {
        base.ProcessMovementInput(player);
        CheckIfLeftGround(player);

        if (base.CheckTransitionToShooting(player)) return;
        if (CheckTransitionToGrounded(player)) return;
        if (base.CheckTransitionToFalling(player)) return;
    }

    void Setup(Player player) {
        player.coyoteTimer = 0;
        leftGround = false;
    }

    void JumpAction(Player player) {
        player.rb.velocity = new Vector2(player.rb.velocity.x, player.jumpForce);
    }

    void CheckIfLeftGround(Player player) {
        if (leftGround) return;

        if (!player.isGrounded) {
            leftGround = true;
        }
    }

    public override bool CheckTransitionToGrounded(Player player) {
        if (!leftGround) return false;
        return base.CheckTransitionToGrounded(player);
    }
}
