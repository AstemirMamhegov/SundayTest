using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Gallery Image")]
public class AssetGalleryImg : ScriptableObject, IItem
{
    public string Name => _name;
    public Sprite UIIcon => _uiIcon;

    [SerializeField]private string _name;
    [SerializeField]private Sprite _uiIcon;
}

