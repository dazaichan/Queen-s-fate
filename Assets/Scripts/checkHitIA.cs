using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkHitIA : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            if (!other.GetComponent<CharController>().covering)
            {
                other.GetComponent<HealthManager>().TakeDamage(5);
            }
            Debug.Log("oli");
        }
    }
}
