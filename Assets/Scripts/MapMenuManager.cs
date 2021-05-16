using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] maps;
    private int mapIndex;

    private void Start()
    {
        mapIndex = 0;
    }

    public void ChangeMap(int index)
    {
        for(int i =0; i< maps.Length; i++)
        {
            maps[i].SetActive(false);
        }
        maps[index].SetActive(true);
        mapIndex = index;
    }

    public void GameStart()
    {
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
