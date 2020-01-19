using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsteiraGrandeQuebrada : MonoBehaviour
{
    private Animator animator;
    private bool moverDireita = false;
    private bool moverEsquerda = false;
    public float velocidade = 2.0f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        moverDireita = animator.GetBool("MoverDireita");
        moverEsquerda = animator.GetBool("MoverEsquerda");
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (moverDireita)
            collision.transform.Translate(new Vector3(velocidade, collision.rigidbody.velocity.y, 0.0f) * Time.deltaTime);
        else if (moverEsquerda)
            collision.transform.Translate(new Vector3(-velocidade, collision.rigidbody.velocity.y, 0.0f) * Time.deltaTime);
    }

    public void MoverDireita()
    {
        animator.SetBool("MoverDireita", true);
        animator.SetBool("MoverEsquerda", false);
    }
    public void MoverEsquerda()
    {
        animator.SetBool("MoverDireita", false);
        animator.SetBool("MoverEsquerda", true);
    }
    public void Parar()
    {
        animator.SetBool("MoverDireita", false);
        animator.SetBool("MoverEsquerda", false);
    }
}
