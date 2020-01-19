using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorCarros : MonoBehaviour {

	private List<Collider> colliders = new List<Collider>();
	public int numeroDeCarros = 0;
	public List<Collider> GetColliders () { return colliders; }

	private void Update(){
		numeroDeCarros = GetColliders ().Count / 2;
	}

	private void OnTriggerEnter (Collider other) {
		if (!colliders.Contains(other)) { colliders.Add(other); }
	}

	private void OnTriggerExit (Collider other) {
		colliders.Remove(other);
	}

}
