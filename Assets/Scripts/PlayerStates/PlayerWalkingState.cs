using UnityEngine;

public class PlayerWalkingState : PlayerBaseState {
    public override void EnterState(Player player) {
        Setup(player);
    }

    public override void Update(Player player) {
        base.ProcessMovementInput(player);
        PlayAnimationIfCan(player);
        ResetCoyoteTimer(player);

        if (base.CheckTransitionToShooting(player)) return;
        if (CheckTransitionToGrounded(player)) return;
        if (base.CheckTransitionToFalling(player)) return;
        if (base.CheckTransitionToJumping(player)) return;
    }

    void Setup(Player player) {
    }

    public override bool CheckTransitionToGrounded(Player player) {
        if (!player.isGrounded) return false;

        float xInput = Input.GetAxisRaw("Horizontal");
        if (xInput == 0) {
            player.TransitionToState(player.GroundedState);
            return true;
        }
        return false;
    }

    void ResetCoyoteTimer(Player player) {
        player.coyoteTimer = player.startCoyoteDurationTime;
    }

    private void PlayAnimationIfCan(Player player) {
        if (Helper.IsPlayingAnimation("Walking", player.animator)) return;

        player.animator.Play("Walking");
    }
}
