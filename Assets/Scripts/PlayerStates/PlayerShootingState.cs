using UnityEngine;

public class PlayerShootingState : PlayerBaseState {
    public override void EnterState(Player player) {
        player.animator.Play("Shooting");
        Setup(player);
    }

    public override void Update(Player player) {
        base.ProcessMovementInput(player);

        if (player.ammunition > 0 && Input.GetButton("Shooting")) {
            ShootAction(player);
            return;
        }

        if (player.ammunition <= 0 && Input.GetButton("Shooting")) {
            player.emptyAmmoParticles.Play();
        }

        if (CheckTransitionToFalling(player)) return;
        if (base.CheckTransitionToGrounded(player)) return;
    }

    void Setup(Player player) {
    }

    void ShootAction(Player player) {
        if (player.shootingCooldownTimer > 0) return;

        Manager.audio.Play("shoot");
        player.shootParticles.Play();
        float xOffset = 0f;
        Vector3 spawnPosition = player.transform.position + new Vector3(xOffset, -0.6f, 0f);
        GameObject bullet = MonoBehaviour.Instantiate(player.defaultBulletPrefab, spawnPosition, Quaternion.identity);
        Vector3 direction = Vector3.down;

        bullet.GetComponent<Rigidbody2D>().velocity = direction * player.defaultBulletSpeed;

        player.shootingCooldownTimer = player.startShootingCooldownTimer;

        float ySpeed = Mathf.Clamp(player.maxFallSpeed + player.shootingForce, 0f, player.shootingMaxSpeed);
        player.rb.velocity = new Vector2(player.rb.velocity.x, ySpeed);
        player.ammunition--;
        player.UpdateAmmoUI();
    }

    public override bool CheckTransitionToFalling(Player player) {
        if (player.isGrounded) return false;

        bool playerIsFalling = player.rb.velocity.y <= 0;

        if (playerIsFalling) {
            player.TransitionToState(player.FallingState);
            return true;
        }

        return false;
    }
}
