using UnityEngine;

public class GroundyDyingState : GroundyBaseState {
    public override void EnterState(Groundy groundy) {
        Enemy.DieAction(groundy.gameObject);
    }

    public override void Update(Groundy groundy) {
    }
}