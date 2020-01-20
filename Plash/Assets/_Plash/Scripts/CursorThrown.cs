using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorThrown : MonoBehaviour
{
    //[Space(25f)]
    //[Header("Hi there!")]

    public bool apertou = false, soltou = false;
    private Vector3 posIni, posFin;
    public GameObject lixo;
    private ScriptTrash lixoScript;

    void Update()
    {
        if (apertou)
        {
            posIni = transform.position;
            apertou = false;
            lixoScript = lixo.GetComponent<ScriptTrash>();
        }
        if (soltou)
        {
            posFin = transform.position;
            soltou = false;
            CalcularDirecao();
        }
    }

    public void CalcularDirecao()
    {
        Vector3 diference = posFin - posIni;
        float sign = (posIni.x > posFin.x) ? -1.0f : 1.0f;
        diference.y = 0f;
        float angle = Vector3.Angle(Vector3.forward, diference) * sign;
        if (posFin.x >= posIni.x)
            return;
        else
            lixoScript.ChangeDirection(angle, true);
    }
}