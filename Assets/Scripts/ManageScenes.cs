using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    public AudioSource buttonSound;
    // Start is called before the first frame update
    public void LoadMainScreen()
    {
        buttonSound.Play();
        StartCoroutine(LoadMainScene());

        
    }
    IEnumerator LoadMainScene()
    {
        yield return new WaitForSeconds(0.6f);

        SceneManager.LoadScene("mainScreen");
    }

    public void LoadControls()
    {
        buttonSound.Play();
        StartCoroutine(LoadControlsScene());
    }

    IEnumerator LoadControlsScene()
    {
        yield return new WaitForSeconds(0.6f);

        SceneManager.LoadScene("controlsScene");
    }

    public void LoadCharSelection()
    {
        buttonSound.Play();
        StartCoroutine(LoadCharScene());
    }

    IEnumerator LoadCharScene()
    {
        yield return new WaitForSeconds(0.6f);

        SceneManager.LoadScene("CharacterSelection");

    }

    public void ExitGame()
    {
        buttonSound.Play();
        Application.Quit();

    }
}
