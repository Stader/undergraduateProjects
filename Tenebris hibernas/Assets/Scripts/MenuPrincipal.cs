using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject interfaceMenu;
    [SerializeField] private GameObject interfaceSelectLevel;

    public void IniciarNovoJogo()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lvl1-1");
    }

    public void ContinuarJogo()
    {
        interfaceMenu.SetActive(false);
        interfaceSelectLevel.SetActive(true);
    }

    public void VoltarParaMenu()
    {
        interfaceMenu.SetActive(true);
        interfaceSelectLevel.SetActive(false);
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }

    public void SelectLvl1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lvl1-1");
    }

    public void SelectLvl2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lvl1-2");
    }
}
