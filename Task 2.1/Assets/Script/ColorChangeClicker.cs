using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorChangeClicker : MonoBehaviour
{
    [SerializeField] private GameObject _coinShader;
    [SerializeField] private TextMeshProUGUI _textMeshProCoinClickClicker;

    public int coinClickCounter;

    private void Start()
    {
        _textMeshProCoinClickClicker.text = coinClickCounter.ToString();
    }

    public void Update()
    {
        _textMeshProCoinClickClicker.text = coinClickCounter.ToString();
    }

    private void OnMouseDown()
    {
        float redX = Random.Range(0, 256);
        float greenX = Random.Range(0, 256);
        float blueX = Random.Range(0, 256);
        float colourSum = redX + greenX + blueX;
        redX = redX / colourSum;
        greenX = greenX / colourSum;
        blueX = blueX / colourSum;

        _coinShader.GetComponent<Renderer>().material.color = new Color(redX, greenX, blueX, 1);

        coinClickCounter++;
    }
}
