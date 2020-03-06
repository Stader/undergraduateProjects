using UnityEngine;

public class GeradorChefe : MonoBehaviour
{
    private float tempoParaProximaGeração = 0;
    public float tempoEntreGeracoes = 60;
    public GameObject ChefePrefab;
    private InterfaceController scriptControlaInterface;
    public Transform[] PosicoesPossiveisDeGeracao;
    private Transform jogador;

    private void Start()
    {
        tempoParaProximaGeração = tempoEntreGeracoes;
        scriptControlaInterface = GameObject.FindObjectOfType(typeof(InterfaceController)) as InterfaceController;
        jogador = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (Time.timeSinceLevelLoad > tempoParaProximaGeração)
        {
            Vector3 posicaoDeCriacao = CalcularPosicaoMaisDistanteDoJogador();
            Instantiate(ChefePrefab, posicaoDeCriacao, Quaternion.identity);
            scriptControlaInterface.AparecerTextoChefeCriado();
            tempoParaProximaGeração = Time.timeSinceLevelLoad + tempoEntreGeracoes;
        }
    }

    Vector3 CalcularPosicaoMaisDistanteDoJogador()
    {
        Vector3 posicaoDeMaiorDistancia = Vector3.zero;
        float maiorDistancia = 0;
        foreach (Transform posicao in PosicoesPossiveisDeGeracao)
        {
            float distanciaEntreOJogador = Vector3.Distance(posicao.position, jogador.position);
            if (distanciaEntreOJogador > maiorDistancia){
                maiorDistancia = distanciaEntreOJogador;
                posicaoDeMaiorDistancia = posicao.position;
            }
                
        }


        return posicaoDeMaiorDistancia;
    }
}
