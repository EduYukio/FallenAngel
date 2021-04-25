using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preload : MonoBehaviour {
    void Awake() {
        DontDestroyOnLoad(gameObject);
        LoadNextScene();
    }

    private void Update() {
    }

    public void InitializeFirstBGM() {
        // Manager.audio.Play("LD_song");
    }

    void LoadNextScene() {
        SceneManager.LoadScene(1);
    }
}
