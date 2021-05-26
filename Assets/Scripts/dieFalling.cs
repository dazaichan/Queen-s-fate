using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieFalling : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy") || other.CompareTag("player"))
        {
            other.GetComponent<HealthManager>().TakeDamage(100);
            //other.GetComponent<Animator>().Play("hurt2");
        }
    }
}
