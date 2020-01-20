using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal.Input;

public class PauseGame : MonoBehaviour
{
    public bool isPause = false;
    [SerializeField]
    private GameObject menuPause;

    [SerializeField]
    private CursorInput inputSystem;

    [SerializeField] private StopWatch _watch;

    [SerializeField] private GameObject buttonPause;

    void Update()
    {

        if (inputSystem.declareInput == DeclareInput.Mouse)
        {
            buttonPause.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }
        else if (inputSystem.declareInput == DeclareInput.Touch)
            buttonPause.SetActive(true);
        if (isPause)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if(!isPause)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }


    public void ContinueGame()
    {
        menuPause.SetActive(false);
        isPause = false;
    }

    public void Pause()
    {
        isPause = true;
        menuPause.SetActive(true);
    }
}
