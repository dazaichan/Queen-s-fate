using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] maps;
    private int mapIndex;
    public AudioSource buttonSound;
    public AudioSource mapButtonSound;

    private void Start()
    {
        mapIndex = 0;
    }

    public void ChangeMap(int index)
    {
        mapButtonSound.Play();
        for (int i =0; i< maps.Length; i++)
        {
            maps[i].SetActive(false);
        }
        maps[index].SetActive(true);
        mapIndex = index;
    }

    public void GameStart()
    {
        buttonSound.Play();
        PlayerPrefs.SetInt("mapSelected", mapIndex);
        if (mapIndex == 0)
        {
            SceneManager.LoadScene("game");
        }
        else
        {
            SceneManager.LoadScene("game2");
        }
    }
}
