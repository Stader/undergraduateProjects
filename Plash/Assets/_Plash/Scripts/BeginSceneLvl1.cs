using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginSceneLvl1 : MonoBehaviour
{
    [SerializeField]
    private GameObject Instanciador;
    [SerializeField]
    private Text[] TextBegin;
    //private Animator anim;
    [SerializeField] private AudioSource soundGame;
    [SerializeField] private AudioClip begin, game;
    
    void Awake()
    {
        Instanciador.SetActive(false);
        //anim = GetComponent<Animator>();
        soundGame = GetComponent<AudioSource>();
    }

    IEnumerator BeginSceneCoroutine()
    {
        yield return new WaitForSeconds(3f);
        Instanciador.SetActive(true);
    }
     public void ChangeTextTwo()
    {
        foreach(Text text in TextBegin)
        {
            text.text = "2";
        }
    }

    public void ChangeTextOne()
    {
        foreach (Text text in TextBegin)
        {
            text.text = "1";
        }
        Instanciador.SetActive(true);
    }
    public void ChangeTextGogo()
    {
        foreach (Text text in TextBegin)
        {
            text.text = "GO!!!";
        }
    }

    public void PlaySoundGame()
    {
        soundGame.clip = game;
        soundGame.loop = true;
        soundGame.Play();
    }

    public void PlaySoundBegin()
    {
        soundGame.clip = begin;
        soundGame.loop = false;
        soundGame.Play();
    }
}
