using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public static DataController instance;
    public Sprite image;

    public struct ImageData
    {
        public string url;
        public Sprite image;
    } 

    public List<ImageData> images = new List<ImageData>();

    private void Awake()
    {
        instance = this;
    }

    public void AddNewImage(string url, Sprite image)
    {
        ImageData data = new ImageData();
        data.url = url;
        data.image = image;
        images.Add(data);
    }

    public void SelectImage(string url)
    {
        foreach (ImageData data in images)
        {
            if (data.url == url)
            {
                image = data.image;
                break;
            }
        }
    }

    public Sprite GetImage(string url)
    {
        foreach (ImageData data in images)
        {
            if (data.url == url)
            {
                return data.image;            
            }
        }

        return null;
    }
}
