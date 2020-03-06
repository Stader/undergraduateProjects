using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{

    private PlayerController _scriptPlayer;
    [SerializeField] private Slider barraVida;
    public GameObject painelGameOver;
    public Text textoTempoSobrevivencia;
    public Text textoTempoMaximo;
    private float _tempoPontuacaoSalvo = 0f;
    private int quantidadeDeZumbisMortos;
    public Text TextoQtdZumbisMortos;
    public Text TextoChefeAparece;

    private void Start()
    {
        _scriptPlayer = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        barraVida.maxValue = _scriptPlayer.status.Vida;
        barraVida.value = _scriptPlayer.status.Vida;
        Time.timeScale = 1;
        _tempoPontuacaoSalvo = PlayerPrefs.GetFloat("PontuacaoMaxima");
    }

    public void AtualizarSliderVidaJogador()
    {
        barraVida.value = _scriptPlayer.status.Vida;
    }

    public void AtualizarQuantidadeDeZumbisMortos()
    {
        quantidadeDeZumbisMortos++;
        TextoQtdZumbisMortos.text = string.Format("x {0}", quantidadeDeZumbisMortos);
    }

    public void GameOver()
    {
        painelGameOver.SetActive(true);
        Time.timeScale = 0;

        var minutos = (int)(Time.timeSinceLevelLoad / 60);
        var segundos = (int)Time.timeSinceLevelLoad % 60;
        textoTempoSobrevivencia.text = "Você sobreviveu por: " + minutos + "min e " + segundos + "s";

        AjustarPontuacaoMaxima(minutos, segundos);
    }

    void AjustarPontuacaoMaxima(int min, int seg)
    {
        if (Time.timeSinceLevelLoad > _tempoPontuacaoSalvo)
        {
            _tempoPontuacaoSalvo = Time.timeSinceLevelLoad;
            textoTempoMaximo.text = string.Format("Seu melhor tempo é {0}min e {1}s", min, seg);
            PlayerPrefs.SetFloat("PontuacaoMaxima", _tempoPontuacaoSalvo);
        }

        if (textoTempoMaximo.text == "")
        {
            min = (int)_tempoPontuacaoSalvo / 60;
            seg = (int)_tempoPontuacaoSalvo % 60;
            textoTempoMaximo.text = string.Format("Seu melhor tempo é {0}min e {1}s", min, seg);
        }
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("Game");
    }

    public void AparecerTextoChefeCriado()
    {
        StartCoroutine(DesaparecerTexto(2, TextoChefeAparece));
    }

    IEnumerator DesaparecerTexto(float tempoDeSumir, Text texto)
    {
        TextoChefeAparece.gameObject.SetActive(true);
        Color corTexto = texto.color;
        corTexto.a = 1;
        texto.color = corTexto;
        yield return new WaitForSeconds(tempoDeSumir);
        float contador = 0;
        while (texto.color.a > 0)
        {
            contador += Time.deltaTime / tempoDeSumir;
            corTexto.a = Mathf.Lerp(1, 0, contador);
            texto.color = corTexto;
            if(texto.color.a <= 0){
                texto.gameObject.SetActive(false);
            }
            yield return null;
        }
        TextoChefeAparece.gameObject.SetActive(false);
    }
}
