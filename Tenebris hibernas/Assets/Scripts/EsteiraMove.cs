using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsteiraMove : MonoBehaviour
{
    //private SpriteRenderer sprite;
    private ArrayList objetos = new ArrayList();
    private Animator anima;
    public bool moverDireita = true;
    public float velocidade = 2.0f;

    private void Awake()
    {
        anima = GetComponent<Animator>();
        //sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        anima.SetBool("MovimentoDireita", moverDireita);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (moverDireita)
        {
            collision.transform.Translate(new Vector3(velocidade, collision.rigidbody.velocity.y, 0.0f) * Time.deltaTime);
        }
        else
        {
            collision.transform.Translate(new Vector3(-velocidade, collision.rigidbody.velocity.y, 0.0f) * Time.deltaTime);
        }
    }

    public void AlterarMovimento()
    {
        if(moverDireita)
        {
            moverDireita = false;
        }
        else
        {
            moverDireita = true;
        }
    }
}
