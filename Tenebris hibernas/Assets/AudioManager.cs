using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public new AudioClip[] audio;
    private void Start()
    {
        GameObject audioSource = GameObject.Find("AudioClip");
        AudioSource source = audioSource.GetComponent<AudioSource>();

        // Utilize as linhas abaixo conforme necessário
        // para controlar a reprodução.
        //source.Play();       Inicia a reprodução do áudio.
        //source.Stop();       Pára a reprodução do áudio, inicia do começo quando for reproduzido novamente.
        //source.UnPause();    Despausa a reprodução previamente pausada. Similar ao Play após um audio ter sido pausado.
        //source.Pause();      Pausa a reprodução.

        // Exemplo:
        if (SceneManager.GetActiveScene().name == "Lvl1-1")
        {
            Cursor.visible = false;
            source.volume = 0.07f;
            source.panStereo = 0.0f;
            source.clip = audio[1];
            source.Play();
        }
        else if(SceneManager.GetActiveScene().name == "Menu")
        {
            Cursor.visible = true;
            source.volume = 0.03f;
            source.panStereo = -0.6f;
            source.clip = audio[0];
            source.Play();
        }
        else if (SceneManager.GetActiveScene().name == "Lvl1-2")
        {
            Cursor.visible = false;
            if(source.clip == audio[0])
                source.clip = audio[1];
            source.volume = 0.03f;
            source.panStereo = 0.0f;
        }
        else
        {
            source.Stop();
        }
    }
}
