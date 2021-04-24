using UnityEngine;

public class FlyBeingHitState : FlyBaseState {
    float hitTimer;

    public override void EnterState(Fly fly) {
        // fly.animator.Play("BeingHit", -1, 0f);
        // Manager.audio.Play("EnemyHit");
        Setup(fly);
        BeingHitAction(fly);
    }

    public override void Update(Fly fly) {
        if (base.CheckTransitionToDying(fly)) return;

        if (hitTimer >= 0) {
            hitTimer -= Time.deltaTime;
            return;
        }

        if (base.CheckTransitionToMoving(fly)) return;
    }

    void Setup(Fly fly) {
        hitTimer = 0.3f;
        // hitTimer = Helper.GetAnimationDuration("BeingHit", fly.animator);
    }

    void BeingHitAction(Fly fly) {
        fly.rb.velocity = Vector2.zero;
    }
}