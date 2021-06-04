using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    public AudioSource buttonSound;
    // Start is called before the first frame update

    public void Start()
    {
        Time.timeScale = 1f;
    }

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

    public void LoadMainScreenFromPause()
    {
        buttonSound.Play();
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

    public void reloadGame()
    {
        buttonSound.Play(); 
        
        if (SceneManager.GetActiveScene().name == "game")
        {
            SceneManager.LoadScene("game");
        }
        else
        {
            SceneManager.LoadScene("game2");
        }
        //StartCoroutine(reloadGameScene());
    }

    IEnumerator reloadGameScene()
    {
        yield return new WaitForSeconds(0.6f);



    }

    public void ExitGame()
    {
        buttonSound.Play();
        Application.Quit();

    }
}
