using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [HideInInspector] public PlayerBaseState currentState;

    public readonly PlayerGroundedState GroundedState = new PlayerGroundedState();
    public readonly PlayerWalkingState WalkingState = new PlayerWalkingState();
    public readonly PlayerJumpingState JumpingState = new PlayerJumpingState();
    public readonly PlayerFallingState FallingState = new PlayerFallingState();

    public bool printDebugStates = false;
    public string debugState;

    public bool isGrounded;
    public float moveSpeed = 10f;
    public float maxFallSpeed = 14f;
    public float fallMultiplier = 10f;
    public float lowJumpMultiplier = 10f;
    public float jumpForce = 10f;
    // [HideInInspector] public int lastDirection = 1;


    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Animator animator;
    [HideInInspector] public SpriteRenderer spriteRenderer;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        TransitionToState(GroundedState);
    }


    void Update() {
        currentState.Update(this);

    }

    public void TransitionToState(PlayerBaseState state) {
        currentState = state;
        currentState.EnterState(this);

        if (printDebugStates) {
            debugState = currentState.GetType().Name;
            Debug.Log(debugState);
        }
    }
}
