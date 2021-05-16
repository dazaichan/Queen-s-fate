using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkHitFire : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            if (!other.GetComponent<IAController>().covering && !other.GetComponent<IAController>().hurt)
            {
                other.GetComponent<HealthManager>().TakeDamage(12);
                other.GetComponent<Animator>().Play("hurt3");
            }
            else
            {
                other.GetComponent<HealthManager>().TakeDamage(6);
            }
        }
    }
}
