using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnZombie : MonoBehaviour
{

    [SerializeField] private GameObject zombie;
    public LayerMask layerZumbi;
    private float distanciaGeracao = 3;
    private float _contadorTempo;
    public float tempoGerarZumbi = 2f;
    private float _distanciaDoJogadorParaGeracao = 20;
    private GameObject _jogador;
    private int qtdMaxDeZumbisVivos = 2;
    private int qtdZumbisVivos;
    private float tempoProximoAumentoDeDificuldade = 30;
    private float contadorAumentarDificuldade;

    private void Start()
    {
        _jogador = GameObject.FindWithTag(Tags.Jogador);
        contadorAumentarDificuldade = tempoProximoAumentoDeDificuldade;
        for(int i = 0; i< qtdMaxDeZumbisVivos; i++){
            StartCoroutine(Zombie());
        }
    }

    private void Update()
    {
        bool possoGerarZumbis = Vector3.Distance(transform.position, _jogador.transform.position) > _distanciaDoJogadorParaGeracao;
        if (possoGerarZumbis && qtdZumbisVivos <= qtdMaxDeZumbisVivos)
        {
            _contadorTempo += Time.deltaTime;
            if (_contadorTempo >= tempoGerarZumbi)
            {
                StartCoroutine(Zombie());
                _contadorTempo = 0;
            }
        }

        if(Time.timeSinceLevelLoad > contadorAumentarDificuldade){
            qtdMaxDeZumbisVivos++;
            contadorAumentarDificuldade = Time.timeSinceLevelLoad + tempoProximoAumentoDeDificuldade;
        }
    }

    private IEnumerator Zombie()
    {
        var posicaoDeCriacao = AleatorizarPosicao();
        var colisores = Physics.OverlapSphere(posicaoDeCriacao, 1, layerZumbi);
        while(colisores.Length > 0)
        {
            posicaoDeCriacao = AleatorizarPosicao();
            colisores = Physics.OverlapSphere(posicaoDeCriacao, 1, layerZumbi);
            yield return null;
        }
        var zumbi = Instantiate(zombie, posicaoDeCriacao, transform.rotation).GetComponent<ZombieController>();
        zumbi.meuGerador = this;
        qtdZumbisVivos++;
    }

    public void DiminuirQtdZumbisVivos(){
        qtdZumbisVivos--;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaGeracao);
    }

    Vector3 AleatorizarPosicao()
    {
        var posicao = Random.insideUnitSphere * distanciaGeracao;
        posicao += transform.position;
        posicao.y = 0;
        
        return posicao;
    }
}
