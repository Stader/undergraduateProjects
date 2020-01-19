using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoPersonagem : MonoBehaviour
{
    private Movimentacao _mov;
    private ControleCamera _camera;
    private Animator _anim;
    private SpriteRenderer _sprite;

    private bool segurando = false;
    private bool aguardar = false;
    
    private void Start()
    {
        _mov = GetComponent<Movimentacao>();
        _camera = Camera.main.GetComponent<ControleCamera>();
        _anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_mov.movimento < -0.01f)
             _sprite.flipX = true;
        else if (_mov.movimento > 0f)
            _sprite.flipX = false;
        _anim.SetFloat("Andar", Mathf.Abs(_mov.movimento));
        _anim.SetBool("Segurando", segurando);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("TransicaoCamera"))
        {
            if (ControleJogo.pressionouAcao && !aguardar)
            {
                aguardar = true;
                ControleJogo.pressionouAcao = false;
                _camera.AlterarCamera();
                StartCoroutine(ResetarAguardar());
            }
        }
    }

    private IEnumerator ResetarAguardar()
    {
        yield return new WaitForSeconds(3f);
        aguardar = false;
    }
}
