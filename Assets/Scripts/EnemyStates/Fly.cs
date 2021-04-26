using UnityEngine;

public class Fly : Enemy {
    private FlyBaseState currentState;

    public readonly FlyBeingHitState BeingHitState = new FlyBeingHitState();
    public readonly FlyDyingState DyingState = new FlyDyingState();
    public readonly FlyMovingState MovingState = new FlyMovingState();

    public float moveSpeed = 2f;
    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public Player player;

    public ParticleSystem dieParticles;

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
        BlinkRedIfNeeded();
    }

    public void TransitionToState(FlyBaseState state) {
        currentState = state;
        currentState.EnterState(this);
    }

    public void TakeDamage() {
        hp--;
        TransitionToState(BeingHitState);
    }

    public void BlinkRedIfNeeded() {
        float step = 0.1f;
        float otherColors = spriteRenderer.color.g;
        if (otherColors < 1) {
            spriteRenderer.color = new Color(1, otherColors + step, otherColors + step, 1);
        }
    }
}