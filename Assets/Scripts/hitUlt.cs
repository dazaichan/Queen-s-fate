using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitUlt : MonoBehaviour
{
    public Animator charAnim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            this.gameObject.SetActive(false);
            other.GetComponent<IAController>().enabled = false;
            charAnim.Play("ulti2");
        }
    }
}
