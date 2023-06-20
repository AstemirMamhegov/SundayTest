using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public string sceneName;

    public void Load()
    {
        SceneController.instance.LoadScene(sceneName);
    }
}
