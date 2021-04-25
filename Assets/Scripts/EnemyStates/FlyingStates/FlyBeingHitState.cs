using UnityEngine;

public class FlyBeingHitState : FlyBaseState {
    float hitTimer = 0.1f;

    public override void EnterState(Fly fly) {
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
    }

    void BeingHitAction(Fly fly) {
        fly.rb.velocity = Vector2.zero;
        fly.spriteRenderer.color = new Color(1, 0, 0, 1);
    }
}