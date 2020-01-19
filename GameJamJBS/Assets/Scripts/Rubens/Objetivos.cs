using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivos : MonoBehaviour
{
    public bool temGarrafa;
    public bool temOleo;

    [Header("Objetivos Concluidos")]
    public bool ObjetivoRecolherOleo;
    public bool ObjetivoEntregarOleoParaEscola;
    public bool ObjetivoInformarAlguem;
    public bool ObjetivoConscientizar;
    public bool ObjetivoEntregarGarrafa;

    public GameObject garrafaSemOleo;
    public GameObject garrafaComOleo;

    void Start()
    {
        garrafaSemOleo.SetActive(false);
        garrafaComOleo.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Pegar a garrafa vazia
        if (collision.tag == "Garrafa")
        {
            StartCoroutine(Interagir(collision));
        }
        //Entregar a garrafa vazia
        else if (collision.tag == "ObjetivoEntregarGarrafa" && temGarrafa)
        {
            if (!ObjetivoEntregarGarrafa)
            {
                print("Obrigado por me entregar uma garrafa!");

                temGarrafa = false;

                ObjetivoEntregarGarrafa = true;
                garrafaSemOleo.SetActive(false);
            }
        }

        //Coletar o oleo
        else if (collision.tag == "LocalDeColeta" && !temOleo)
        {
            if (!ObjetivoRecolherOleo && ControleJogo.pressionouAcao)
            {
                temOleo = true;
                ObjetivoRecolherOleo = true;
                garrafaComOleo.SetActive(true);
            }
        }

        //escola
        else if (collision.tag == "Escola" && temOleo)
        {
            if (!ObjetivoEntregarOleoParaEscola)
            {
                temOleo = false;
                print("Obrigado por trazer o oleo para escola!");

                ObjetivoEntregarOleoParaEscola = true;
                garrafaComOleo.SetActive(false);
            }
        }

        //Informar local de coleta de oleo
        else if (collision.tag == "ObjetivoInformar")
        {
            if (!ObjetivoInformarAlguem)
            {
                print("Obrigado por me informar sobre o local de coleta");
                collision.GetComponent<Collider2D>().enabled = false;

                ObjetivoInformarAlguem = true;
            }
        }

        //Conscientizar
        else if (collision.tag == "ObjetivoConscientizar" && temGarrafa)
        {
            if (!ObjetivoConscientizar)
            {
                print("Obrigado por me conscientizar!");
                collision.GetComponent<Collider2D>().enabled = false;

                temGarrafa = false;
                garrafaSemOleo.SetActive(false);
                ObjetivoConscientizar = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Garrafa")
        {
            StopCoroutine("Interagir");
        }
    }

    public IEnumerator Interagir(Collider2D objeto)
    {
        //Interação para pegar a garrafa sem oleo
        if (!temGarrafa)
        {
            yield return new WaitUntil(() => ControleJogo.pressionouAcao);
            Destroy(objeto.gameObject);
            temGarrafa = true;
            garrafaSemOleo.SetActive(true);
        }
    }
}
