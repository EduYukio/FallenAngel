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
        bool flyIsVisible = fly.spriteRenderer.isVisible;
        float dist = Mathf.Abs(fly.transform.position.y - fly.player.transform.position.y);
        bool flyIsABitAbovePlayer = dist < 5.5f;
        if (!flyIsVisible && !flyIsABitAbovePlayer) return;

        Vector3 targetPosition = fly.player.transform.position + new Vector3(0f, -0.8f, 0f);
        Vector3 coords = targetPosition - fly.transform.position;
        Vector2 direction = (new Vector2(coords.x, coords.y)).normalized;
        fly.transform.Translate(direction * fly.moveSpeed * Time.deltaTime);
    }
}