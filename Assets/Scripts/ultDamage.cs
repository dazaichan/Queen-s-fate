using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ultDamage : MonoBehaviour
{
    public AudioClip damageAudioUlti;
    public AudioClip damageAudioUltiTamachi;
    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("player1Hit"))
        {
            if (other.CompareTag("enemy"))
            {
                other.GetComponent<CharControllerPlayer2>().enabled = true;
                other.GetComponent<HealthManager>().TakeDamage(30);
                other.GetComponent<Animator>().Play("hurt3");
                if (other.name == "YuraIA")
                {
                    other.GetComponent<AudioSource>().clip = damageAudioUlti;
                    other.GetComponent<AudioSource>().volume = 0.2f;
                    other.GetComponent<AudioSource>().Play();
                }
                else
                {
                    other.GetComponent<AudioSource>().clip = damageAudioUltiTamachi;
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
                other.GetComponent<CharController>().enabled = true;
                other.GetComponent<HealthManager>().TakeDamage(30);
                other.GetComponent<Animator>().Play("hurt3");
                if (other.name == "YuraPlayer")
                {
                    other.GetComponent<AudioSource>().clip = damageAudioUlti;
                    other.GetComponent<AudioSource>().volume = 0.2f;
                    other.GetComponent<AudioSource>().Play();
                }
                else
                {
                    other.GetComponent<AudioSource>().clip = damageAudioUltiTamachi;
                    other.GetComponent<AudioSource>().volume = 1f;
                    other.GetComponent<AudioSource>().pitch = 1f;
                    other.GetComponent<AudioSource>().Play();
                }
            }
        }
    }
}
