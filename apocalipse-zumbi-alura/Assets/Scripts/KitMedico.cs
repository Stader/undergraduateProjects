using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitMedico : MonoBehaviour
{
    private int _quantidadeDeCura = 15;
    private float _tempoDeDestruir = 5f;

    private void Start()
    {
        Destroy(gameObject, _tempoDeDestruir);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(("Player")))
        {
            other.GetComponent<PlayerController>().CurarVida(_quantidadeDeCura);
            Destroy(gameObject);
        }
    }
}
