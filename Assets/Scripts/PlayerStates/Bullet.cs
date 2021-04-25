using UnityEngine;

public class Bullet : MonoBehaviour {
    public float lifetime = 2f;
    private void Start() {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameObject otherObj = other.gameObject;
        if (otherObj.CompareTag("Groundy")) {
            Groundy groundy = otherObj.GetComponent<Groundy>();

            if (groundy.hp > 0) groundy.TakeDamage();
            Destroy(gameObject);
        }
        else if (otherObj.CompareTag("Fly")) {
            Fly fly = otherObj.GetComponent<Fly>();

            if (fly.hp > 0) fly.TakeDamage();
            Destroy(gameObject);
        }
        else if (otherObj.CompareTag("Ground")) {
            // taca partículas
            Destroy(gameObject);
        }
    }
}