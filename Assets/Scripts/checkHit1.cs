using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkHit1 : MonoBehaviour
{
    public FireChargeManager fireChargeManager;
    public UltiChargeManager ultiChargeManager;
    public Transform myOrientation;
    public AudioClip damageAudio1;
    public AudioClip damageAudio1Tamachi;
    public AudioClip hit1Yura;
    public AudioClip hit1Tama;
    public AudioSource myAudio;
    public GameObject thisPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("player1Hit"))
        {
            if (other.CompareTag("enemy"))
            {
                if (!other.GetComponent<CharControllerPlayer2>().covering)
                {
                    fireChargeManager.LoadBar(2);
                    ultiChargeManager.LoadBar(1);
                    other.GetComponent<HealthManager>().TakeDamage(2);
                    other.GetComponent<Animator>().Play("hurt1");
                    other.GetComponent<CharControllerPlayer2>().cancelJump();
                    other.GetComponent<CharControllerPlayer2>().adjustOrientation(myOrientation);
                    if (other.name == "YuraIA")
                    {
                        other.GetComponent<AudioSource>().clip = damageAudio1;
                        other.GetComponent<AudioSource>().volume = 0.2f;
                        other.GetComponent<AudioSource>().Play();
                    }
                    else
                    {
                        other.GetComponent<AudioSource>().clip = damageAudio1Tamachi;
                        other.GetComponent<AudioSource>().volume = 1f;
                        other.GetComponent<AudioSource>().pitch = 1f;
                        other.GetComponent<AudioSource>().Play();
                    }
                    if (thisPlayer.name == "YuraPlayer")
                    {
                        myAudio.clip = hit1Yura;
                        myAudio.pitch = 1f;
                    }
                    else
                    {
                        myAudio.clip = hit1Tama;
                        myAudio.pitch = 2.5f;
                        myAudio.volume = 0.3f;
                    }
                    myAudio.Play();
                }
            }
        }
        else if (this.CompareTag("player2Hit"))
        {
            if (other.CompareTag("player"))
            {
                if (!other.GetComponent<CharController>().covering)
                {
                    fireChargeManager.LoadBar(2);
                    ultiChargeManager.LoadBar(1);
                    other.GetComponent<HealthManager>().TakeDamage(2);
                    other.GetComponent<Animator>().Play("hurt1");
                    other.GetComponent<CharController>().cancelJump();
                    other.GetComponent<CharController>().adjustOrientation(myOrientation);
                    if (other.name == "YuraPlayer")
                    {
                        other.GetComponent<AudioSource>().clip = damageAudio1;
                        other.GetComponent<AudioSource>().volume = 0.2f;
                        other.GetComponent<AudioSource>().Play();
                    }
                    else
                    {
                        other.GetComponent<AudioSource>().clip = damageAudio1Tamachi;
                        other.GetComponent<AudioSource>().volume = 1f;
                        other.GetComponent<AudioSource>().pitch = 1f;
                        other.GetComponent<AudioSource>().Play();
                    }
                    if (thisPlayer.name == "YuraIA")
                    {
                        myAudio.clip = hit1Yura;
                        myAudio.pitch = 1f;
                    }
                    else
                    {
                        myAudio.clip = hit1Tama;
                        myAudio.pitch = 2.5f;
                        myAudio.volume = 0.3f;
                    }
                    myAudio.Play();
                }
            }
        }
    }
}
