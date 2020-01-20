using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static bool finish;
    [SerializeField] private GameObject scoreCanvas;
    [SerializeField] private Text[] scoreTexts;
    [SerializeField] private Text[] score;

    // Update is called once per frame
    private void Update()
    {
        if (!finish) return;
        LoadScore();
        finish = false;
        
        Debug.Log(finish);
    }

    private void LoadScore()
    {
        scoreCanvas.SetActive(true);
        for (var i = 0; i < scoreTexts.Length; i++)
        {
            scoreTexts[i].text = score[i].text;
        }
    }
    
}
