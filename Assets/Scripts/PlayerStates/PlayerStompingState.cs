using UnityEngine;

public class PlayerStompingState : PlayerBaseState {
    public override void EnterState(Player player) {
        Setup(player);
        JumpAction(player);
    }

    public override void Update(Player player) {
        // if (player.rb.velocity.y > player.stompForce) player.rb.velocity = new Vector2(player.rb.velocity.x, player.stompForce);
        base.ProcessMovementInput(player);

        if (base.CheckTransitionToShooting(player)) return;
        if (base.CheckTransitionToGrounded(player)) return;
        if (CheckTransitionToFalling(player)) return;
    }

    void Setup(Player player) {
        player.isGrounded = false;
    }

    void JumpAction(Player player) {
        player.rb.velocity = new Vector2(player.rb.velocity.x, player.stompForce);
    }

    public override bool CheckTransitionToFalling(Player player) {
        if (player.isGrounded) return false;

        bool playerIsFalling = player.rb.velocity.y <= 0;

        if (playerIsFalling) {
            player.TransitionToState(player.FallingState);
            return true;
        }

        return false;
    }
}
