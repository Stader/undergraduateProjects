using UnityEngine;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour
{
    public Slider slider;

    public GameObject[] objetosHud;


    private void Start()
    {
        Time.timeScale = 1;
        
        if(GameObject.FindGameObjectWithTag("musica") != null)
        {
            AudioSource audioSource = GameObject.FindGameObjectWithTag("musica").GetComponent<AudioSource>();
            
            if(audioSource != null)
            {
                slider.value = audioSource.volume;
            }
        }
        

        //se quiser mudar Rafael, pode, ai coloca ao inves de sumir uma animação e tals
        objetosHud[0].SetActive(true);
        objetosHud[1].SetActive(true);
        objetosHud[2].SetActive(true);
        objetosHud[3].SetActive(false);
        objetosHud[4].SetActive(false);
    }

    public void Menu()
    {
        Time.timeScale = 0;

        //se quiser mudar Rafael, pode, ai coloca ao inves de sumir uma animação e tals
        objetosHud[0].SetActive(false);
        objetosHud[1].SetActive(false);
        objetosHud[2].SetActive(false);
        objetosHud[3].SetActive(true);
        objetosHud[4].SetActive(true);
    }

    public void VoltarAoJogo ()
    {
        Time.timeScale = 1;

        //se quiser mudar Rafael, pode, ai coloca ao inves de sumir uma animação e tals
        objetosHud[0].SetActive(true);
        objetosHud[1].SetActive(true);
        objetosHud[2].SetActive(true);
        objetosHud[3].SetActive(false);
        objetosHud[4].SetActive(false);
    }

    public void ControleDoVolumeMenuPause()
    {
        if(GameObject.FindGameObjectWithTag("musica") != null)
        {
            AudioSource audioSource = GameObject.FindGameObjectWithTag("musica").GetComponent<AudioSource>();
            
            if(audioSource != null)
            {
                audioSource.volume = slider.value;
            }
        }
    }
}
