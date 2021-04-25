using UnityEngine;

public class FlyDyingState : FlyBaseState {
    public override void EnterState(Fly fly) {
        Manager.audio.Play("enemy_dying");
        Enemy.DieAction(fly.gameObject);
    }

    public override void Update(Fly fly) {
    }
}