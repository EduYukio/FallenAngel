using UnityEngine;

public class FlyMovingState : FlyBaseState {
    public override void EnterState(Fly fly) {
        fly.animator.Play("Flying");
    }

    public override void Update(Fly fly) {
        base.MoveAction(fly);
    }
}