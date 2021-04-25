using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void PlayButton() {
        Sound BGM = Manager.audio.FindSound("LD_song");
        if (!BGM.source.isPlaying) BGM.source.Play();
        SceneManager.LoadScene(2);
    }

    public void QuitButton() {
        Application.Quit();
    }
}