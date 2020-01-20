using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGame : MonoBehaviour
{
    [SerializeField]
    public Text score;
    public static int scorePoint;
    private void Start()
    {
        score.text = "0";
    }

    private void Update()
    {
        score.text = scorePoint.ToString();
    }

    public void UpdateScore()
    {
        scorePoint += 5;
    }
}
