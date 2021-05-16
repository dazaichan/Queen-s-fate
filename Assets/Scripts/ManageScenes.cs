using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadMainScreen()
    {
        SceneManager.LoadScene("mainScreen");
    }

    public void LoadCharSelection()
    {
        SceneManager.LoadScene("CharacterSelection");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
