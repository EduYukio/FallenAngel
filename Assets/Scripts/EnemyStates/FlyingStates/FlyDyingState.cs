using UnityEngine;

public class FlyDyingState : FlyBaseState {
    public override void EnterState(Fly fly) {
        Enemy.DieAction(fly.gameObject);
    }

    public override void Update(Fly fly) {
    }
}