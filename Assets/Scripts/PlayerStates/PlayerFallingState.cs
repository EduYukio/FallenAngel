using System.Collections;
using UnityEngine;

public class PlayerFallingState : PlayerBaseState {
    public override void EnterState(Player player) {
    }

    public override void Update(Player player) {
        BetterFalling(player);
        base.ProcessMovementInput(player);

        if (CheckTransitionToGrounded(player)) return;
    }

    void BetterFalling(Player player) {
        if (player.rb.velocity.y < player.maxFallSpeed) {
            player.rb.velocity = new Vector2(player.rb.velocity.x, player.maxFallSpeed);
            return;
        }

        bool playerIsFalling = player.rb.velocity.y < 0;
        bool playerStoppedJumping = player.rb.velocity.y > 0 && !Input.GetButton("Jump");

        if (playerIsFalling) {
            player.rb.velocity += Vector2.up * Physics2D.gravity.y * (player.fallMultiplier - 1) * Time.deltaTime;
        }
        else if (playerStoppedJumping) {
            player.rb.velocity += Vector2.up * Physics2D.gravity.y * (player.lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    public override bool CheckTransitionToGrounded(Player player) {
        if (player.isGrounded) {
            player.TransitionToState(player.GroundedState);
            return true;
        }

        return false;
    }
}
