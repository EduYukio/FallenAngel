using UnityEngine;

public class PlayerStompingState : PlayerBaseState {
    public override void EnterState(Player player) {
        Setup(player);
        JumpAction(player);
    }

    public override void Update(Player player) {
        base.ProcessMovementInput(player);

        if (base.CheckTransitionToShooting(player)) return;
        if (base.CheckTransitionToGrounded(player)) return;
        if (base.CheckTransitionToFalling(player)) return;
    }

    void Setup(Player player) {
    }

    void JumpAction(Player player) {
        player.rb.velocity = new Vector2(player.rb.velocity.x, player.stompForce);
    }
}
