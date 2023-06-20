using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class Loader : MonoBehaviour, ILoader
    {
        public GameObject ui;
        public Slider slider;

        public void LoadEnd()
        {
            ui.SetActive(false);
            slider.value = 1;
        }

        public void LoadStart()
        {
            ui.SetActive(true);
            slider.value = 0;
        }

        public void SetProgress(float progress)
        {
            slider.value = progress;
        }
    }

    public interface ILoader
    {
        void LoadStart();
        void SetProgress(float progress);
        void LoadEnd();
    }
}
