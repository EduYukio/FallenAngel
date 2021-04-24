using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Animator animator;
    [HideInInspector] public SpriteRenderer spriteRenderer;

    [HideInInspector] public PlayerBaseState currentState;

    public readonly PlayerGroundedState GroundedState = new PlayerGroundedState();
    public readonly PlayerWalkingState WalkingState = new PlayerWalkingState();
    public readonly PlayerJumpingState JumpingState = new PlayerJumpingState();
    public readonly PlayerFallingState FallingState = new PlayerFallingState();
    public readonly PlayerDyingState DyingState = new PlayerDyingState();

    public bool printDebugStates = false;
    public string debugState;

    public bool isGrounded;
    public float moveSpeed = 10f;
    public float maxFallSpeed = 14f;
    public float fallMultiplier = 10f;
    public float lowJumpMultiplier = 10f;
    public float jumpForce = 10f;
    [HideInInspector] public int lastDirection = 1;

    [HideInInspector] public float coyoteTimer;
    public float startCoyoteDurationTime = 0.1f;
    public float invulnerableTime = 1.5f;

    public bool isInvulnerable = false;

    public int maxHP = 5;
    public int hp = 5;

    public GameObject cameraHolder;


    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        TransitionToState(GroundedState);
    }

    void Update() {
        float step = Time.deltaTime;
        if (coyoteTimer >= 0) coyoteTimer -= step;

        UpdateFacingSprite();
        currentState.Update(this);

        if (isInvulnerable) {
            Blink();
        }
    }

    public void TransitionToState(PlayerBaseState state) {
        currentState = state;
        currentState.EnterState(this);

        if (printDebugStates) {
            debugState = currentState.GetType().Name;
            Debug.Log(debugState);
        }
    }

    private void UpdateFacingSprite() {
        if (lastDirection == 1) {
            spriteRenderer.flipX = false;
        }
        else if (lastDirection == -1) {
            spriteRenderer.flipX = true;
        }
    }

    public void TakeDamage() {
        hp--;


        if (hp <= 0) {
            TransitionToState(DyingState);
            return;
        }

        ActivateInvulnerability();
    }

    public void ActivateInvulnerability() {
        StartCoroutine(nameof(InvulnerableTimer), invulnerableTime);
    }

    public void Blink() {
        float step = 0.025f;
        float playerAlpha = spriteRenderer.color.a;
        if (playerAlpha > 0.2f) {
            spriteRenderer.color = new Color(1, 1, 1, playerAlpha - step);
        }
        else {
            spriteRenderer.color = Color.white;
        }
    }

    IEnumerator InvulnerableTimer(float waitTime) {
        isInvulnerable = true;
        yield return new WaitForSeconds(waitTime);
        isInvulnerable = false;
        spriteRenderer.color = Color.white;
    }
}
