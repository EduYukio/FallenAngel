using UnityEngine;

public class FlyMovingState : FlyBaseState {
    public override void EnterState(Fly fly) {
        // fly.animator.Play("Moving");
    }

    public override void Update(Fly fly) {
        base.MoveAction(fly);
    }
}