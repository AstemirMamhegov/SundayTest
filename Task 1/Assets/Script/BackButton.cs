using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public Button backUI;


    public void Quit()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Menu))
            {
                Quit();
                return;
            }

            if (Input.GetKey(KeyCode.Escape))
            {
                backUI.onClick.Invoke();
            }
        }
    }
}
