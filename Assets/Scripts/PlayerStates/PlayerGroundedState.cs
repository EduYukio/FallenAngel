using UnityEngine;

public class PlayerGroundedState : PlayerBaseState {
    public override void EnterState(Player player) {
        Setup(player);
        GroundedAction(player);
    }

    public override void Update(Player player) {
        // if (base.CheckTransitionToFalling(player)) return;
        // if (base.CheckTransitionToJumping(player)) return;
        if (base.CheckTransitionToWalking(player)) return;
    }

    void Setup(Player player) {
    }

    void GroundedAction(Player player) {
        player.rb.velocity = Vector2.zero;
    }
}
