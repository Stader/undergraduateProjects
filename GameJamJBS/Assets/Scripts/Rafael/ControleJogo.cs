using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleJogo : MonoBehaviour
{
    [SerializeField] private KeyCode action;
    public static ControleCamera controleCamera;
    public static ControleJogo controleJogo;
    public static KeyCode ActionButton;
    public static bool pressionouAcao;
    public GameObject camera;

    public bool buildParaComputador;
    public bool podeAndar;

    private void Awake()
    {
        ActionButton = action;
    }
    void Start()
    {
        controleCamera = camera.GetComponent<ControleCamera>();
        controleJogo = this;
        podeAndar = true;
    }

    public void ActionInput()
    {
        Debug.Log("Passou");
        pressionouAcao = true;
        StartCoroutine(CancelAction());
    }

    private IEnumerator CancelAction()
    {
        yield return new WaitForSeconds(0.4f);
        pressionouAcao = false;
    }
}
