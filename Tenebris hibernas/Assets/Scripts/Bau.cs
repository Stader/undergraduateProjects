using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bau : MonoBehaviour
{
    private Animator animator;
    private new BoxCollider2D collider;
    private Rigidbody2D rb2d;
    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Espeto"))
        {
            animator.SetTrigger("Destruir");
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "LimiteBau")
        {
            collider.enabled = false;
            rb2d.gravityScale = 0.0f;
            animator.SetTrigger("Destruir");
        }
    }


    public void DestruirBau()
    {
        Destroy(gameObject);
    }
}
