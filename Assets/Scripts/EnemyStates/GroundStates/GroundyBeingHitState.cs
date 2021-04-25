using System.Collections;
using UnityEngine;

public class GroundyBeingHitState : GroundyBaseState {
    float hitTimer = 0.1f;

    public override void EnterState(Groundy groundy) {
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
    }

    void BeingHitAction(Groundy groundy) {
        groundy.rb.velocity = Vector2.zero;
        groundy.spriteRenderer.color = new Color(1, 0, 0, 1);
    }
}