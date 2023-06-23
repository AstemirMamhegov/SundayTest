using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{

    public float speed = 0;
    public Vector3 dirRotate;
    
    void Update()
    {
        transform.Rotate(dirRotate * speed * Time.deltaTime, Space.Self);
    }
}
