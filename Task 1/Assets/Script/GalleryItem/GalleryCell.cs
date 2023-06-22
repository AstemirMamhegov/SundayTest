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
    private bool _loaded, _startLoad;
    private float _minBoarder;

    public void Render(IItem item)
    {
        _nameField.text = item.Name;
        _icon.sprite = item.UIIcon;
    }

    public void Init()
    {
        Sprite image = DataController.instance.GetImage(url);

        if (image != null)
        {
            _icon.sprite = image;
            _loaded = true;
            _startLoad = true;
            return;
        }

        Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        _minBoarder = min.y;

        if (CheckPosition())
        {
            StartCoroutine(DownloadImage(url));
        }
    }

    private void Update()
    {
        if (_loaded)
            return;

        if (!_startLoad && CheckPosition())
        {
            StartCoroutine(DownloadImage(url));
        }
    }

    private bool CheckPosition()
    {
        if (transform.position.y > _minBoarder)
            return true;

        return false;
    }


    IEnumerator DownloadImage(string MediaUrl)
    {
        _startLoad = true;
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            Debug.Log(request.error);
        else
        {
            Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
            _icon.sprite = sprite;
            _loaded = true;
            DataController.instance.AddNewImage(url, sprite);
        }
    }

    private void OnMouseDown()
    {
        if (!_loaded)
            return;

        DataController.instance.SelectImage(url);
        SceneController.instance.LoadScene("ViewImageScene");
    }
}

