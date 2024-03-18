using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollidedObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("called");
        Destroy(other.gameObject);
    }

}
