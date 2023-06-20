using System.Collections.Generic;
using UnityEngine;
using static System.Net.WebRequestMethods;

namespace Assets.Script.GalleryItem
{
    public class Gallery : MonoBehaviour
    {
        [SerializeField] private List<AssetGalleryImg> Items;
        [SerializeField] private GalleryCell _galleryCellTemplate;
        [SerializeField] private Transform _container;

        public void OnEnable()
        {
            Render(Items);
        }

        public void Render(List<AssetGalleryImg> items)
        {
            foreach (Transform child in _container)
            {
                Destroy(child.gameObject);
            }

            //items.ForEach(item =>
            //{
            //    var cell = Instantiate(_galleryCellTemplate, _container);
            //    cell.Render(item);
            //});

            for(int i = 1; i <= 66; i++)
            {
                var cell = Instantiate(_galleryCellTemplate, _container);
                cell.url = $"http://data.ikppbb.com/test-task-unity-data/pics/{i}.jpg";
                cell.Init();
            }
        }
    }
}
