using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.WebRequestMethods;

namespace Assets.Script.GalleryItem
{
    public class Gallery : MonoBehaviour
    {
        [SerializeField] private List<AssetGalleryImg> Items;
        [SerializeField] private GalleryCell _galleryCellTemplate;
        [SerializeField] private Transform _container;
        [SerializeField] private GridLayoutGroup _layoutGroup;

        public void OnEnable()
        {
            float widthScreen = Screen.width;
            float cellSize = (Screen.width - _layoutGroup.spacing.x * _layoutGroup.constraintCount - _layoutGroup.padding.left - _layoutGroup.padding.right)/ _layoutGroup.constraintCount;
            _layoutGroup.cellSize = new Vector2 (cellSize, cellSize);

            Render(Items);

            Debug.Log(Screen.width);
        }

        public void Render(List<AssetGalleryImg> items)
        {
            foreach (Transform child in _container)
            {
                Destroy(child.gameObject);
            }

            for(int i = 1; i <= 66; i++)
            {
                var cell = Instantiate(_galleryCellTemplate, _container);
                cell.url = $"http://data.ikppbb.com/test-task-unity-data/pics/{i}.jpg";
                cell.Init();
            }
        }
    }
}
