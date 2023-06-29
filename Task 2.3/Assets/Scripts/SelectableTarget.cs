using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableTarget : MonoBehaviour
{
    public LayerMask layer;
    public static Action<Enemy> OnSelect;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if(Physics.Raycast(ray,out RaycastHit hit, 100, layer, QueryTriggerInteraction.Ignore))
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();

                if (enemy)
                {
                    OnSelect?.Invoke(enemy);
                }
            }
        }
    }
}
