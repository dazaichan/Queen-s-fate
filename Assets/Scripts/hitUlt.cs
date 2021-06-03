using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitUlt : MonoBehaviour
{
    public Animator charAnim;
    public GameObject currentPlayer;
    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("player1Hit"))
        {
            if (other.CompareTag("enemy"))
            {
                if (!other.GetComponent<CharControllerPlayer2>().covering && !other.GetComponent<CharControllerPlayer2>().hurt)
                {
                    this.gameObject.SetActive(false);
                    other.GetComponent<CharControllerPlayer2>().cancelJump();
                    //other.GetComponent<CharControllerPlayer2>().adjustOrientation(currentPlayer.transform);
                    other.GetComponent<CharControllerPlayer2>().enabled = false;
                    charAnim.Play("ulti2");
                }
            }
        }
        else if (this.CompareTag("player2Hit"))
        {
            if (other.CompareTag("player"))
            {
                if (!other.GetComponent<CharController>().covering && !other.GetComponent<CharController>().hurt)
                {
                    this.gameObject.SetActive(false);
                    other.GetComponent<CharController>().cancelJump();
                    //other.GetComponent<CharController>().adjustOrientation(currentPlayer.transform);
                    other.GetComponent<CharController>().enabled = false;
                    charAnim.Play("ulti2");

                }
            }
        }
    }
}
