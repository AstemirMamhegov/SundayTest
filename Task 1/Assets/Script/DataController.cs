using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public static DataController instance;
    public Sprite image;

    private void Awake()
    {
        instance = this;
    }
}
