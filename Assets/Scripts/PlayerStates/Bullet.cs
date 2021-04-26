using UnityEngine;

public class Bullet : MonoBehaviour {
    public float lifetime = 1f;
    public ParticleSystem hitParticles;

    private void Start() {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameObject otherObj = other.gameObject;
        if (otherObj.CompareTag("Groundy")) {
            Groundy groundy = otherObj.GetComponent<Groundy>();

            if (groundy.hp > 0) {
                // groundy.dieParticles.transform.parent = null;
                // groundy.dieParticles.transform.position = groundy.transform.position;
                // groundy.dieParticles.Play();
                hitParticles.transform.parent = null;
                hitParticles.transform.position = transform.position;
                hitParticles.transform.localScale = new Vector3(1, 1, 1);
                hitParticles.Play();
                groundy.TakeDamage();
            }
            Destroy(gameObject);
        }
        else if (otherObj.CompareTag("Fly")) {
            Fly fly = otherObj.GetComponent<Fly>();

            if (fly.hp > 0) {
                hitParticles.transform.parent = null;
                hitParticles.transform.position = transform.position;
                hitParticles.transform.localScale = new Vector3(1, 1, 1);
                hitParticles.Play();
                // fly.dieParticles.transform.parent = null;
                // fly.dieParticles.transform.position = fly.transform.position;
                // fly.dieParticles.Play();
                fly.TakeDamage();
            }
            Destroy(gameObject);
        }
        else if (otherObj.CompareTag("Ground")) {
            // taca partículas
            Destroy(gameObject);
        }
    }
}