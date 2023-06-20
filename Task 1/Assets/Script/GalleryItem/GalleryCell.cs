using Assets.Script;
using System.IO;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using UnityEngine.Networking;
using System.Collections;

class GalleryCell : MonoBehaviour
{
    [SerializeField] private Text _nameField;
    [SerializeField] private Image _icon;
    public string url;

    public void Render(IItem item)
    {
        _nameField.text = item.Name;
        _icon.sprite = item.UIIcon;
    }

    public void Init()
    {
        StartCoroutine(DownloadImage(url));
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
        {
            Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
            _icon.sprite = sprite;
        }
    }

    private void OnMouseDown()
    {
        DataController.instance.image = _icon.sprite;
        SceneController.instance.LoadScene("ViewImageScene");
    }
}

