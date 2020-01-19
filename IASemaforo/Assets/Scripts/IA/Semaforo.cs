using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semaforo : MonoBehaviour
{
    //1 e 2 direito // 3 e 4 esquerdo // 5 e 6 frente // 7 e 8 atrás
    //impar semaforo de baixo
    //par semaforo grande de cima
    public GameObject[] semaforoVerde;
    public GameObject[] semaforoAmarelo;
    public GameObject[] semaforoVermelho;

    [SerializeField] private Material sinalVerde, sinalAmarelo, sinalVermelho, sinalOpaco;

    public GameObject[] colisores;

    private bool _ladoXAceso;

	private ContadorCarros _esqDir, _frenTras;

    private void Start()
    {
        _ladoXAceso = false;
		_esqDir = GameObject.Find ("Direito_Esquerdo").GetComponent<ContadorCarros>();
		_frenTras = GameObject.Find ("Frente_Atras").GetComponent<ContadorCarros>();
        StartCoroutine(ProximoSinal(10f));
    }

    private void Update()
    {
    }

	private void CalcularTempoIA(){
		if (!_ladoXAceso) { //prox a acender é lado esquerdo_direito
			if(_esqDir.numeroDeCarros < _frenTras.numeroDeCarros){
				StartCoroutine(ProximoSinal(5f));
			}else if(_esqDir.numeroDeCarros < 8){
				StartCoroutine(ProximoSinal(8f));
			}else if(_esqDir.numeroDeCarros < 12){
				StartCoroutine(ProximoSinal(13f));
			}else if(_esqDir.numeroDeCarros < 18){
				StartCoroutine(ProximoSinal(18f));
			}else{
				StartCoroutine(ProximoSinal(23f));
			}
		} else if (_ladoXAceso) { // prox a acender é o lado frente_tras
			if(_esqDir.numeroDeCarros > _frenTras.numeroDeCarros){
				StartCoroutine(ProximoSinal(5f));
			}else if(_frenTras.numeroDeCarros < 8){
				StartCoroutine(ProximoSinal(8f));
			}else if(_frenTras.numeroDeCarros < 12){
				StartCoroutine(ProximoSinal(13f));
			}else if(_frenTras.numeroDeCarros < 18){
				StartCoroutine(ProximoSinal(18f));
			}else{
				StartCoroutine(ProximoSinal(23f));
			}
		}
	}

    private IEnumerator ProximoSinal(float tempo)
    {
		Debug.Log ("Tempo Ligado: " + tempo + "   lado funcionando: " + _ladoXAceso);
        if (!_ladoXAceso)
        {
            _ladoXAceso = true;
            colisores[0].SetActive(false);
            colisores[1].SetActive(false);
            colisores[2].SetActive(true);
            colisores[3].SetActive(true);
            for (var i = 0; i < 4; i++)
            {
                semaforoVerde[i].GetComponent<Renderer>().sharedMaterial = sinalVerde;
                semaforoAmarelo[i].GetComponent<Renderer>().sharedMaterial = sinalOpaco;
                semaforoVermelho[i].GetComponent<Renderer>().sharedMaterial = sinalOpaco;
            }

            for (var i = 4; i < 8; i++)
            {
                semaforoVerde[i].GetComponent<Renderer>().sharedMaterial = sinalOpaco;
                semaforoAmarelo[i].GetComponent<Renderer>().sharedMaterial = sinalOpaco;
                semaforoVermelho[i].GetComponent<Renderer>().sharedMaterial = sinalVermelho;
            }
        }
        else
        {
            _ladoXAceso = false;
            colisores[0].SetActive(true);
            colisores[1].SetActive(true);
            colisores[2].SetActive(false);
            colisores[3].SetActive(false);

            for (var i = 0; i < 4; i++)
            {
                semaforoVerde[i].GetComponent<Renderer>().sharedMaterial = sinalOpaco;
                semaforoAmarelo[i].GetComponent<Renderer>().sharedMaterial = sinalOpaco;
                semaforoVermelho[i].GetComponent<Renderer>().sharedMaterial = sinalVermelho;
            }

            for (var i = 4; i < 8; i++)
            {
                semaforoVerde[i].GetComponent<Renderer>().sharedMaterial = sinalVerde;
                semaforoAmarelo[i].GetComponent<Renderer>().sharedMaterial = sinalOpaco;
                semaforoVermelho[i].GetComponent<Renderer>().sharedMaterial = sinalOpaco;
            }
        }

        StartCoroutine(ChamarAmarelo(tempo - 2f));

        yield return new WaitForSeconds(tempo);
		CalcularTempoIA ();
    }

    private IEnumerator ChamarAmarelo(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        colisores[0].SetActive(true);
        colisores[1].SetActive(true);
        colisores[2].SetActive(true);
        colisores[3].SetActive(true);
        if (_ladoXAceso)
        {
            for (var i = 0; i < 4; i++)
            {
                semaforoVerde[i].GetComponent<Renderer>().sharedMaterial = sinalOpaco;
                semaforoAmarelo[i].GetComponent<Renderer>().sharedMaterial = sinalAmarelo;
                semaforoVermelho[i].GetComponent<Renderer>().sharedMaterial = sinalOpaco;
            }
        }
        else
        {
            for (var i = 4; i < 8; i++)
            {
                semaforoVerde[i].GetComponent<Renderer>().sharedMaterial = sinalOpaco;
                semaforoAmarelo[i].GetComponent<Renderer>().sharedMaterial = sinalAmarelo;
                semaforoVermelho[i].GetComponent<Renderer>().sharedMaterial = sinalOpaco;
            }
        }
    }
}