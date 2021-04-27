using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompTrigger : MonoBehaviour {
    Player player;

    private void Start() {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameObject otherObj = other.gameObject;
        if (otherObj.CompareTag("PlayerStompCollider")) {
            Player player = otherObj.transform.parent.gameObject.GetComponent<Player>();
            string playerState = player.GetStateName();

            // bool playerIsFalling = playerState == "PlayerFallingState" && player.rb.velocity.y < 0f;
            // bool playerIsShooting = playerState == "PlayerShootingState";

            if (player.rb.velocity.y <= 0.05f) {
                Stomp();
            }
        }
    }

    public void Stomp() {
        if (transform.parent.gameObject.name.Contains("Evil")) {
            if (!player.isInvulnerable) {
                player.TakeDamage();
                player.TransitionToState(player.StompingState);
            }
            return;
        }
        player.TransitionToState(player.StompingState);
        player.ammunition = player.maxAmmunition;
        player.UpdateAmmoUI();
        Manager.audio.Play("stomp");
        Manager.shaker.Shake(player.cameraObj, player.stompShakeDuration, player.stompShakeMagnitude);
        player.stompParticles.Play();
        Destroy(gameObject.transform.parent.gameObject);
    }
}
