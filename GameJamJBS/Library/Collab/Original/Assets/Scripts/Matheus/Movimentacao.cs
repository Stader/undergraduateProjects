using UnityEngine;
using UnityEngine.UI;

public class Movimentacao : MonoBehaviour
{
    public float velocidade = 10f;
    public float movimento;
    public int movimentoCelular;

    private void Update()
    {
       if (ControleJogo.controleJogo.buildParaComputador)
            MovimentacaoComputador();
        else
            MovimentacaoCelular();
    }

    private void MovimentacaoComputador()
    {
        movimento = Input.GetAxis("Horizontal") * velocidade * Time.deltaTime;
        transform.Translate(movimento, 0, 0);
    }

    public void MovimentacaoCelular()
    {
        movimento = movimentoCelular * velocidade * Time.deltaTime;
        transform.Translate(new Vector3(movimento, 0, 0));
    }

    public void SetDirection(int value)
    {
        movimentoCelular = value;
    }

}
