using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartController : MonoBehaviour
{
    public Rigidbody kart;

    float speed, currentSpeed;
    float rotate, currentRotate;

    [Header("Parameters")]
    public float acceleration = 30f;
    public float steering = 80f;
    public float gravity = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = kart.transform.position - new Vector3(0, .2f, 0);

        if (Input.GetKey(KeyCode.W)) { 
            speed = acceleration;
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            int dir = Input.GetAxis("Horizontal") > 0 ? 1 : -1;
            float amount = Mathf.Abs((Input.GetAxis("Horizontal")));
            Steer(dir, amount);
        }

        currentSpeed = Mathf.SmoothStep(currentSpeed, speed, Time.deltaTime * 12f);
        currentRotate = Mathf.Lerp(currentRotate, rotate, Time.deltaTime * 4f);

        speed = 0f;
        rotate = 0f;
    }

    private void FixedUpdate()
    {
        kart.AddForce(kart.transform.forward * currentSpeed, ForceMode.Acceleration);

        kart.AddForce(Vector3.down * gravity, ForceMode.Acceleration);

        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y + currentRotate, 0), Time.deltaTime * 5f);
    }

    private void Steer(int direction, float amount)
    {
        rotate = (steering * direction) * amount;
    }
}
