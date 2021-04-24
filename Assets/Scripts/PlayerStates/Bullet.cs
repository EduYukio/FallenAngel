using UnityEngine;

public class Bullet : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        GameObject otherObj = other.gameObject;
        if (otherObj.CompareTag("Enemy")) {
            Groundy groundy = otherObj.GetComponent<Groundy>();
            Fly fly = otherObj.GetComponent<Fly>();

            if (groundy != null) {
                if (groundy.hp > 0) groundy.TakeDamage();
            }
            if (fly != null) {
                if (fly.hp > 0) fly.TakeDamage();
            }

            Destroy(gameObject);
        }
        else if (otherObj.CompareTag("Ground")) {
            // taca partículas
            Destroy(gameObject);
        }
    }
}