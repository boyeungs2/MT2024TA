using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float vertical;
    public float horizontal;
    public bool drifting;
    public bool boosting;

    private void FixedUpdate()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        drifting = (Input.GetAxis("Jump") != 0) ? true : false;
        boosting = (Input.GetKey(KeyCode.LeftShift)) ? true : false;
    }
}
