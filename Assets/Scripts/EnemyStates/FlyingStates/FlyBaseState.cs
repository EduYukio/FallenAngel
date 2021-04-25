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
        if (!fly.spriteRenderer.isVisible) return;

        Vector3 targetPosition = fly.player.transform.position + new Vector3(0f, -0.8f, 0f);
        Vector3 coords = targetPosition - fly.transform.position;
        Vector2 direction = (new Vector2(coords.x, coords.y)).normalized;
        fly.transform.Translate(direction * fly.moveSpeed * Time.deltaTime);
    }
}