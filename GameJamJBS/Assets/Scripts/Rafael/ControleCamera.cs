using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleCamera : MonoBehaviour
{
    private Animator _anim;
    public GameObject player;

    private bool ruaDeCima;
    private bool seguirJogador;
    private void Start()
    {
        ruaDeCima = true;
        seguirJogador = true;
        _anim = GetComponent<Animator>();
    }

    public void AlterarCamera()
    {
        _anim.SetTrigger("Alterar");
    }

    private void Update()
    {
        if (seguirJogador)
        {
            var finalPosition = player.transform.position;
            finalPosition.y += 4.9f;
            finalPosition.z = -10f;
            transform.position = finalPosition;
        }
    }

    public void AlterarPosicaoPersonagem()
    {
        if (ruaDeCima)
        {
            player.transform.position = new Vector2(player.transform.position.x, -30.4f);
            ruaDeCima = false;
        }else if (!ruaDeCima)
        {
            player.transform.position = new Vector2(player.transform.position.x, -6f);
            ruaDeCima = true;
        }
    }

    public void AlterarSeguirJogador()
    {
        seguirJogador = !seguirJogador;
    }
}
