using UnityEngine;

public abstract class GroundyBaseState {
    public abstract void EnterState(Groundy groundy);
    public abstract void Update(Groundy groundy);

    public virtual bool CheckTransitionToMoving(Groundy groundy) {
        InvertDirectionIfNeeded(groundy);

        groundy.TransitionToState(groundy.MovingState);
        return true;
    }

    public virtual bool CheckTransitionToDying(Groundy groundy) {
        if (groundy.hp <= 0) {
            groundy.TransitionToState(groundy.DyingState);
            return true;
        }

        return false;
    }

    public void MoveAction(Groundy groundy) {
        groundy.transform.Translate(Vector2.right * groundy.moveSpeed * Time.deltaTime);
    }

    public void InvertDirectionIfNeeded(Groundy groundy) {
        if (groundy.needToTurn) {
            if (groundy.transform.eulerAngles.y == 0) {
                groundy.transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
            else if (groundy.transform.eulerAngles.y == 180) {
                groundy.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
        }
        groundy.needToTurn = false;
    }

    public Vector2 CalculateDirection(Groundy groundy) {
        return (groundy.moreFrontTransform.position - groundy.frontTransform.position).normalized;
    }
}