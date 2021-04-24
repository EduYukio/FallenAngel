using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float maxHP = 3f;
    public float hp = 3f;

    [HideInInspector] public Animator animator;
    [HideInInspector] public Rigidbody2D rb;

    private void OnCollisionStay2D(Collision2D other) {
        GameObject otherObj = other.gameObject;
        if (otherObj.CompareTag("Player")) {
            Player player = otherObj.GetComponent<Player>();
            if (player.isInvulnerable) return;

            if (player.hp > 0) player.TakeDamage();
        }
    }

    public static void DieAction(GameObject enemy) {
        //animação de death?
        Destroy(enemy);
    }
}
