using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartController : MonoBehaviour
{
    internal enum driveType {
        frontWheelDrive,
        rearWheelDrive,
        allWheelDrive
    }
    [SerializeField] private driveType drive;

    private InputManager IM;
    public WheelCollider[] wheels = new WheelCollider[4];
    public GameObject[] wheelMesh = new GameObject[4];
    public float motorTorque = 100f;
    public float steeringMax = 4f;

    private WheelFrictionCurve forwardFriction, sidewaysFriction;

    void Start()
    {
        GetObjects();
    }

    private void FixedUpdate()
    {
        AnimateWheels();
        MoveKart();
        SteerKart();
    }

    private void MoveKart()
    {
        float totalPower;

        if (drive == driveType.allWheelDrive) {
            for (int i = 0; i < wheels.Length; i++) {
                wheels[i].motorTorque = IM.vertical * (motorTorque / 4);
            }
        }
        else if (drive == driveType.rearWheelDrive) { 
            for (int i = 2; i < wheels.Length; i++) {
                wheels[i].motorTorque = IM.vertical * (motorTorque / 2);
            }
        }
        else { 
            for (int i = 0; i < wheels.Length - 2; i++) {
                wheels[i].motorTorque = IM.vertical * (motorTorque / 2);
            }
        }
    }

    private void SteerKart()
    {
        for (int i = 0; i < wheels.Length - 2; i++) {
            wheels[i].steerAngle = IM.horizontal * steeringMax;
        }
    }

    void AnimateWheels()
    {
        Vector3 wheelPosition = Vector3.zero;
        Quaternion wheelRotation = Quaternion.identity;

        for (int i = 0; i < wheels.Length; i++) {
            wheels[i].GetWorldPose(out wheelPosition, out wheelRotation);
            wheelMesh[i].transform.position = wheelPosition;
            wheelMesh[i].transform.rotation = wheelRotation;
        }
    }

    private void GetObjects()
    {
        IM = GetComponent<InputManager>();
    }

    //void adjustTraction()
    //{
    //    if (!IM.handbrake) {
    //        forwardFriction = wheels[0].forwardFriction;
    //        sidewaysFriction = wheels[0].sidewaysFriction;

    //        forwardFriction.extremumValue = forwardFriction.asymptoteValue = ((currSpeed * frictionM))
    //    }
    //}
}
