using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float maxHP = 3f;
    public float hp = 3f;

    private void OnCollisionEnter2D(Collision2D other) {
        GameObject otherObj = other.gameObject;
        if (otherObj.CompareTag("Player")) {
            Player player = otherObj.GetComponent<Player>();
            if (player.isInvulnerable) return;

            if (player.hp > 0) player.TakeDamage();
        }
    }

    public void TakeDamage() {
        hp--;

        if (hp <= 0) {
            Die();
            return;
        }
    }

    public void Die() {
        //animação de death?
        Destroy(gameObject);
    }
}
