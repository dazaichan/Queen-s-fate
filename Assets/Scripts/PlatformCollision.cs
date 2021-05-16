using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollision : MonoBehaviour
{
    public GameObject[] positions;
    public GameObject playerPosition;
    public BoxCollider collider;
    private Transform myTransform;
    void Start()
    {
        myTransform = this.transform;
        StartCoroutine(AssignGround(1f));
    }
    public IEnumerator AssignGround(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        for (int i = 0; i < positions.Length; i++)
        {
            if (positions[i] != null)
            {
                playerPosition = positions[i];
            }
        }
    }
    void FixedUpdate()
    {      
        if (playerPosition)
        {
            Vector3 distance = playerPosition.transform.position - myTransform.position;
            if (distance.y >= 0)
            {
                collider.enabled = true;
            }
            else
            {
                collider.enabled = false;
            }
        }
    }
}
