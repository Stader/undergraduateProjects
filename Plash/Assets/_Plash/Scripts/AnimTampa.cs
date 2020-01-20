using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimTampa : MonoBehaviour
{

    public Animator _anim;
    private int aux;
    
    void Start()
    {
        aux = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash") && aux == 0)
        {
            aux++;
            _anim.SetTrigger("Abrir");
            StartCoroutine(Tempo());
        }
    }

    private IEnumerator Tempo()
    {
        var tempo = Random.Range(7f, 15f);
        yield return new WaitForSeconds(tempo);
        _anim.SetTrigger("Fechar");
        aux = 0;
    }
}
