using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelPortal : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        GameObject otherObj = other.gameObject;
        if (otherObj.CompareTag("Player")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}