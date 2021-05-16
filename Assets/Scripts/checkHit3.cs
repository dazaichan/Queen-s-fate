using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkHit3 : MonoBehaviour
{
    public FireChargeManager fireChargeManager;
    public UltiChargeManager ultiChargeManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            if (!other.GetComponent<IAController>().covering && !other.GetComponent<IAController>().hurt)
            {
                fireChargeManager.LoadBar(7);
                ultiChargeManager.LoadBar(5);
                other.GetComponent<HealthManager>().TakeDamage(7);
                other.GetComponent<Animator>().Play("hurt3");
                Debug.Log("oli");
            }   
        }
    }
}
