using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            other.GetComponent<HealthManager>().TakeDamage(1);
            other.GetComponent<Animator>().Play("hurt1");
        }
    }
}
