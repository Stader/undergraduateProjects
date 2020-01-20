using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject menu, settings, score;
    [SerializeField]
    private Text[] ranking;
    private Animator anim;
    //
    private void Awake()
    {
        anim = GetComponent<Animator>();
        menu.SetActive(true);
        settings.SetActive(false);
        score.SetActive(false);
    }
    void Start()
    {
        settings.SetActive(false);
        settings.gameObject.SetActive(false);
    }
    public void Play()
    {
        SceneManager.LoadScene("Fase1");
    }
    public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
            Application.OpenURL(webplayerQuitURL);
        #else
            Application.Quit();
        #endif
    }
    public void MenuToSettings()
    {
        StartCoroutine(MenuToSettingsCoroutine());
    }

    public void SettingsToMenu()
    {
        StartCoroutine(SettingsToMenuCoroutine());
    }

    public void MenuToScore()
    {
        StartCoroutine(MenuToScoreCoroutine());
    }

    public void ScoreToMenu()
    {
        StartCoroutine(ScoreToMenuCoroutine());
    }

    public IEnumerator MenuToSettingsCoroutine()
    {
        anim.Play("MenuOut");
        settings.SetActive(false);
        score.SetActive(false);
        yield return new WaitForSeconds(1f);
        menu.SetActive(false);
        settings.SetActive(true);
        anim.Play("SettingsIn");
    }

    public IEnumerator SettingsToMenuCoroutine()
    {
        anim.Play("SettingsOut");
        yield return new WaitForSeconds(1f);
        menu.SetActive(true);
        settings.SetActive(false);
        anim.Play("MenuIn");
    }

    public IEnumerator MenuToScoreCoroutine()
    {
        anim.Play("MenuOut");
        settings.SetActive(false);
        score.SetActive(false);
        yield return new WaitForSeconds(1f);
        menu.SetActive(false);
        score.SetActive(true);
        anim.Play("ScoreIn");

        var scores = Ranking.SetDefault();

        for (var i = 0; i < ranking.Length; i++)
        {
            ranking[i].text += scores[i].ToString();
        }
        
    }

    public IEnumerator ScoreToMenuCoroutine()
    {
        anim.Play("ScoreOut");
        yield return new WaitForSeconds(1f);
        menu.SetActive(true);
        score.SetActive(false);
        anim.Play("MenuIn");
    }

}
