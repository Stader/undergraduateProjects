using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCar : MonoBehaviour
{

	public int typeOfSinal;
	public LayerMask layerCarro;
	public GameObject[] carros;
	private Vector3 _posicaoDeCriacao;
	[SerializeField] private Quaternion rotation;
	[SerializeField] private Vector3 newRotation;

	void Start () {
		rotation = transform.localRotation;
		newRotation = rotation.eulerAngles;
		StartCoroutine (GerarCarro());
	}

	private IEnumerator GerarCarro()
	{
		var time = Random.Range (1, 7) + 1;
		_posicaoDeCriacao = transform.position;
		if(typeOfSinal == 1)
			_posicaoDeCriacao += new Vector3(0f,0f,-1.4f);
		else if(typeOfSinal == 2)
			_posicaoDeCriacao += new Vector3(0f,0f,1.4f);
		else if(typeOfSinal == 3)
			_posicaoDeCriacao += new Vector3(1.4f,0f,0f);
		else if(typeOfSinal == 4)
			_posicaoDeCriacao += new Vector3(-1.4f,0f,0f);
			
		yield return new WaitForSeconds (time);
		
		
		
		var colisores = Physics.OverlapSphere(_posicaoDeCriacao, 2f, layerCarro);
		while(colisores.Length > 0)
		{
			colisores = Physics.OverlapSphere(_posicaoDeCriacao, 2f, layerCarro);
			yield return null;
		}
		
		var carro = carros[Random.Range(0,carros.Length)];
		Instantiate (carro, transform.position, Quaternion.Euler(newRotation));
		StartCoroutine (GerarCarro());
	}
	
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(_posicaoDeCriacao, 2f);
	}
}
