using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCollision : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToEnableOrDisable;

    private void OnTriggerEnter(Collider other)
    {
        if (transform.GetChild(0).localPosition.y == 0.4f)
        {
            transform.GetChild(0).localPosition = Vector3.up * 0.15f;
        }
        else
        {
            transform.GetChild(0).localPosition = Vector3.up * 0.4f;
        }
        foreach (GameObject iterator in objectsToEnableOrDisable)
        {
            iterator.SetActive(!iterator.activeSelf);
        }
    }
}
