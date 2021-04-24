using UnityEngine;

public class Fly : Enemy {
    private FlyBaseState currentState;

    public readonly FlyBeingHitState BeingHitState = new FlyBeingHitState();
    public readonly FlyDyingState DyingState = new FlyDyingState();
    public readonly FlyMovingState MovingState = new FlyMovingState();

    public float moveSpeed = 2f;
    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public Player player;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        player = FindObjectOfType<Player>();

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