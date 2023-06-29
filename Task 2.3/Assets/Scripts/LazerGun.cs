using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerGun : MonoBehaviour
{
    public PlayerRotate rotate;
    public Lazer lazer;
    public Transform muzzle;
    public LayerMask layer;
    public float shootDistance;
    public float damage;
    private Vector3 _shootablePoint;


    public void Shoot()
    {
        if (Physics.Raycast(muzzle.position, rotate.rotateRoot.forward, out RaycastHit hit, shootDistance, layer, QueryTriggerInteraction.Ignore))
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();

            if(enemy != null) 
            {
                enemy.health.Damage(damage);
            }

            _shootablePoint = hit.point;
        }
        else
        {
            _shootablePoint = muzzle.position + rotate.rotateRoot.forward * shootDistance;
        }

        Lazer spawned = Instantiate(lazer, muzzle.position, Quaternion.identity);

        spawned.SetPoint(_shootablePoint);
    }
}


