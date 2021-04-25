using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour {
    public bool cameraIsShaking = false;

    public IEnumerator ShakeCoroutine(GameObject cameraObj, float duration, float magnitude) {
        cameraIsShaking = true;

        Vector3 originalPos = cameraObj.transform.position;

        float elapsed = 0.0f;
        while (elapsed < duration) {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            cameraObj.transform.position = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);
            elapsed += Time.deltaTime;

            yield return null;
        }
        cameraIsShaking = false;

        cameraObj.transform.position = originalPos;
    }

    public void Shake(GameObject cameraObj, float duration, float magnitude) {
        StartCoroutine(ShakeCoroutine(cameraObj, duration, magnitude));
    }
}
