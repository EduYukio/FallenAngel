using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void PlayButton() {
        Manager.audio.Play("button_select");
        Sound BGM = Manager.audio.FindSound("LD_song");
        if (!BGM.source.isPlaying) BGM.source.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitButton() {
        Manager.audio.Play("button_select");
        Application.Quit();
    }

    public void BackButton() {
        Manager.audio.Play("button_select");
        SceneManager.LoadScene(1);
    }
}