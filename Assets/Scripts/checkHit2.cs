using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkHit2 : MonoBehaviour
{
    public FireChargeManager fireChargeManager;
    public UltiChargeManager ultiChargeManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            if (!other.GetComponent<IAController>().covering)
            {
                fireChargeManager.LoadBar(4);
                ultiChargeManager.LoadBar(2);
                other.GetComponent<HealthManager>().TakeDamage(5);
                other.GetComponent<Animator>().Play("hurt2");
            }
        }
    }
}
