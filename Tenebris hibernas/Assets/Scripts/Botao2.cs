using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botao2 : MonoBehaviour
{
    private Animator animator;
    private EsteiraGrandeQuebrada esteira;
    private void Start()
    {
        animator = GetComponent<Animator>();
        esteira = GameObject.Find("EsteiraGrandeQuebrada").GetComponent<EsteiraGrandeQuebrada>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Acionar", true);
            esteira.MoverDireita();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Acionar", false);
            esteira.Parar();
        }
    }
}
