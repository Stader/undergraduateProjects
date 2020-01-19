using UnityEngine;
using UnityEngine.UI;

public class Movimentacao : MonoBehaviour
{
    public float velocidade = 10f;

    public int movimentoCelular;

    private void Update()
    {
        //Descomentar
       /* if (ControleJogo.controleJogo.buildParaComputador)
            MovimentacaoComputador();
        else*/
        MovimentacaoCelular();
    }

    private void MovimentacaoComputador()
    {
        float movimentacao = Input.GetAxis("Horizontal") * velocidade * Time.deltaTime;

        transform.Translate(movimentacao, 0, 0);
    }

    public void MovimentacaoCelular()
    {
        float movimentacao = movimentoCelular * velocidade * Time.deltaTime;
        transform.Translate(new Vector3(movimentacao, 0, 0));
    }

    public void SetDirection(int value)
    {
        movimentoCelular = value;
    }

}
