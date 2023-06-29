using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchController : MonoBehaviour
{
    public PlayerMovement movement;
    public PlayerRotate rotate;
    public LazerGun lazerGun;

    private void Start()
    {
        SelectableTarget.OnSelect += SelectEnemy;
    }

    private void SelectEnemy(Enemy enemy)
    {
        rotate.SetTarget(enemy.transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lazerGun.Shoot();
        }
    }
}
