using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    public float jumpPower;
    

    public void ImpulseJump(Rigidbody rigidbody)
    {
        rigidbody.AddForce(Vector3.up * jumpPower);
    }
}
