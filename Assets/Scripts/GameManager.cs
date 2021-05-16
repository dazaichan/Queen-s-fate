using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characters;
    [SerializeField]
    private GameObject[] healthbars;
    [SerializeField]
    private GameObject[] characters2;
    [SerializeField]
    private GameObject[] healthbars2;

    void Start()
    {
        int characterIndex = PlayerPrefs.GetInt("characterSelected");
        int characterIndex2 = PlayerPrefs.GetInt("characterSelectedPlayer2");
        characters[characterIndex].SetActive(true);
        healthbars[characterIndex].SetActive(true);

        characters2[characterIndex2].SetActive(true);
        healthbars2[characterIndex2].SetActive(true);

        if (characterIndex == 0)
        {
            Destroy(characters[1]);
        }
        else
        {
            Destroy(characters[0]);
        }

        if (characterIndex2 == 0)
        {
            Destroy(characters2[1]);
        }
        else
        {
            Destroy(characters2[0]);
        }
    }
}
