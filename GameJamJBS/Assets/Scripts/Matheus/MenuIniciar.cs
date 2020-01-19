using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MenuIniciar : MonoBehaviour
{
    public string nomeCena;

    public GameObject[] botoes;

    public Slider slider;

    public AudioSource audioSource;

    public GameObject fade_In, fade_out;

    private float tempo = 1f;

    private bool volumeNoMinimo = false;

    private void Start()
    {
        fade_In.SetActive(true);

        //se quiser mudar Rafael, pode, ai coloca ao inves de sumir uma animação e tals
        botoes[0].SetActive(true);
        botoes[1].SetActive(true);
        botoes[2].SetActive(true);
        botoes[3].SetActive(false);
        botoes[4].SetActive(false);
    }

    public void Iniciar()
    {
        fade_out.SetActive(true);
        StartCoroutine(TempoPassarFase());
    }

    public void Opcoes()
    {
        //se quiser mudar Rafael, pode, ai coloca ao inves de sumir uma animação e tals
        botoes[0].SetActive(false);
        botoes[1].SetActive(false);
        botoes[2].SetActive(false);
        botoes[3].SetActive(true);
        botoes[4].SetActive(true);
    }

    public void VoltarAoMenu()
    {
        //se quiser mudar Rafael, pode, ai coloca ao inves de sumir uma animação e tals
        botoes[0].SetActive(true);
        botoes[1].SetActive(true);
        botoes[2].SetActive(true);
        botoes[3].SetActive(false);
        botoes[4].SetActive(false);
    }

    public void Sair()
    {
        //mudar depois para o celular tmb
        Application.Quit();
    }

    public void ControleDoVolume()
    {
        audioSource.volume = slider.value;
    }

    public void AlmentarBotaoAoPassarMouse(string nome)
    {
        if(nome.Equals("iniciar"))
        {
            botoes[0].GetComponent<Animator>().SetBool("iniciar", true);                
        }
        else
        if(nome.Equals("opcoes"))
        {
            botoes[1].GetComponent<Animator>().SetBool("opcoes", true);
        }
        else
        if(nome.Equals("sair"))
        {
            botoes[2].GetComponent<Animator>().SetBool("sair", true);
        }
        else
        if(nome.Equals("voltar"))
        {
            botoes[4].GetComponent<Animator>().SetBool("voltar", true);
        }
    }

    public void DiminuirBotaoAoPassarMouse(string nome)
    {
        if(nome.Equals("iniciar"))
        {
            botoes[0].GetComponent<Animator>().SetBool("iniciar", false);
        }
        else
        if(nome.Equals("opcoes"))
        {
            botoes[1].GetComponent<Animator>().SetBool("opcoes", false);
        }
        else
        if(nome.Equals("sair"))
        {
            botoes[2].GetComponent<Animator>().SetBool("sair", false);
        }
        else
        if(nome.Equals("voltar"))
        {
            botoes[4].GetComponent<Animator>().SetBool("voltar", false);
        }
    }

    IEnumerator TempoPassarFase()
    {
        yield return new WaitForSeconds(tempo);
        SceneManager.LoadScene(nomeCena);
    }
}
