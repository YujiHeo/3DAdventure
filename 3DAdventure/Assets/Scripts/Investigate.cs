using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Investigate : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    private int layermask;




    void Start()
    {
        layermask = 1 << 7;
    }

    public void OnInteractionInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layermask))
            {
                Debug.Log("hit Investigate" + hit.collider.gameObject.name);
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            }

            else
            {
                Debug.DrawRay(transform.position, transform.forward * 1000f, Color.red);
            }
        }
    }
}
