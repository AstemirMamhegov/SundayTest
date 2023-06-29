using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public Transform rotateRoot;
    private Vector3 _moveInput;
    public float rotateSpeed;
    private Transform _target;
    public Rigidbody theRB;

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    void Update()
    {
        _moveInput.x = Input.GetAxis("Horizontal");
        _moveInput.z = Input.GetAxis("Vertical");

        if (_target != null && _moveInput.magnitude < 0.5f)
        {
            rotateRoot.LookAt(_target);
            return;
        }

        if (_target)
            _target = null;

        if (Mathf.Abs(_moveInput.x) > 0.5f || Mathf.Abs(_moveInput.z) > 0.5f)
        {
            Vector3 relativePos = new Vector3(_moveInput.x, 0f, _moveInput.z);
            Quaternion targetRot = Quaternion.LookRotation(relativePos, Vector3.up);
            rotateRoot.rotation = Quaternion.Lerp(rotateRoot.rotation, targetRot, Time.deltaTime * rotateSpeed);
            theRB.angularVelocity = Vector3.zero;
        }
    }
}
