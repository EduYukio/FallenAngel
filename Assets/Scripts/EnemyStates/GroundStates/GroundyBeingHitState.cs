using UnityEngine;

public class GroundyBeingHitState : GroundyBaseState {
    float hitTimer;

    public override void EnterState(Groundy groundy) {
        // groundy.animator.Play("BeingHit", -1, 0f);
        // Manager.audio.Play("EnemyHit");
        Setup(groundy);
        BeingHitAction(groundy);
    }

    public override void Update(Groundy groundy) {
        if (base.CheckTransitionToDying(groundy)) return;

        if (hitTimer >= 0) {
            hitTimer -= Time.deltaTime;
            return;
        }

        if (base.CheckTransitionToMoving(groundy)) return;
    }

    void Setup(Groundy groundy) {
        hitTimer = 0.3f;
        // hitTimer = Helper.GetAnimationDuration("BeingHit", groundy.animator);
    }

    void BeingHitAction(Groundy groundy) {
        groundy.rb.velocity = Vector2.zero;
    }
}