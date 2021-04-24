using UnityEngine;

public abstract class FlyBaseState {
    public abstract void EnterState(Fly fly);
    public abstract void Update(Fly fly);

    public virtual bool CheckTransitionToDying(Fly fly) {
        if (fly.hp <= 0) {
            fly.TransitionToState(fly.DyingState);
            return true;
        }

        return false;
    }

    public virtual bool CheckTransitionToMoving(Fly fly) {
        fly.TransitionToState(fly.MovingState);
        return true;
    }

    public void MoveAction(Fly fly) {
        Vector2 direction = fly.player.transform.position - fly.transform.position;
        fly.transform.Translate(direction * fly.moveSpeed * Time.deltaTime);
    }
}