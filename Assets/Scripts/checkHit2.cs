using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkHit2 : MonoBehaviour
{
    public FireChargeManager fireChargeManager;
    public UltiChargeManager ultiChargeManager;
    public Transform myOrientation;
    public AudioClip damageAudio2;
    public AudioClip damageAudio2Tamachi;
    public AudioClip hit2Yura;
    public AudioClip hit2Tama;
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
                    fireChargeManager.LoadBar(4);
                    ultiChargeManager.LoadBar(2);
                    other.GetComponent<HealthManager>().TakeDamage(5);
                    other.GetComponent<Animator>().Play("hurt2");
                    other.GetComponent<CharControllerPlayer2>().cancelJump();
                    //other.GetComponent<CharControllerPlayer2>().adjustOrientation(myOrientation);
                    if (other.name == "YuraIA")
                    {
                        other.GetComponent<AudioSource>().clip = damageAudio2;
                        other.GetComponent<AudioSource>().volume = 1f;
                        other.GetComponent<AudioSource>().Play();
                    }
                    else
                    {
                        other.GetComponent<AudioSource>().clip = damageAudio2Tamachi;
                        other.GetComponent<AudioSource>().volume = 1f;
                        other.GetComponent<AudioSource>().pitch = 1f;
                        other.GetComponent<AudioSource>().Play();
                    }
                    if (thisPlayer.name == "YuraPlayer")
                    {
                        myAudio.clip = hit2Yura;
                        myAudio.pitch = 1f;
                    }
                    else
                    {
                        myAudio.clip = hit2Tama;
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
                    fireChargeManager.LoadBar(4);
                    ultiChargeManager.LoadBar(2);
                    other.GetComponent<HealthManager>().TakeDamage(5);
                    other.GetComponent<Animator>().Play("hurt2");
                    other.GetComponent<CharController>().cancelJump();
                    //other.GetComponent<CharController>().adjustOrientation(myOrientation);
                    if (other.name == "YuraPlayer")
                    {
                        other.GetComponent<AudioSource>().clip = damageAudio2;
                        other.GetComponent<AudioSource>().volume = 1f;
                        other.GetComponent<AudioSource>().Play();
                    }
                    else
                    {
                        other.GetComponent<AudioSource>().clip = damageAudio2Tamachi;
                        other.GetComponent<AudioSource>().volume = 1f;
                        other.GetComponent<AudioSource>().pitch = 1f;
                        other.GetComponent<AudioSource>().Play();
                    }
                    if (thisPlayer.name == "YuraIA")
                    {
                        myAudio.clip = hit2Yura;
                        myAudio.pitch = 1f;
                    }
                    else
                    {
                        myAudio.clip = hit2Tama;
                        myAudio.pitch = 2.5f;
                        myAudio.volume = 0.3f;
                    }
                    myAudio.Play();
                }
            }
        }
    }
}
