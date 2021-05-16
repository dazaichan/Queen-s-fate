using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAController : MonoBehaviour
{
    public bool covering;
    public bool hurt;
    // Start is called before the first frame update
    void Start()
    {
        covering = false;
        hurt = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hurt()
    {
        hurt = true;
    }

    public void NoHurt()
    {
        hurt = false;
    }

}
