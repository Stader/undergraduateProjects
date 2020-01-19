using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimarObjetivo : MonoBehaviour
{
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _anim.SetBool("objetivo", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _anim.SetBool("objetivo", false);
        }
    }
}
