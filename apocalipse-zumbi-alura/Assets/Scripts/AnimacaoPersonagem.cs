using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoPersonagem : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Atacar(bool estado)
    {
        _animator.SetBool("Attacking", estado);
    }

    public void Movimentar(float valorMovimento)
    {
        _animator.SetFloat("isMoving", valorMovimento);
    }

    public void Morrer(){
        _animator.SetTrigger("Morrer");
    }
}
