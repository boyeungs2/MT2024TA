using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TmpController : MonoBehaviour
{
    public Rigidbody sphere;

    public float gravity = 10f;

    private void FixedUpdate()
    {
        sphere.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
    }
}
