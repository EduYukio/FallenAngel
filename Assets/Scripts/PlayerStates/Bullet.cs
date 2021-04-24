using UnityEngine;

public class Bullet : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        GameObject otherObj = other.gameObject;
        if (otherObj.CompareTag("Enemy")) {
            Enemy enemy = otherObj.GetComponent<Enemy>();
            if (enemy.hp > 0) enemy.TakeDamage();
            Destroy(gameObject);
        }
        else if (otherObj.CompareTag("Ground")) {
            // taca partículas
            Destroy(gameObject);
        }
    }
}