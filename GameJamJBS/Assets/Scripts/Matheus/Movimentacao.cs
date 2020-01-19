using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    private ControleJogo controleJogo;
    public float velocidade = 10f;
    public float movimento;
    public float limiteDireita, limiteEsquerda;
    [HideInInspector] public int movimentoCelular;

    private void Start()
    {
        controleJogo = GameObject.Find("ControladorDeJogo").GetComponent<ControleJogo>();
    }

    private void Update()
    {
        if (ControleJogo.controleJogo.buildParaComputador)
            MovimentacaoComputador();
        else
            MovimentacaoCelular();

        if (Input.GetKeyDown(ControleJogo.ActionButton))
            controleJogo.ActionInput();
    }

    private void MovimentacaoComputador()
    {
        movimento = Input.GetAxis("Horizontal") * velocidade * Time.deltaTime;
        if (transform.position.x < limiteEsquerda && movimento < 0)
        {
            return;
        }
        else if (transform.position.x > limiteDireita && movimento > 0)
        {
            return;
        }
        else
        {
            if (controleJogo.podeAndar)
                transform.Translate(movimento, 0, 0);
        }
    }

    public void MovimentacaoCelular()
    {
        movimento = movimentoCelular * velocidade * Time.deltaTime;
        if (transform.position.x < limiteEsquerda && movimento < 0)
        {
            return;
        }
        else if (transform.position.x > limiteDireita && movimento > 0)
        {
            return;
        }
        else
        {
            if (controleJogo.podeAndar)
                transform.Translate(new Vector3(movimento, 0, 0));
        }
    }

    public void SetDirection(int value)
    {
        movimentoCelular = value;
    }

}
