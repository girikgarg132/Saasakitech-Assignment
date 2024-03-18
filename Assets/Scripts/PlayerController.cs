using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;

    Animator animator;
    Vector2 initialTouchPosition;
    bool isWalking;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                initialTouchPosition = Input.GetTouch(0).position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                Vector2 dirVector = initialTouchPosition - Input.GetTouch(0).position;
                dirVector.Normalize();
                transform.position += 
                    new Vector3(dirVector.x, 0f, dirVector.y) * 
                    movementSpeed * 
                    Time.deltaTime;
                transform.LookAt(new Vector3(dirVector.x, 0f, dirVector.y) + transform.position);
                if (!isWalking)
                {
                    animator.SetTrigger("walking");
                    isWalking = true;
                }
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                animator.SetTrigger("idle");
                isWalking = false;
            }
        }
    }
}
