using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Groundy : Enemy {
    private GroundyBaseState currentState;

    public readonly GroundyBeingHitState BeingHitState = new GroundyBeingHitState();
    public readonly GroundyDyingState DyingState = new GroundyDyingState();
    public readonly GroundyMovingState MovingState = new GroundyMovingState();

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

    public void TransitionToState(GroundyBaseState state) {
        currentState = state;
        currentState.EnterState(this);
    }

    public void TakeDamage() {
        hp--;
        TransitionToState(BeingHitState);
    }
}