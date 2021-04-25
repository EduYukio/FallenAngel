using UnityEngine;

public class Spike : MonoBehaviour {
    private void OnTriggerStay2D(Collider2D other) {
        GameObject otherObj = other.gameObject;
        if (otherObj.CompareTag("Player")) {
            Player player = otherObj.GetComponent<Player>();
            if (player.isInvulnerable) return;

            if (player.hp > 0) player.TakeDamage();
        }
    }
}