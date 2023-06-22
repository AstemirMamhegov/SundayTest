using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class ImageViewer : MonoBehaviour
    {
        public Image image;

        private void Start()
        {
            image.sprite = DataController.instance.image;

            Screen.orientation = ScreenOrientation.AutoRotation;
        }

        private void OnDestroy()
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
    }
}
