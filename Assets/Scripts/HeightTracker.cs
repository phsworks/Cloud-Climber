using System;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class HeightTracker : MonoBehaviour
{
    float height;
    float highestPoint = 0;
    public TMP_Text heightText;
    public TMP_Text scoreText;
    public UIDocument endScreenDocument;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endScreenDocument = GameObject.Find("EndScreen").GetComponent<UIDocument>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHeight();
        victoryCheck();

        if (height > highestPoint)
        {
            updateScore();
        }
    }

    void UpdateHeight()
    {
        height = transform.position.y - 30f;
        heightText.text = "Height: " + Math.Round(height, 0).ToString() + " Meters";
    }

    void updateScore()
    {
        highestPoint = transform.position.y -30f;
        scoreText.text = "Score: " + Mathf.FloorToInt(highestPoint).ToString();

    }

    void victoryCheck()
    {
        if (height >= 65)
        {
            endScreenDocument.rootVisualElement.style.display = DisplayStyle.Flex;
        }
    }


}
