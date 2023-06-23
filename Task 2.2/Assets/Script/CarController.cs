using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class CarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float acceleration, deceleration, decelerationToStop;
    public VirtualDPad steeringControl, motorControl;
    private float _motorTorque;
    private float _lastMoveDir;

    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
        CalculateTorque();
        float steering = maxSteeringAngle * steeringControl.value.x;

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = _motorTorque;
                axleInfo.rightWheel.motorTorque = _motorTorque;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }

    private void CalculateTorque()
    {
        float ac;

        if (Mathf.Abs(motorControl.value.y) < float.Epsilon)
        {
            if (_velocity.magnitude > 0 && Vector3.Dot(transform.forward * _lastMoveDir, _velocity) > 0)
                ac = decelerationToStop * _lastMoveDir;
            else
            {
                _motorTorque = 0;
                return;
            }
        }
        else
        {
            _lastMoveDir = Vector3.Dot(transform.forward, _velocity);
            ac = motorControl.value.y * (motorControl.value.y > 0 ? acceleration : deceleration);
        }

        _motorTorque = Mathf.Clamp(_motorTorque + ac * Time.fixedDeltaTime, -maxMotorTorque, +maxMotorTorque);
    }

    private Vector3 _lastPosition;
    private Vector3 _velocity;

    private void Update()
    {
        _velocity = Vector3.Lerp(_velocity, (transform.position - _lastPosition) / Time.deltaTime, 10 * Time.deltaTime);
        _lastPosition = transform.position;
    }
}