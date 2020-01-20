using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private float min;
    [SerializeField] private float sec;
    [SerializeField] private Text watch, score;
    [SerializeField] private GameObject canvas;
    [SerializeField] private PauseGame pause;
    private bool auxPause = false;

    private void Start()
    {
        min = GetMin(time);
        sec = GetSec(time);

        InvokeRepeating("Decress", 3, 1f);
    }

    private void Update()
    {
        watch.text = min + ":" + (sec < 10 ? "0" + sec : sec.ToString());
        if (!auxPause && pause.isPause)
        {
            CancelInvoke("Decress");
            auxPause = true;
        }
        else if (auxPause && !pause.isPause)
        {
            InvokeRepeating("Decress", 0, 1);
            auxPause = false;
        }
    }

    private float GetMin(float time)
    {
        if (time >= 60)
            return Mathf.Floor(time / 60);
        return 0;
    }

    private float GetSec(float time)
    {
        if (time >= 60)
            return time % 60;
        return time;
    }

    private void Decress()
    {
        if (min == 0 && sec == 0)
        {
            StartCoroutine(NewScene());
        }

        sec--;
        if (min >= 0)
        {
            if (sec < 0)
            {
                sec = 59;
                min--;
            }
        }
    }

    IEnumerator NewScene()
    {
        canvas.SetActive(true);
        score.text = ScoreGame.scorePoint.ToString();
        yield return new WaitForSeconds(3f);

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Fase3"))
        {
            Ranking.UpdadeRank(ScoreGame.scorePoint);
            SceneManager.LoadScene("Score");
        }
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
