using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoJogador : MovimentoPersonagem
{
    public void RotacaoJogador(LayerMask LayerGround)
    {
        var raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impact;
        if (Physics.Raycast(raio, out impact, 100f, LayerGround))
        {
            var positionTarget = impact.point - transform.position;
            positionTarget.y = transform.position.y;
            Rotacionar(positionTarget);
            
        }
    }
}

