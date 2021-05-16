using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkHit1 : MonoBehaviour
{
    public FireChargeManager fireChargeManager;
    public UltiChargeManager ultiChargeManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            if (!other.GetComponent<IAController>().covering)
            {
                fireChargeManager.LoadBar(2);
                ultiChargeManager.LoadBar(1);
                other.GetComponent<HealthManager>().TakeDamage(2);
                other.GetComponent<Animator>().Play("hurt1");
            }
        }
    }
}
