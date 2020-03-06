using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour, IMatavel, ICuravel
{
    private Vector3 _dir;
    public LayerMask LayerGround;
    public GameObject TextGameOver;
    [SerializeField] private InterfaceController scriptInterface;
    [SerializeField] private AudioClip somDeDano;
    private MovimentoJogador _movimentoJogador;
    private AnimacaoPersonagem _animacaoJogador;
    public Status status;

    private void Start()
    {
        _movimentoJogador = GetComponent<MovimentoJogador>();
        _animacaoJogador = GetComponent<AnimacaoPersonagem>();
        status = GetComponent<Status>();
    }

    private void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        _dir = new Vector3(x, 0, z);
        _animacaoJogador.Movimentar(_dir.magnitude);
    }

    private void FixedUpdate()
    {
        _movimentoJogador.Movimentar(_dir, status.Velocidade);
        _movimentoJogador.RotacaoJogador(LayerGround);
    }

    public void TomarDano(int dano)
    {
        status.Vida -= dano;
        scriptInterface.AtualizarSliderVidaJogador();
        AudioController.instancia.PlayOneShot(somDeDano);
        if (status.Vida <= 0)
        {
            Morrer();
        }
    }

    public void Morrer()
    {
        scriptInterface.GameOver();
    }

    public void CurarVida(int quantidadeDeCura)
    {
        status.Vida += quantidadeDeCura;
        if (status.Vida > status.vidaInicial)
            status.Vida = status.vidaInicial;
        scriptInterface.AtualizarSliderVidaJogador();
    }
}
