using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other) {
        GameObject otherObj = other.gameObject;
        if (otherObj.CompareTag("Player")) {
            Player player = otherObj.GetComponent<Player>();
            if (player.isInvulnerable) return;

            if (player.hp > 0) player.TakeDamage();
        }
    }
}
