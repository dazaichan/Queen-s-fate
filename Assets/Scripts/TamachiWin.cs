using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamachiWin : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hearts;
    public void ActivateHearts()
    {
        hearts.SetActive(true);
    }

    public void DeactivateHearts()
    {
        hearts.SetActive(false);
    }
}
