using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 _moveInput;
    public Rigidbody theRB;

    void Update()
    {
        _moveInput.x = Input.GetAxis("Horizontal");
        _moveInput.z = Input.GetAxis("Vertical");

        theRB.velocity = _moveInput * moveSpeed;
    }
}

