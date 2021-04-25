using UnityEngine;

public class GroundyMovingState : GroundyBaseState {
    float distanceToCheckGround = 0.2f;
    float distanceToCheckObstacle = 0.2f;

    public override void EnterState(Groundy groundy) {
        groundy.animator.Play("Walking");
    }

    public override void Update(Groundy groundy) {
        if (CheckTransitionToMoving(groundy)) return;
        base.MoveAction(groundy);
    }

    bool ThereIsGroundToWalk(Groundy groundy) {
        RaycastHit2D[] groundRay = Physics2D.RaycastAll(groundy.groundTransform.position, Vector2.down, distanceToCheckGround);

        foreach (var obj in groundRay) {
            if (obj.collider != null && obj.collider.CompareTag("Ground")) {
                return true;
            }
        }
        return false;
    }

    bool ReachedObstacle(Groundy groundy) {
        Vector2 direction = CalculateDirection(groundy);
        RaycastHit2D[] frontRay = Physics2D.RaycastAll(groundy.frontTransform.position, direction, distanceToCheckObstacle);

        foreach (var obj in frontRay) {
            if (obj.collider != null) {
                bool isWall = obj.collider.CompareTag("Ground");

                bool hasHitObstacle = isWall;
                if (hasHitObstacle) {
                    return true;
                }
            }
        }

        return false;
    }

    public override bool CheckTransitionToMoving(Groundy groundy) {
        if (!ThereIsGroundToWalk(groundy) || ReachedObstacle(groundy)) {
            groundy.needToTurn = true;
            base.CheckTransitionToMoving(groundy);
            return true;
        }

        return false;
    }
}