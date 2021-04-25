using UnityEngine;

public class SmoothCamera : MonoBehaviour {
    Player player;
    public float moveSpeed = 0.5f;

    private void Start() {
        player = FindObjectOfType<Player>();
    }

    private void Update() {
        Vector2 nextPosition = new Vector2(player.transform.position.x, player.transform.position.y - 3.1f);
        Vector2 camPos = new Vector2(transform.position.x, transform.position.y);
        float distance = (camPos - nextPosition).magnitude;
        if (Mathf.Abs(distance) < 0.1f) return;

        Vector2 posCoords = Vector2.Lerp(transform.position, nextPosition, Time.deltaTime * moveSpeed);
        transform.position = new Vector3(posCoords.x, posCoords.y, -10f);
    }
}