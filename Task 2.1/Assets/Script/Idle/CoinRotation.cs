using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{

    [SerializeField] public float speed = 0;
    
    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime, Space.Self);
    }
}
