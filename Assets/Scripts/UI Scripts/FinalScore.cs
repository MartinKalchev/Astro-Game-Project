using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalScore : MonoBehaviour
{
    private Text scoreText;
    //private TextMeshPro scoreText;
    void Start()
    {
        //scoreText = GetComponent<TextMeshPro>();
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + Score.scoreAmount;
    }
}
