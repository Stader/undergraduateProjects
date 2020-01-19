using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PermanecerAudio : MonoBehaviour
{
    public AudioClip musicaMenu, novaMusica;

    private bool naoRepetir1 = false, naoRepetir2 = false, pararDeAlmentarMusica = false, pararDeAlmentarMusicaLevel1 = false;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("musica");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Menu" && naoRepetir2 != true)
        {
            naoRepetir2 = true;
            naoRepetir1 = false;
            GetComponent<AudioSource>().volume = 0;
            GetComponent<AudioSource>().clip = musicaMenu;
            GetComponent<AudioSource>().Play();
        }
        
        if (SceneManager.GetActiveScene().name == "Level1" && naoRepetir1 != true)
        {
            naoRepetir1 = true;
            naoRepetir2 = false;
            GetComponent<AudioSource>().clip = novaMusica;
            GetComponent<AudioSource>().Play();
        }

        if(SceneManager.GetActiveScene().name == "Menu" && pararDeAlmentarMusica == false) 
        {
            if(GetComponent<AudioSource>().volume == 1f)
            {
                pararDeAlmentarMusica = true;
            }
            else
            {
                GetComponent<AudioSource>().volume += Time.deltaTime;
            }
        }
    }
}
