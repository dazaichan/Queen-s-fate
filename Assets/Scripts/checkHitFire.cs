using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkHitFire : MonoBehaviour
{
    public Transform myOrientation;
    public AudioClip damageAudioFire;
    public AudioClip damageAudioFireTamachi;
    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("player1Hit"))
        {
            if (other.CompareTag("enemy"))
            {
                if (!other.GetComponent<CharControllerPlayer2>().covering && !other.GetComponent<CharControllerPlayer2>().hurt)
                {
                    other.GetComponent<HealthManager>().TakeDamage(12);
                    other.GetComponent<Animator>().Play("hurt3");
                    other.GetComponent<CharControllerPlayer2>().cancelJump();
                    //other.GetComponent<CharControllerPlayer2>().adjustOrientation(myOrientation);
                }
                else
                {
                    other.GetComponent<HealthManager>().TakeDamage(6);
                }
                if (other.name == "YuraIA")
                {
                    other.GetComponent<AudioSource>().clip = damageAudioFire;
                    other.GetComponent<AudioSource>().volume = 0.6f;
                    other.GetComponent<AudioSource>().Play();
                }
                else
                {
                    other.GetComponent<AudioSource>().clip = damageAudioFireTamachi;
                    other.GetComponent<AudioSource>().volume = 1f;
                    other.GetComponent<AudioSource>().pitch = 1f;
                    other.GetComponent<AudioSource>().Play();
                }
            }
        }
        else if (this.CompareTag("player2Hit"))
        {
            if (other.CompareTag("player"))
            {
                if (!other.GetComponent<CharController>().covering && !other.GetComponent<CharController>().hurt)
                {
                    other.GetComponent<HealthManager>().TakeDamage(12);
                    other.GetComponent<Animator>().Play("hurt3");
                    other.GetComponent<CharController>().cancelJump();
                    //other.GetComponent<CharController>().adjustOrientation(myOrientation);
                }
                else
                {
                    other.GetComponent<HealthManager>().TakeDamage(6);
                }
                if (other.name == "YuraPlayer")
                {
                    other.GetComponent<AudioSource>().clip = damageAudioFire;
                    other.GetComponent<AudioSource>().volume = 0.6f;
                    other.GetComponent<AudioSource>().Play();
                }
                else
                {
                    other.GetComponent<AudioSource>().clip = damageAudioFireTamachi;
                    other.GetComponent<AudioSource>().volume = 1f;
                    other.GetComponent<AudioSource>().pitch = 1f;
                    other.GetComponent<AudioSource>().Play();
                }
            }
        }
    }
}
