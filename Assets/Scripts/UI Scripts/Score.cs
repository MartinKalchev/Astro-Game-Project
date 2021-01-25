using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static int scoreAmount;
    //private TextMeshPro scoreText;
    private Text scoreText;
    void Start()
    {
        //scoreText = GetComponent<TextMeshPro>();
        scoreText = GetComponent<Text>();
        scoreAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreAmount;
    }
}
