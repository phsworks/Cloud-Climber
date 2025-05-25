using System;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeightTracker : MonoBehaviour
{
    float height;
    float highestPoint = 0;
    public TMP_Text heightText;
    public TMP_Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHeight();

        if (height > highestPoint)
        {
            updateScore();
        }
    }

    void UpdateHeight()
    {
        height = transform.position.y - 30f;
        heightText.text = "Height: " + Math.Round(height, 2).ToString() + "Meters";
    }

    void updateScore()
    {
        highestPoint = transform.position.y - 30f;
        scoreText.text = "Score: " + Mathf.FloorToInt(highestPoint).ToString() ;

    }
}
