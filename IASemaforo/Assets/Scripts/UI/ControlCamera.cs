using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlCamera : MonoBehaviour
{
    public Text textCamera;
    public Camera[] cameras;
	public GameObject luz;

    private int _camAtual = 0;

    private void Start()
    {
        foreach (var cam in cameras)
        {
            cam.gameObject.SetActive(false);
        }

        cameras[0].gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            _camAtual++;
            if (_camAtual > cameras.Length - 1)
            {
                cameras[cameras.Length - 1].gameObject.SetActive(false);
                _camAtual = 0;
                cameras[_camAtual].gameObject.SetActive(true);
            }
            else
            {
                cameras[_camAtual].gameObject.SetActive(true);
                cameras[_camAtual - 1].gameObject.SetActive(false);
            }

            AttTextCam();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            _camAtual--;
            if (_camAtual < 0)
            {
                cameras[0].gameObject.SetActive(false);
                _camAtual = cameras.Length - 1;
                cameras[_camAtual].gameObject.SetActive(true);
            }
            else
            {
                cameras[_camAtual].gameObject.SetActive(true);
                cameras[_camAtual + 1].gameObject.SetActive(false);
            }

            AttTextCam();
        }
    }

    private void AttTextCam()
    {
        if (_camAtual == 0)
        {
            textCamera.text = "CAM: PRINCIPAL";
			luz.SetActive (false);
        }
        else if (_camAtual == 1)
        {
            textCamera.text = "CAM: FRENTE";
        }
        else if (_camAtual == 2)
        {
            textCamera.text = "CAM: DIREITA";
        }
        else if (_camAtual == 3)
        {
            textCamera.text = "CAM: TRASEIRA";
        }
        else if (_camAtual == 4)
        {
            textCamera.text = "CAM: ESQUERDA";
        }
        else if (_camAtual == 5)
        {
            textCamera.text = "CAM: CRUZAMENTO";
        }
        else if (_camAtual == 6)
        {
            textCamera.text = "CAM: ARVORE";
			luz.SetActive (false);
        }else if (_camAtual == 7)
        {
            textCamera.text = "CAM: MANIPULAR";
			luz.SetActive (true);
        }
    }
}