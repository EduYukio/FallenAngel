using UnityEngine;

public class Fly : Enemy {
    private FlyBaseState currentState;

    public readonly FlyBeingHitState BeingHitState = new FlyBeingHitState();
    public readonly FlyDyingState DyingState = new FlyDyingState();
    public readonly FlyMovingState MovingState = new FlyMovingState();

    public float moveSpeed = 3f;
    // public float playerRayDistance = 5f;
    public Transform groundTransform;
    public Transform frontTransform;
    public Transform moreFrontTransform;
    public bool needToTurn = false;
    [HideInInspector] public SpriteRenderer spriteRenderer;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        hp = maxHP;
        TransitionToState(MovingState);
    }

    private void Update() {
        currentState.Update(this);
    }

    public void TransitionToState(FlyBaseState state) {
        currentState = state;
        currentState.EnterState(this);
    }

    public void TakeDamage() {
        hp--;
        TransitionToState(BeingHitState);
    }
}