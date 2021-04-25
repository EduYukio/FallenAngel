using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDyingState : PlayerBaseState {
    public float dyingTimer;

    public override void EnterState(Player player) {
        Setup(player);
    }

    public override void Update(Player player) {
        if (dyingTimer > 0) {
            dyingTimer -= Time.deltaTime;
            return;
        }

        DieAction(player);
    }

    void Setup(Player player) {
        // player.dyingParticles.Play();
        player.isDying = true;
        // player.spriteRenderer.color = Color.white;

        dyingTimer = 0.5f;
        // player.animator.Play("PlayerHit");
        // Manager.audio.Play("PlayerDying");

        // Manager.shaker.Shake(player.cameraObj, player.config.dyingShakeDuration, player.config.dyingShakeMagnitude);
        // player.cameraHolder.transform.parent = null;

        float direction = -player.lastDirection;
        // player.rb.bodyType = RigidbodyType2D.Dynamic;
        player.rb.velocity = new Vector3(direction * 4f, 9f, 0);
        player.rb.constraints = RigidbodyConstraints2D.None;
        player.rb.angularVelocity = direction * -50f;
        player.rb.gravityScale = 2f;
        player.GetComponent<Collider2D>().enabled = false;
    }

    void DieAction(Player player) {
        player.isDying = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
