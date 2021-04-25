using UnityEngine;

public class GroundyDyingState : GroundyBaseState {
    public override void EnterState(Groundy groundy) {
        Manager.audio.Play("enemy_dying");
        Enemy.DieAction(groundy.gameObject);
    }

    public override void Update(Groundy groundy) {
    }
}